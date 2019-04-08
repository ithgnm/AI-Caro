namespace Caro
{
    partial class Caro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caro));
            this.panelBoard = new System.Windows.Forms.Panel();
            this.panelMode = new System.Windows.Forms.Panel();
            this.btnPlayerDual = new System.Windows.Forms.Button();
            this.btnComDual = new System.Windows.Forms.Button();
            this.btnExtreme = new System.Windows.Forms.Button();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnNormal = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extremeComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comVsComToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textSubject = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.hintMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMode.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.AccessibleDescription = "";
            this.panelBoard.BackColor = System.Drawing.SystemColors.Control;
            this.panelBoard.Location = new System.Drawing.Point(12, 29);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(600, 600);
            this.panelBoard.TabIndex = 0;
            // 
            // panelMode
            // 
            this.panelMode.Controls.Add(this.btnPlayerDual);
            this.panelMode.Controls.Add(this.btnComDual);
            this.panelMode.Controls.Add(this.btnExtreme);
            this.panelMode.Controls.Add(this.btnHard);
            this.panelMode.Controls.Add(this.btnNormal);
            this.panelMode.Location = new System.Drawing.Point(621, 296);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(274, 333);
            this.panelMode.TabIndex = 0;
            // 
            // btnPlayerDual
            // 
            this.btnPlayerDual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayerDual.Location = new System.Drawing.Point(17, 3);
            this.btnPlayerDual.Name = "btnPlayerDual";
            this.btnPlayerDual.Size = new System.Drawing.Size(240, 50);
            this.btnPlayerDual.TabIndex = 1;
            this.btnPlayerDual.Text = "Player vs. Player";
            this.btnPlayerDual.UseVisualStyleBackColor = true;
            this.btnPlayerDual.Click += new System.EventHandler(this.btnPlayerDual_Click);
            // 
            // btnComDual
            // 
            this.btnComDual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComDual.Location = new System.Drawing.Point(17, 283);
            this.btnComDual.Name = "btnComDual";
            this.btnComDual.Size = new System.Drawing.Size(240, 50);
            this.btnComDual.TabIndex = 0;
            this.btnComDual.Text = "Computer vs. Computer";
            this.btnComDual.UseVisualStyleBackColor = true;
            this.btnComDual.Click += new System.EventHandler(this.btnComDual_Click);
            // 
            // btnExtreme
            // 
            this.btnExtreme.Enabled = false;
            this.btnExtreme.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExtreme.Location = new System.Drawing.Point(17, 213);
            this.btnExtreme.Name = "btnExtreme";
            this.btnExtreme.Size = new System.Drawing.Size(240, 50);
            this.btnExtreme.TabIndex = 0;
            this.btnExtreme.Text = "Extreme Computer";
            this.btnExtreme.UseVisualStyleBackColor = true;
            // 
            // btnHard
            // 
            this.btnHard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHard.Location = new System.Drawing.Point(17, 143);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(240, 50);
            this.btnHard.TabIndex = 0;
            this.btnHard.Text = "Hard Computer";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormal.Location = new System.Drawing.Point(17, 73);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(240, 50);
            this.btnNormal.TabIndex = 0;
            this.btnNormal.Text = "Normal Computer";
            this.btnNormal.UseVisualStyleBackColor = true;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.modeToolStripMenuItem,
            this.informationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.hintMoveToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newGameToolStripMenuItem.ShowShortcutKeys = false;
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click_1);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.ShowShortcutKeys = false;
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.quitToolStripMenuItem.ShowShortcutKeys = false;
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.normalComputerToolStripMenuItem,
            this.hardComputerToolStripMenuItem,
            this.extremeComputerToolStripMenuItem,
            this.comVsComToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.modeToolStripMenuItem.Text = "Mode";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs. Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerVsPlayerToolStripMenuItem_Click);
            // 
            // normalComputerToolStripMenuItem
            // 
            this.normalComputerToolStripMenuItem.Name = "normalComputerToolStripMenuItem";
            this.normalComputerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.normalComputerToolStripMenuItem.Text = "Normal Computer";
            this.normalComputerToolStripMenuItem.Click += new System.EventHandler(this.normalComputerToolStripMenuItem_Click);
            // 
            // hardComputerToolStripMenuItem
            // 
            this.hardComputerToolStripMenuItem.Name = "hardComputerToolStripMenuItem";
            this.hardComputerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.hardComputerToolStripMenuItem.Text = "Hard Computer";
            this.hardComputerToolStripMenuItem.Click += new System.EventHandler(this.hardComputerToolStripMenuItem_Click);
            // 
            // extremeComputerToolStripMenuItem
            // 
            this.extremeComputerToolStripMenuItem.Enabled = false;
            this.extremeComputerToolStripMenuItem.Name = "extremeComputerToolStripMenuItem";
            this.extremeComputerToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.extremeComputerToolStripMenuItem.Text = "Extreme Computer";
            // 
            // comVsComToolStripMenuItem
            // 
            this.comVsComToolStripMenuItem.Name = "comVsComToolStripMenuItem";
            this.comVsComToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.comVsComToolStripMenuItem.Text = "Computer vs. Computer";
            this.comVsComToolStripMenuItem.Click += new System.EventHandler(this.comVsComToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.informationToolStripMenuItem.Text = "About Me";
            this.informationToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textSubject
            // 
            this.textSubject.BackColor = System.Drawing.SystemColors.Control;
            this.textSubject.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textSubject.Cursor = System.Windows.Forms.Cursors.Default;
            this.textSubject.Enabled = false;
            this.textSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubject.Location = new System.Drawing.Point(12, 636);
            this.textSubject.Name = "textSubject";
            this.textSubject.ReadOnly = true;
            this.textSubject.Size = new System.Drawing.Size(297, 16);
            this.textSubject.TabIndex = 2;
            this.textSubject.Text = "Artificial Intelligence Project";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Caro.Properties.Resources.a;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(638, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 240);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // hintMoveToolStripMenuItem
            // 
            this.hintMoveToolStripMenuItem.Name = "hintMoveToolStripMenuItem";
            this.hintMoveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.hintMoveToolStripMenuItem.ShowShortcutKeys = false;
            this.hintMoveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hintMoveToolStripMenuItem.Text = "Hint Move";
            this.hintMoveToolStripMenuItem.Click += new System.EventHandler(this.hintMoveToolStripMenuItem_Click);
            // 
            // Caro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(904, 661);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelMode);
            this.Controls.Add(this.textSubject);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Caro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI Caro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelMode.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnComDual;
        private System.Windows.Forms.Button btnExtreme;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnNormal;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extremeComputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comVsComToolStripMenuItem;
        private System.Windows.Forms.Button btnPlayerDual;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintMoveToolStripMenuItem;
    }
}

