namespace AIBot.Game.UC
{
    partial class StressLevelOne
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
            this.components = new System.ComponentModel.Container();
            this.tmrBackgroundImage = new System.Windows.Forms.Timer(this.components);
            this.tmrCount = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFaild = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picQuit = new System.Windows.Forms.PictureBox();
            this.picAction = new System.Windows.Forms.PictureBox();
            this.picHero = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrBackgroundImage
            // 
            this.tmrBackgroundImage.Tick += new System.EventHandler(this.tmrBackgroundImage_Tick);
            // 
            // tmrCount
            // 
            this.tmrCount.Interval = 1000;
            this.tmrCount.Tick += new System.EventHandler(this.tmrCount_Tick);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(159, 38);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 31);
            this.lblTime.TabIndex = 4;
            this.lblTime.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "SUCCESS";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Location = new System.Drawing.Point(127, 29);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(13, 13);
            this.lblSuccess.TabIndex = 6;
            this.lblSuccess.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "FAILED";
            // 
            // lblFaild
            // 
            this.lblFaild.AutoSize = true;
            this.lblFaild.Location = new System.Drawing.Point(127, 74);
            this.lblFaild.Name = "lblFaild";
            this.lblFaild.Size = new System.Drawing.Size(13, 13);
            this.lblFaild.TabIndex = 8;
            this.lblFaild.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.picQuit);
            this.groupBox1.Controls.Add(this.lblTime);
            this.groupBox1.Controls.Add(this.picAction);
            this.groupBox1.Controls.Add(this.lblSuccess);
            this.groupBox1.Controls.Add(this.lblFaild);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(743, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACTIONS";
            // 
            // picQuit
            // 
            this.picQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picQuit.Image = global::AIBot.Game.Properties.Resources.quit;
            this.picQuit.Location = new System.Drawing.Point(309, 38);
            this.picQuit.Name = "picQuit";
            this.picQuit.Size = new System.Drawing.Size(39, 31);
            this.picQuit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picQuit.TabIndex = 10;
            this.picQuit.TabStop = false;
            this.picQuit.Click += new System.EventHandler(this.picQuit_Click);
            // 
            // picAction
            // 
            this.picAction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAction.Location = new System.Drawing.Point(236, 38);
            this.picAction.Name = "picAction";
            this.picAction.Size = new System.Drawing.Size(39, 31);
            this.picAction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAction.TabIndex = 9;
            this.picAction.TabStop = false;
            this.picAction.Click += new System.EventHandler(this.picAction_Click);
            // 
            // picHero
            // 
            this.picHero.Location = new System.Drawing.Point(32, 48);
            this.picHero.Name = "picHero";
            this.picHero.Size = new System.Drawing.Size(70, 40);
            this.picHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHero.TabIndex = 3;
            this.picHero.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AIBot.Game.Properties.Resources.tree2;
            this.pictureBox3.Location = new System.Drawing.Point(1106, 365);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(168, 182);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::AIBot.Game.Properties.Resources.tree3;
            this.pictureBox2.Location = new System.Drawing.Point(1101, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(286, 410);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AIBot.Game.Properties.Resources.tree4;
            this.pictureBox1.Location = new System.Drawing.Point(1108, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 310);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // StressLevelOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picHero);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "StressLevelOne";
            this.Size = new System.Drawing.Size(1100, 550);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StressLevelOne_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StressLevelOne_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrBackgroundImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picHero;
        private System.Windows.Forms.Timer tmrCount;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFaild;
        private System.Windows.Forms.PictureBox picAction;
        private System.Windows.Forms.PictureBox picQuit;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
