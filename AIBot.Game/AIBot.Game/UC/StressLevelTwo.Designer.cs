namespace AIBot.Game.UC
{
    partial class StressLevelTwo
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
            this.picBucketBlue = new System.Windows.Forms.PictureBox();
            this.picBucketRed = new System.Windows.Forms.PictureBox();
            this.picBucketYello = new System.Windows.Forms.PictureBox();
            this.pnlBaloon = new System.Windows.Forms.Panel();
            this.lblFaild = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tmrCountDown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBucketBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBucketRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBucketYello)).BeginInit();
            this.pnlBaloon.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBucketBlue
            // 
            this.picBucketBlue.Location = new System.Drawing.Point(153, 351);
            this.picBucketBlue.Name = "picBucketBlue";
            this.picBucketBlue.Size = new System.Drawing.Size(169, 165);
            this.picBucketBlue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBucketBlue.TabIndex = 0;
            this.picBucketBlue.TabStop = false;
            this.picBucketBlue.Click += new System.EventHandler(this.picBucketBlue_Click);
            // 
            // picBucketRed
            // 
            this.picBucketRed.Location = new System.Drawing.Point(402, 351);
            this.picBucketRed.Name = "picBucketRed";
            this.picBucketRed.Size = new System.Drawing.Size(169, 165);
            this.picBucketRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBucketRed.TabIndex = 1;
            this.picBucketRed.TabStop = false;
            this.picBucketRed.Click += new System.EventHandler(this.picBucketRed_Click);
            // 
            // picBucketYello
            // 
            this.picBucketYello.Location = new System.Drawing.Point(631, 351);
            this.picBucketYello.Name = "picBucketYello";
            this.picBucketYello.Size = new System.Drawing.Size(169, 165);
            this.picBucketYello.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBucketYello.TabIndex = 2;
            this.picBucketYello.TabStop = false;
            this.picBucketYello.Click += new System.EventHandler(this.picBucketYello_Click);
            // 
            // pnlBaloon
            // 
            this.pnlBaloon.Controls.Add(this.lblFaild);
            this.pnlBaloon.Controls.Add(this.label3);
            this.pnlBaloon.Controls.Add(this.lblSuccess);
            this.pnlBaloon.Controls.Add(this.label1);
            this.pnlBaloon.Controls.Add(this.lblTime);
            this.pnlBaloon.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBaloon.Location = new System.Drawing.Point(0, 0);
            this.pnlBaloon.Name = "pnlBaloon";
            this.pnlBaloon.Size = new System.Drawing.Size(1100, 127);
            this.pnlBaloon.TabIndex = 3;
            // 
            // lblFaild
            // 
            this.lblFaild.AutoSize = true;
            this.lblFaild.Location = new System.Drawing.Point(989, 75);
            this.lblFaild.Name = "lblFaild";
            this.lblFaild.Size = new System.Drawing.Size(13, 13);
            this.lblFaild.TabIndex = 13;
            this.lblFaild.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(912, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "FAILED";
            // 
            // lblSuccess
            // 
            this.lblSuccess.AutoSize = true;
            this.lblSuccess.Location = new System.Drawing.Point(989, 30);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(13, 13);
            this.lblSuccess.TabIndex = 11;
            this.lblSuccess.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(894, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "SUCCESS";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(1041, 30);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(29, 31);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "0";
            // 
            // tmrCountDown
            // 
            this.tmrCountDown.Interval = 1000;
            this.tmrCountDown.Tick += new System.EventHandler(this.tmrCountDown_Tick);
            // 
            // StressLevelTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBaloon);
            this.Controls.Add(this.picBucketYello);
            this.Controls.Add(this.picBucketRed);
            this.Controls.Add(this.picBucketBlue);
            this.Name = "StressLevelTwo";
            this.Size = new System.Drawing.Size(1100, 550);
            ((System.ComponentModel.ISupportInitialize)(this.picBucketBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBucketRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBucketYello)).EndInit();
            this.pnlBaloon.ResumeLayout(false);
            this.pnlBaloon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBucketBlue;
        private System.Windows.Forms.PictureBox picBucketRed;
        private System.Windows.Forms.PictureBox picBucketYello;
        private System.Windows.Forms.Panel pnlBaloon;
        private System.Windows.Forms.Label lblFaild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSuccess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tmrCountDown;
    }
}
