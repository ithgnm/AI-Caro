using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caro
{
    public partial class Caro : System.Windows.Forms.Form
    {
        Board ChessBoard;

        public Caro()
        {
            InitializeComponent();
            ChessBoard = new Board(panelBoard);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.boardDraw();
            panelBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            hintMoveToolStripMenuItem.Enabled = false;
        }

        void EndGame()
        {
            timer1.Stop();
            panelBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            hintMoveToolStripMenuItem.Enabled = false;
            Button btn = new Button();
            Point point = new Point();
            if (ChessBoard.CurPlayer != -1)
            {
                //MessageBox.Show(ChessBoard.IsEndButton.Count.ToString());
                for (int i = 0; i < 5; i++)
                {
                    point = ChessBoard.IsEndButton.Pop();
                    btn = ChessBoard.Matrix[point.Y][point.X];
                    btn.BackColor = Color.Gray;   
                }
            }
            if (ChessBoard.CurPlayer == -1)
                MessageBox.Show("Ended, draw game!");
            else if (ChessBoard.CurPlayer == 0)
                MessageBox.Show("Ended, X is winner!");
            else MessageBox.Show("Ended, O is winner!");
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            hintMoveToolStripMenuItem.Enabled = false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ChessBoard.ModeGame == 0) ChessBoard.Undo();
            else
            {
                ChessBoard.Undo();
                ChessBoard.Undo();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (MessageBox.Show("Exit?", "", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ChessBoard.comTurn();
            //ChessBoard.comDepthTurn();
        }
        private void comVsComToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.boardDraw();
            ChessBoard.comFirstTurn();
            panelBoard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            hintMoveToolStripMenuItem.Enabled = false;
            timer1.Start();
        }

        private void btnComDual_Click(object sender, EventArgs e)
        {
            ChessBoard.ComAttack = new List<int> { 0, 2, 89, 768, 2607, 12867 };
            ChessBoard.ComDefend = new List<int> { 0, 4, 49, 515, 1771, 8769 };
            hintMoveToolStripMenuItem.Enabled = false;
            comVsComToolStripMenuItem_Click(sender, e);
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Random rdAtt = new Random();
            Random rdDef = new Random();
            ChessBoard.ComAttack = new List<int> { 0, rdAtt.Next(1, 5), rdAtt.Next(19, 49), rdAtt.Next(99, 199), rdAtt.Next(599, 1999), rdAtt.Next(4999, 9999), rdAtt.Next(4999, 9999) };
            ChessBoard.ComDefend = new List<int> { 0, rdDef.Next(1, 5), rdDef.Next(19, 49), rdDef.Next(99, 199), rdDef.Next(599, 1999), rdDef.Next(4999, 9999), rdAtt.Next(4999, 9999) };
            ChessBoard.ModeGame = 1;
            ChessBoard.boardDraw();
            undoToolStripMenuItem.Enabled = true;
            hintMoveToolStripMenuItem.Enabled = true;
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            //ChessBoard.ComAttack = new List<int> { 0, 1, 9, 85, 769, 6921, 62289 };
            ChessBoard.ComAttack = new List<int> { 0, 3, 54, 162, 1458, 13112, 68769 };
            ChessBoard.ComDefend = new List<int> { 0, 1, 26, 256, 2308, 8769, 26796 };
            //ChessBoard.ComDefend = new List<int> { 0, 3, 27, 99, 729, 6561, 32189 };
            ChessBoard.ModeGame = 2;
            ChessBoard.boardDraw();
            ChessBoard.comFirstTurn();
            undoToolStripMenuItem.Enabled = true;
            hintMoveToolStripMenuItem.Enabled = true;
        }

        private void normalComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNormal_Click(sender, e);
        }

        private void hardComputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnHard_Click(sender, e);
        }

        private void btnPlayerDual_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            ChessBoard.boardDraw();
            ChessBoard.ModeGame = 0;
            undoToolStripMenuItem.Enabled = true;
            hintMoveToolStripMenuItem.Enabled = true;
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ChessBoard.boardDraw();
            panelBoard.Enabled = false;
        }

        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPlayerDual_Click(sender, e);
        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void hintMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChessBoard.comDepthTurn();
            if (ChessBoard.ModeGame == 0) return;
            else if (ChessBoard.ModeGame == 2) ChessBoard.comDepthTurn();
            else ChessBoard.comTurn();
        }
    }
}