namespace EtabsAddIn_Framework
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.openCsv = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.watchBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(421, 405);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 0;
            this.ok.Text = "Ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(512, 405);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // openCsv
            // 
            this.openCsv.Location = new System.Drawing.Point(600, 11);
            this.openCsv.Name = "openCsv";
            this.openCsv.Size = new System.Drawing.Size(110, 23);
            this.openCsv.TabIndex = 2;
            this.openCsv.Text = "Open CSV";
            this.openCsv.UseVisualStyleBackColor = true;
            this.openCsv.Click += new System.EventHandler(this.openCsv_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 12);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(577, 22);
            this.pathBox.TabIndex = 3;
            // 
            // watchBox
            // 
            this.watchBox.FormattingEnabled = true;
            this.watchBox.ItemHeight = 16;
            this.watchBox.Location = new System.Drawing.Point(12, 67);
            this.watchBox.Name = "watchBox";
            this.watchBox.Size = new System.Drawing.Size(577, 324);
            this.watchBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.watchBox);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.openCsv);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Name = "Form1";
            this.Text = "Revit Import";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button openCsv;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ListBox watchBox;
    }
}