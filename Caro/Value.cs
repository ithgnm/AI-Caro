using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public class Value
    {
        public static int chessWidth = 30;
        public static int chessHeight = 30;

        public static int chessBoardWidth = 20;
        public static int chessBoardHeight = 20;

        public static int maxDepth = 9;
        public static int maxMove = 3;
    }

    public class Player
    {
        private string name;
        public string Name { get => name; set => name = value; }

        private Image mark;
        public Image Mark { get => mark; set => mark = value; }

        public Player(string name, Image mark)
        {
            this.Name = name;
            this.Mark = mark;
        }
    }

    public class Info
    {
        private Point point;
        public Point Point { get => point; set => point = value; }

        private int curPlayer;
        public int CurPlayer { get => curPlayer; set => curPlayer = value; }

        public Info(Point point, int curPlayer)
        {
            this.Point = point;
            this.CurPlayer = curPlayer;
        }
    }

    public class Score : IComparer<Score>
    {
        private int empScore;
        public int EmpScore { get => empScore; set => empScore = value; }

        private int xPos, yPos;
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }

        public int Compare(Score a, Score b)
        {
            if (a.EmpScore > b.EmpScore) return -1;
            else if (a.EmpScore < b.EmpScore) return 1;
            else return 0;
        }
    }

    public class Eval
    {
        private int xPos, yPos;
        private List<Score> arrMatrix;
        public int XPos { get => xPos; set => xPos = value; }
        public int YPos { get => yPos; set => yPos = value; }
        public List<Score> ArrMatrix { get => arrMatrix; set => arrMatrix = value; }

        public Eval()
        {
            XPos = Value.chessBoardHeight;
            YPos = Value.chessBoardWidth;
            ArrMatrix = new List<Score>();
            //arrMatrix.Clear();
        }

        public Point MaxPosition()
        {
            Point point = new Point();
            ArrMatrix.Sort(new Score());
            if(ArrMatrix.Count != 0)
            {
                point.Y = ArrMatrix[0].YPos;
                point.X = ArrMatrix[0].XPos;
            }
            return point;
        }
    }
}
