namespace FiveExamsAtVoenmeh
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.teacher = new System.Windows.Forms.PictureBox();
            this.teacherTimer = new System.Windows.Forms.Timer(this.components);
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.leftHandBox = new System.Windows.Forms.PictureBox();
            this.rightHandBox = new System.Windows.Forms.PictureBox();
            this.paper1 = new System.Windows.Forms.PictureBox();
            this.paper2 = new System.Windows.Forms.PictureBox();
            this.paper3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.examTimer = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.teacher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftHandBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHandBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper3)).BeginInit();
            this.SuspendLayout();
            // 
            // teacher
            // 
            this.teacher.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.Teacher;
            this.teacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.teacher.Location = new System.Drawing.Point(390, 41);
            this.teacher.Name = "teacher";
            this.teacher.Size = new System.Drawing.Size(60, 100);
            this.teacher.TabIndex = 0;
            this.teacher.TabStop = false;
            // 
            // teacherTimer
            // 
            this.teacherTimer.Interval = 1000;
            this.teacherTimer.Tick += new System.EventHandler(this.teacherTimer_Tick);
            // 
            // playerTimer
            // 
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick);
            // 
            // leftHandBox
            // 
            this.leftHandBox.BackColor = System.Drawing.Color.Transparent;
            this.leftHandBox.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.leftHand;
            this.leftHandBox.Location = new System.Drawing.Point(142, 310);
            this.leftHandBox.Name = "leftHandBox";
            this.leftHandBox.Size = new System.Drawing.Size(163, 144);
            this.leftHandBox.TabIndex = 1;
            this.leftHandBox.TabStop = false;
            // 
            // rightHandBox
            // 
            this.rightHandBox.BackColor = System.Drawing.Color.Transparent;
            this.rightHandBox.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.rightHand;
            this.rightHandBox.Location = new System.Drawing.Point(475, 310);
            this.rightHandBox.Name = "rightHandBox";
            this.rightHandBox.Size = new System.Drawing.Size(163, 144);
            this.rightHandBox.TabIndex = 2;
            this.rightHandBox.TabStop = false;
            // 
            // paper1
            // 
            this.paper1.BackColor = System.Drawing.Color.Transparent;
            this.paper1.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.paper;
            this.paper1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paper1.Location = new System.Drawing.Point(354, 337);
            this.paper1.Name = "paper1";
            this.paper1.Size = new System.Drawing.Size(30, 30);
            this.paper1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.paper1.TabIndex = 3;
            this.paper1.TabStop = false;
            // 
            // paper2
            // 
            this.paper2.BackColor = System.Drawing.Color.Transparent;
            this.paper2.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.paper;
            this.paper2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paper2.Location = new System.Drawing.Point(390, 373);
            this.paper2.Name = "paper2";
            this.paper2.Size = new System.Drawing.Size(30, 30);
            this.paper2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.paper2.TabIndex = 4;
            this.paper2.TabStop = false;
            // 
            // paper3
            // 
            this.paper3.BackColor = System.Drawing.Color.Transparent;
            this.paper3.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.paper;
            this.paper3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paper3.Location = new System.Drawing.Point(338, 408);
            this.paper3.Name = "paper3";
            this.paper3.Size = new System.Drawing.Size(30, 30);
            this.paper3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.paper3.TabIndex = 5;
            this.paper3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(34, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "До окончания экзамена осталось: 5 минут";
            // 
            // examTimer
            // 
            this.examTimer.Interval = 6000;
            this.examTimer.Tick += new System.EventHandler(this.examTimer_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(563, 65);
            this.progressBar1.MarqueeAnimationSpeed = 60;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(125, 29);
            this.progressBar1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::FiveExamsAtVoenmeh.Properties.Resources.classroom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paper3);
            this.Controls.Add(this.paper2);
            this.Controls.Add(this.paper1);
            this.Controls.Add(this.rightHandBox);
            this.Controls.Add(this.leftHandBox);
            this.Controls.Add(this.teacher);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftHandBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightHandBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paper3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox teacher;
        private System.Windows.Forms.Timer teacherTimer;
        private System.Windows.Forms.Timer playerTimer;
        private PictureBox leftHandBox;
        private PictureBox rightHandBox;
        private PictureBox paper1;
        private PictureBox paper2;
        private PictureBox paper3;
        private Label label1;
        private System.Windows.Forms.Timer examTimer;
        private ProgressBar progressBar1;
    }
}