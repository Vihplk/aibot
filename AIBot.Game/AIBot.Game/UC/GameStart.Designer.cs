namespace AIBot.Game.UC
{
    partial class GameStart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.picHero = new System.Windows.Forms.PictureBox();
            this.btnStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHero)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Mistral", 50.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblName.Location = new System.Drawing.Point(290, 49);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(540, 79);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "SUPERMAN IN JUNGLE";
            // 
            // picHero
            // 
            this.picHero.Image = global::AIBot.Game.Properties.Resources.supermanwin;
            this.picHero.Location = new System.Drawing.Point(244, 149);
            this.picHero.Name = "picHero";
            this.picHero.Size = new System.Drawing.Size(240, 222);
            this.picHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHero.TabIndex = 7;
            this.picHero.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::AIBot.Game.Properties.Resources.stard;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(592, 149);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(278, 230);
            this.btnStart.TabIndex = 6;
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // GameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picHero);
            this.Controls.Add(this.btnStart);
            this.Name = "GameStart";
            this.Size = new System.Drawing.Size(1100, 550);
            ((System.ComponentModel.ISupportInitialize)(this.picHero)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picHero;
        private System.Windows.Forms.Button btnStart;
    }
}
