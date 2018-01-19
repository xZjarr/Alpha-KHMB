namespace KHMB_ServerSide
{
    partial class Form1
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
            this.timer_ExecuteJobs = new System.Windows.Forms.Timer(this.components);
            this.lbl_output = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer_ExecuteJobs
            // 
            this.timer_ExecuteJobs.Enabled = true;
            this.timer_ExecuteJobs.Interval = 60000;
            this.timer_ExecuteJobs.Tick += new System.EventHandler(this.timer_ExecuteJobs_Tick);
            // 
            // lbl_output
            // 
            this.lbl_output.Location = new System.Drawing.Point(0, 19);
            this.lbl_output.Name = "lbl_output";
            this.lbl_output.Size = new System.Drawing.Size(270, 212);
            this.lbl_output.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.lbl_output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_ExecuteJobs;
        private System.Windows.Forms.Label lbl_output;
    }
}

