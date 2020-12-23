namespace ProcessScheduler
{
    partial class ProcessCreator
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
            this.burstTime = new System.Windows.Forms.NumericUpDown();
            this.startTime = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.priority = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.burstTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priority)).BeginInit();
            this.SuspendLayout();
            // 
            // burstTime
            // 
            this.burstTime.Location = new System.Drawing.Point(67, 33);
            this.burstTime.Name = "burstTime";
            this.burstTime.Size = new System.Drawing.Size(41, 20);
            this.burstTime.TabIndex = 0;
            this.burstTime.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // startTime
            // 
            this.startTime.Location = new System.Drawing.Point(67, 7);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(41, 20);
            this.startTime.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // priority
            // 
            this.priority.Location = new System.Drawing.Point(67, 59);
            this.priority.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.priority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priority.Name = "priority";
            this.priority.Size = new System.Drawing.Size(41, 20);
            this.priority.TabIndex = 3;
            this.priority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Burst time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Priority:";
            // 
            // ProcessCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 88);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.priority);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.burstTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ProcessCreator";
            this.Text = "ProcessCreator";
            this.Load += new System.EventHandler(this.ProcessCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.burstTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown burstTime;
        private System.Windows.Forms.NumericUpDown startTime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown priority;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
