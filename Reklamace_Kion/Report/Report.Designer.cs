namespace Reklamace_Kion.Report
{
    partial class Report
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelReklamation = new System.Windows.Forms.Panel();
            this.panelRepairs = new System.Windows.Forms.Panel();
            this.btnCreateExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reklamace - Vyberte data k exportu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(360, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Opravy - Vyberte data k exportu";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelReklamation
            // 
            this.panelReklamation.AutoScroll = true;
            this.panelReklamation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelReklamation.Location = new System.Drawing.Point(18, 29);
            this.panelReklamation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelReklamation.Name = "panelReklamation";
            this.panelReklamation.Size = new System.Drawing.Size(320, 477);
            this.panelReklamation.TabIndex = 1;
            // 
            // panelRepairs
            // 
            this.panelRepairs.AutoScroll = true;
            this.panelRepairs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRepairs.Location = new System.Drawing.Point(360, 29);
            this.panelRepairs.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelRepairs.Name = "panelRepairs";
            this.panelRepairs.Size = new System.Drawing.Size(320, 477);
            this.panelRepairs.TabIndex = 1;
            // 
            // btnCreateExcel
            // 
            this.btnCreateExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateExcel.Location = new System.Drawing.Point(700, 29);
            this.btnCreateExcel.Name = "btnCreateExcel";
            this.btnCreateExcel.Size = new System.Drawing.Size(135, 42);
            this.btnCreateExcel.TabIndex = 2;
            this.btnCreateExcel.Text = "Vytvořit excel";
            this.btnCreateExcel.UseVisualStyleBackColor = true;
            this.btnCreateExcel.Click += new System.EventHandler(this.btnCreateExcel_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 519);
            this.Controls.Add(this.btnCreateExcel);
            this.Controls.Add(this.panelRepairs);
            this.Controls.Add(this.panelReklamation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelReklamation;
        private System.Windows.Forms.Panel panelRepairs;
        private System.Windows.Forms.Button btnCreateExcel;
    }
}