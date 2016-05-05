namespace Flóð
{
    partial class Flóð
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
            this.DatoLbl = new System.Windows.Forms.Label();
            this.fyrrapartLbl = new System.Windows.Forms.Label();
            this.seinnapartLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // DatoLbl
            // 
            this.DatoLbl.AutoSize = true;
            this.DatoLbl.Location = new System.Drawing.Point(95, 10);
            this.DatoLbl.Name = "DatoLbl";
            this.DatoLbl.Size = new System.Drawing.Size(33, 13);
            this.DatoLbl.TabIndex = 0;
            this.DatoLbl.Text = "Dato:";
            // 
            // fyrrapartLbl
            // 
            this.fyrrapartLbl.AutoSize = true;
            this.fyrrapartLbl.Location = new System.Drawing.Point(95, 35);
            this.fyrrapartLbl.Name = "fyrrapartLbl";
            this.fyrrapartLbl.Size = new System.Drawing.Size(54, 13);
            this.fyrrapartLbl.TabIndex = 1;
            this.fyrrapartLbl.Text = "Fyrrapart: ";
            // 
            // seinnapartLbl
            // 
            this.seinnapartLbl.AutoSize = true;
            this.seinnapartLbl.Location = new System.Drawing.Point(95, 60);
            this.seinnapartLbl.Name = "seinnapartLbl";
            this.seinnapartLbl.Size = new System.Drawing.Size(61, 13);
            this.seinnapartLbl.TabIndex = 2;
            this.seinnapartLbl.Text = "Seinnapart:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fyrra part: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seinna part:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Flóð
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 94);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seinnapartLbl);
            this.Controls.Add(this.fyrrapartLbl);
            this.Controls.Add(this.DatoLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = new System.Drawing.Point(1000, 50);
            this.Name = "Flóð";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Flóð Fuglafjørður";
            this.Load += new System.EventHandler(this.Flóð_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DatoLbl;
        private System.Windows.Forms.Label fyrrapartLbl;
        private System.Windows.Forms.Label seinnapartLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

