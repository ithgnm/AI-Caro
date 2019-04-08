namespace Caro
{
    partial class About
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
            this.btnClose = new System.Windows.Forms.Button();
            this.textName = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.textClub = new System.Windows.Forms.TextBox();
            this.textPosition = new System.Windows.Forms.TextBox();
            this.textMajor = new System.Windows.Forms.TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(419, 199);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // textName
            // 
            this.textName.BackColor = System.Drawing.SystemColors.Control;
            this.textName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textName.Location = new System.Drawing.Point(254, 62);
            this.textName.Name = "textName";
            this.textName.ReadOnly = true;
            this.textName.Size = new System.Drawing.Size(230, 22);
            this.textName.TabIndex = 1;
            this.textName.Text = "HUY NGUYỄN MINH";
            this.textName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textName.WordWrap = false;
            this.textName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textName_MouseClick);
            // 
            // textID
            // 
            this.textID.BackColor = System.Drawing.SystemColors.Control;
            this.textID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textID.Cursor = System.Windows.Forms.Cursors.Default;
            this.textID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textID.Location = new System.Drawing.Point(254, 37);
            this.textID.Name = "textID";
            this.textID.ReadOnly = true;
            this.textID.Size = new System.Drawing.Size(230, 19);
            this.textID.TabIndex = 1;
            this.textID.Text = "17D1TH01 - 175050002";
            this.textID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textID.WordWrap = false;
            // 
            // textClub
            // 
            this.textClub.BackColor = System.Drawing.SystemColors.Control;
            this.textClub.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textClub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textClub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClub.Location = new System.Drawing.Point(254, 161);
            this.textClub.Name = "textClub";
            this.textClub.ReadOnly = true;
            this.textClub.Size = new System.Drawing.Size(230, 19);
            this.textClub.TabIndex = 1;
            this.textClub.Text = "Olympiad in Informatics Club";
            this.textClub.WordWrap = false;
            this.textClub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textClub_MouseClick);
            // 
            // textPosition
            // 
            this.textPosition.BackColor = System.Drawing.SystemColors.Control;
            this.textPosition.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textPosition.Cursor = System.Windows.Forms.Cursors.Default;
            this.textPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPosition.Location = new System.Drawing.Point(254, 140);
            this.textPosition.Name = "textPosition";
            this.textPosition.ReadOnly = true;
            this.textPosition.Size = new System.Drawing.Size(230, 15);
            this.textPosition.TabIndex = 1;
            this.textPosition.Text = "Chairmain of";
            this.textPosition.WordWrap = false;
            // 
            // textMajor
            // 
            this.textMajor.BackColor = System.Drawing.SystemColors.Control;
            this.textMajor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textMajor.Cursor = System.Windows.Forms.Cursors.Default;
            this.textMajor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMajor.Location = new System.Drawing.Point(254, 90);
            this.textMajor.Name = "textMajor";
            this.textMajor.ReadOnly = true;
            this.textMajor.Size = new System.Drawing.Size(230, 19);
            this.textMajor.TabIndex = 1;
            this.textMajor.Text = "Information Technology";
            this.textMajor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textMajor.WordWrap = false;
            // 
            // picAvatar
            // 
            this.picAvatar.BackgroundImage = global::Caro.Properties.Resources.am;
            this.picAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAvatar.Location = new System.Drawing.Point(25, 18);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(200, 200);
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 236);
            this.ControlBox = false;
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.textPosition);
            this.Controls.Add(this.textMajor);
            this.Controls.Add(this.textClub);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textClub;
        private System.Windows.Forms.TextBox textPosition;
        private System.Windows.Forms.TextBox textMajor;
        private System.Windows.Forms.PictureBox picAvatar;
    }
}