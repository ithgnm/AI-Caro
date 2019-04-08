using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public class Board
    {
        #region Properties
        private Panel chessBoard;
        public Panel ChessBoard { get => chessBoard; set => chessBoard = value; }

        private List<Player> player;
        public List<Player> Player { get => player; set => player = value; }

        private int curPlayer;
        public int CurPlayer { get => curPlayer; set => curPlayer = value; }

        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private Stack<Info> curMove;
        public Stack<Info> CurMove { get => curMove; set => curMove = value; }

        private event EventHandler endedGame;
        public event EventHandler EndedGame { add => endedGame += value; remove => EndedGame -= value; }

        private int modeGame = new int();
        public int ModeGame { get => modeGame; set => modeGame = value; }

        private Stack<Point> isEndButton = new Stack<Point>();
        public Stack<Point> IsEndButton { get => isEndButton; set => isEndButton = value; }

        private List<int> comAttack = new List<int> { 0, 2, 89, 768, 2607, 12867 };
        public List<int> ComAttack { get => comAttack; set => comAttack = value; }

        private List<int> comDefend = new List<int> { 0, 4, 49, 515, 1771, 8769 };
        public List<int> ComDefend { get => comDefend; set => comDefend = value; }

        //private List<int> comAttack = new List<int> { 0, 3, 14, 98, 686, 4802 };
        //private List<int> comDefend = new List<int> { 0, 1, 9, 85, 769, 6921 };

        //private List<int> comAttack = new List<int> { 0, 9, 54, 162, 1458, 13112 };
        //private List<int> comDefend = new List<int> { 0, 3, 27, 99, 729, 6561 };
        #endregion

        public Board(Panel chessBoard)
        {
            this.ChessBoard = chessBoard;
            this.Player = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\o.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\x.png"))
            };
            CurPlayer = 0;
        }

        #region Board
        public void boardDraw()
        {
            ChessBoard.Enabled = true;
            ChessBoard.Controls.Clear();
            CurMove = new Stack<Info>();
            Matrix = new List<List<Button>>();
            IsEndButton = new Stack<Point>();
            Search = new Eval();
            Button oldBtn = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Value.chessBoardHeight; i++)
            {
                for (int j = 0; j <= Value.chessBoardWidth; j++)
                {
                    Matrix.Add(new List<Button>());
                    Button btn = new Button()
                    {
                        Width = Value.chessWidth,
                        Height = Value.chessHeight,
                        Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    btn.Click += btn_Click;
                    ChessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldBtn = btn;
                }
                oldBtn.Location = new Point(0, oldBtn.Location.Y + Value.chessHeight);
                oldBtn.Width = 0;
                oldBtn.Height = 0;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null) return;
            btn.BackgroundImage = Player[CurPlayer].Mark;
            CurMove.Push(new Info(getChessPoint(btn), CurPlayer));
            CurPlayer = CurPlayer == 1 ? 0 : 1;
            if (isEnd(btn)) EndGame();
            else
            {
                if (ModeGame == 0) return;
                else if (ModeGame == 1) comTurn();
                else if (ModeGame == 2) comDepthTurn();
            }
        }

        public void EndGame()
        {
            if (endedGame != null)
                endedGame(this, new EventArgs());
        }

        public bool isEnd(Button btn)
        {
            if (isEndHor(btn)) return true;
            if (isEndPri(btn)) return true;
            if (isEndVer(btn)) return true;
            if (isEndSub(btn)) return true;
            IsEndButton.Clear();
            return false;
        }

        public Point getChessPoint(Button btn)
        {
            int ver = Convert.ToInt32(btn.Tag);
            int hor = Matrix[ver].IndexOf(btn);
            Point point = new Point(hor, ver);
            return point;
        }

        #region Check Game State

        private bool isEndHor(Button btn)
        {
            Point point = getChessPoint(btn);
            Point tmpPoint = new Point();
            int checkBlock = 0;
            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y;
                    tmpPoint.X = i;
                    IsEndButton.Push(tmpPoint);
                    countLeft++;
                }
                else
                {
                    if (Matrix[point.Y][i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Value.chessBoardWidth; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y;
                    tmpPoint.X = i;
                    IsEndButton.Push(tmpPoint);
                    countRight++;
                }
                else
                {
                    if (Matrix[point.Y][i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            if (checkBlock == 2) return false;
            int count = countLeft + countRight;
            while (count > 5)
            {
                isEndButton.Pop();
                count--;
            }
            return count == 5;
        }

        private bool isEndVer(Button btn)
        {
            Point point = getChessPoint(btn);
            Point tmpPoint = new Point();
            int checkBlock = 0;
            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                    tmpPoint.Y = i;
                    tmpPoint.X = point.X;
                    IsEndButton.Push(tmpPoint);
                }
                else
                {
                    if (Matrix[i][point.X].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            int countBot = 0;
            for (int i = point.Y + 1; i < Value.chessBoardHeight; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBot++;
                    tmpPoint.Y = i;
                    tmpPoint.X = point.X;
                    IsEndButton.Push(tmpPoint);
                }
                else
                {
                    if (Matrix[i][point.X].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            if (checkBlock == 2) return false;
            int count = countTop + countBot;
            while (count > 5)
            {
                isEndButton.Pop();
                count--;
            }
            return count == 5;
        }

        private bool isEndPri(Button btn)
        {
            Point point = getChessPoint(btn);
            Point tmpPoint = new Point();
            int checkBlock = 0;
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0) break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y - i;
                    tmpPoint.X = point.X - i;
                    IsEndButton.Push(tmpPoint);
                    countTop++;
                }
                else
                {
                    if (Matrix[point.Y - i][point.X - i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            int countBot = 0;
            for (int i = 1; i <= Value.chessBoardWidth - point.X; i++)
            {
                if (point.Y + i >= Value.chessBoardHeight || point.X + i >= Value.chessBoardWidth) break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y + i;
                    tmpPoint.X = point.X + i;
                    IsEndButton.Push(tmpPoint);
                    countBot++;
                }
                else
                {
                    if (Matrix[point.Y + i][point.X + i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            if (checkBlock == 2) return false;
            int count = countTop + countBot;
            while (count > 5)
            {
                isEndButton.Pop();
                count--;
            }
            return count == 5;
        }

        private bool isEndSub(Button btn)
        {
            Point point = getChessPoint(btn);
            Point tmpPoint = new Point();
            int checkBlock = 0;
            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= Value.chessBoardWidth || point.Y - i < 0) break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y - i;
                    tmpPoint.X = point.X + i;
                    IsEndButton.Push(tmpPoint);
                    countTop++;
                }
                else
                {
                    if (Matrix[point.Y - i][point.X + i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            int countBot = 0;
            for (int i = 1; i <= Value.chessBoardWidth - point.Y; i++)
            {
                if (point.Y + i >= Value.chessBoardHeight || point.X - i < 0) break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    tmpPoint.Y = point.Y + i;
                    tmpPoint.X = point.X - i;
                    IsEndButton.Push(tmpPoint);
                    countBot++;
                }
                else
                {
                    if (Matrix[point.Y + i][point.X - i].BackgroundImage == Player[CurPlayer].Mark) checkBlock++;
                    break;
                }
            }
            if (checkBlock == 2) return false;
            int count = countTop + countBot;
            while (count > 5)
            {
                isEndButton.Pop();
                count--;
            }
            return count == 5;
        }

        public bool Undo()
        {
            if (CurMove.Count <= 1) return false;
            Info oldPoint = CurMove.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;
            if (CurMove.Count <= 0) CurPlayer = 0;
            else
            {
                oldPoint = CurMove.Peek();
                CurPlayer = oldPoint.CurPlayer == 1 ? 0 : 1;
            }
            return true;
        }
        #endregion
        #endregion

        #region Computer
        public void comFirstTurn()
        {
            Random rd = new Random();
            Button comBtn = new Button();
            do comBtn = Matrix[rd.Next(Value.chessBoardHeight / 2 - 2, Value.chessBoardHeight / 2 + 2)][rd.Next(Value.chessBoardWidth / 2 - 2, Value.chessBoardWidth / 2 + 2)];
            while (comBtn.BackgroundImage != null);
            comBtn.BackgroundImage = Player[CurPlayer].Mark;
            CurMove.Push(new Info(getChessPoint(comBtn), CurPlayer));
            CurPlayer = CurPlayer == 1 ? 0 : 1;
        }

        public void comTurn()
        {
            Point bestMove = comBestMove(CurPlayer);
            if (bestMove.X == -1 || bestMove.Y == -1)
            {
                CurPlayer = -1;
                EndGame();
                CurPlayer = 0;
                return;
            }
            Button comBtn = new Button();
            comBtn = Matrix[bestMove.Y][bestMove.X];
            comBtn.BackgroundImage = Player[CurPlayer].Mark;
            CurMove.Push(new Info(getChessPoint(comBtn), CurPlayer));
            CurPlayer = CurPlayer == 1 ? 0 : 1;
            if (isEnd(comBtn)) EndGame();
        }

        private int maxPos(int a, int b, int c, int d)
        {
            int tmp = a > b ? a : b;
            tmp = tmp > c ? tmp : c;
            return tmp > d ? tmp : d;
        }

        private Point comBestMove(int CurPlayer)
        {
            Search.ArrMatrix.Clear();
            Point bestMove = new Point(-1, -1);
            int score = -1996;
            for (int i = 0; i < Value.chessBoardHeight; i++)
            {
                for (int j = 0; j < Value.chessBoardWidth; j++)
                {
                    if (Matrix[i][j].BackgroundImage == null)
                    {
                        int scoreAttack, scoreDefend;
                        if (ModeGame == 1)
                        {
                            scoreAttack = maxPos(comAttHor(i, j, CurPlayer), comAttVer(i, j, CurPlayer), comAttPri(i, j, CurPlayer), comAttSub(i, j, CurPlayer));
                            scoreDefend = maxPos(comDefHor(i, j, CurPlayer), comDefVer(i, j, CurPlayer), comDefPri(i, j, CurPlayer), comDefSub(i, j, CurPlayer));
                        }
                        else
                        {
                            scoreAttack = comAttHor(i, j, CurPlayer) + comAttVer(i, j, CurPlayer) + comAttPri(i, j, CurPlayer) + comAttSub(i, j, CurPlayer);
                            scoreDefend = comDefHor(i, j, CurPlayer) + comDefVer(i, j, CurPlayer) + comDefPri(i, j, CurPlayer) + comDefSub(i, j, CurPlayer);
                        }
                        int scoreTemp = scoreAttack > scoreDefend ? scoreAttack : scoreDefend;
                        Score scr = new Score()
                        {
                            EmpScore = scoreTemp,
                            XPos = j,
                            YPos = i
                        };
                        Search.ArrMatrix.Add(scr);
                        if (score < scoreTemp)
                        {
                            score = scoreTemp;
                            bestMove.Y = i;
                            bestMove.X = j;
                        }
                    }
                }
            }
            return bestMove;
        }

        #region Finding Best Move
        private int comAttHor(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth; i++)
            {
                if (Matrix[height][width + i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height][width + i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0; i++)
            {
                if (Matrix[height][width - i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height][width - i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            if (countEnemy == 2) return 0;
            if (ModeGame == 2)
            {
                if (countOur == 4) return ComAttack[countOur + 1] * 5;
                else if (countOur >= 3 && countEnemy == 0) countOur++;
                
            }
            return ComAttack[countOur] - ComDefend[countEnemy + 1];
        }

        private int comAttVer(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 0; i < 6 && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height + i][width].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && height - i >= 0; i++)
            {
                if (Matrix[height - i][width].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height - i][width].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            if (countEnemy == 2) return 0;
            if (ModeGame == 2)
            {
                if (countOur == 4) return ComAttack[countOur + 1] * 5;
                else if (countOur >= 3 && countEnemy == 0) countOur++;

            }
            return ComAttack[countOur] - ComDefend[countEnemy + 1];
        }

        private int comAttPri(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width + i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height + i][width + i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0 && height - i >= 0; i++)
            {
                if (Matrix[height - i][width - i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height - i][width - i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            if (countEnemy == 2) return 0;
            if (ModeGame == 2)
            {
                if (countOur == 4) return ComAttack[countOur + 1] * 5;
                else if (countOur >= 3 && countEnemy == 0) countOur++;

            }
            return ComAttack[countOur] - ComDefend[countEnemy + 1];
        }

        private int comAttSub(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth && height - i >= 0; i++)
            {
                if (Matrix[height - i][width + i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height - i][width + i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0 && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width - i].BackgroundImage == Player[CurPlayer].Mark)
                    countOur++;
                else if (Matrix[height + i][width - i].BackgroundImage == Player[EnePlayer].Mark)
                {
                    countEnemy++;
                    break;
                }
                else break;
            }
            if (countEnemy == 2) return 0;
            if (ModeGame == 2)
            {
                if (countOur == 4) return ComAttack[countOur + 1] * 5;
                else if (countOur >= 3 && countEnemy == 0) countOur++;

            }
            return ComAttack[countOur] - ComDefend[countEnemy + 1];
        }

        private int comDefHor(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth; i++)
            {
                if (Matrix[height][width + i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height][width + i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0; i++)
            {
                if (Matrix[height][width - i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height][width - i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            if (countOur == 2) return 0;
            if (ModeGame == 2)
            {
                if (countEnemy == 4) return ComDefend[countEnemy + 1] * 2;
                else if (countEnemy == 3 && countOur == 0) return ComDefend[countEnemy + 1];
            }
            return ComDefend[countEnemy] - comAttack[countOur];
        }

        private int comDefVer(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height + i][width].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && height - i >= 0; i++)
            {
                if (Matrix[height - i][width].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height - i][width].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            if (countOur == 2) return 0;
            if (ModeGame == 2)
            {
                if (countEnemy == 4) return ComDefend[countEnemy + 1] * 2;
                else if (countEnemy == 3 && countOur == 0) return ComDefend[countEnemy + 1];
            }
            return ComDefend[countEnemy] - comAttack[countOur];
        }

        private int comDefPri(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width + i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height + i][width + i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0 && height - i >= 0; i++)
            {
                if (Matrix[height - i][width - i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height - i][width - i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            if (countOur == 2) return 0;
            if (ModeGame == 2)
            {
                if (countEnemy == 4) return ComDefend[countEnemy + 1] * 2;
                else if (countEnemy == 3 && countOur == 0) return ComDefend[countEnemy + 1];
            }
            return ComDefend[countEnemy] - comAttack[countOur];
        }

        private int comDefSub(int height, int width, int CurPlayer)
        {
            int countOur = 0;
            int countEnemy = 0;
            int EnePlayer = CurPlayer == 1 ? 0 : 1;
            for (int i = 1; i < 6 && width + i < Value.chessBoardWidth && height - i >= 0; i++)
            {
                if (Matrix[height - i][width + i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height - i][width + i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            for (int i = 1; i < 6 && width - i >= 0 && height + i < Value.chessBoardHeight; i++)
            {
                if (Matrix[height + i][width - i].BackgroundImage == Player[EnePlayer].Mark)
                    countEnemy++;
                else if (Matrix[height + i][width - i].BackgroundImage == Player[CurPlayer].Mark)
                {
                    countOur++;
                    break;
                }
                else break;
            }
            if (countOur == 2) return 0;
            if (ModeGame == 2)
            {
                if (countEnemy == 4) return ComDefend[countEnemy + 1] * 2;
                else if (countEnemy == 3 && countOur == 0) return ComDefend[countEnemy + 1];
            }
            return ComDefend[countEnemy] - comAttack[countOur];
        }
        #endregion

        #region MiniMax
        private bool isWin = false;
        private int depth = 0;
        int tempPlayer = new int();
        Eval Search;

        private Point[] ourMoves = new Point[Value.maxMove + 2];
        private Point[] eneMoves = new Point[Value.maxMove + 2];
        private Point[] winMove = new Point[Value.maxDepth + 2];
        private Point[] loseMove = new Point[Value.maxDepth + 2];

        private void findMove()
        {
            if (depth > Value.maxDepth) return;
            depth++;
            isWin = false;
            bool isLose = false;
            Point ourMove = new Point();
            Point eneMove = new Point();
            Point tempMove = comBestMove(tempPlayer);
            for (int i = 0; i < Value.maxMove; i++)
            {
                tempMove = Search.MaxPosition();
                ourMoves[i] = tempMove;
                if (Search.ArrMatrix.Count != 0) Search.ArrMatrix.Remove(Search.ArrMatrix[0]);
            }
            int countMove = 0;
            while (countMove < Value.maxMove)
            {
                ourMove = ourMoves[countMove++];
                Button btn = Matrix[ourMove.Y][ourMove.X];
                btn.BackgroundImage = Player[tempPlayer].Mark;
                winMove.SetValue(ourMove, depth - 1);
                Search.ArrMatrix.Clear();
                tempPlayer = tempPlayer == 1 ? 0 : 1;
                comBestMove(tempPlayer);
                for (int i = 0; i < Value.maxMove; i++)
                {
                    tempMove = Search.MaxPosition();
                    eneMoves[i] = tempMove;
                    if (Search.ArrMatrix.Count != 0) Search.ArrMatrix.Remove(Search.ArrMatrix[0]);
                }
                for (int i = 0; i < Value.maxMove; i++)
                {
                    eneMove = eneMoves[i];
                    btn = Matrix[eneMove.Y][eneMove.X];
                    btn.BackgroundImage = Player[tempPlayer].Mark;
                    if (isEnd(btn))
                    {
                        if (tempPlayer == CurPlayer)
                        {
                            isWin = true;
                            //MessageBox.Show("isWin: " + isWin.ToString());
                        }
                        else
                        {
                            isLose = true;
                            //MessageBox.Show("isLose: " + isLose.ToString());
                        }
                    }
                    if (isLose)
                    {
                        btn = Matrix[ourMove.Y][ourMove.X];
                        btn.BackgroundImage = null;
                        btn = Matrix[eneMove.Y][eneMove.X];
                        btn.BackgroundImage = null;
                        break;
                    }
                    if (isWin)
                    {
                        btn = Matrix[ourMove.Y][ourMove.X];
                        btn.BackgroundImage = null;
                        btn = Matrix[eneMove.Y][eneMove.X];
                        btn.BackgroundImage = null;
                        return;
                    }
                    findMove();
                    btn = Matrix[eneMove.Y][eneMove.X];
                    btn.BackgroundImage = null;
                }
                btn = Matrix[ourMove.Y][ourMove.X];
                btn.BackgroundImage = null;
            }
        }

        public void comDepthTurn()
        {
            for (int i = 0; i < Value.maxMove; i++)
            {
                winMove[i] = new Point();
                ourMoves[i] = new Point();
                eneMoves[i] = new Point();
            }
            depth = 0;
            tempPlayer = CurPlayer;
            findMove();
            //MessageBox.Show(depth.ToString());
            Point bestMove = new Point();
            Button comBtn = new Button();
            if (isWin) bestMove = winMove[0];
            else bestMove = comBestMove(CurPlayer);
            if (bestMove.X == -1 || bestMove.Y == -1)
            {
                CurPlayer = -1;
                EndGame();
                CurPlayer = 0;
                return;
            }
            comBtn = Matrix[bestMove.Y][bestMove.X];
            comBtn.BackgroundImage = Player[CurPlayer].Mark;
            CurMove.Push(new Info(getChessPoint(comBtn), CurPlayer));
            CurPlayer = CurPlayer == 1 ? 0 : 1;
            if (isEnd(comBtn)) EndGame();
        }
        #endregion
        #endregion
    }
}