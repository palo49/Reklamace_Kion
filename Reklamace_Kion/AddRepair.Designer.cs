﻿namespace Reklamace_Kion
{
    partial class AddRepair
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
            this.lblBrand = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.chckWD = new System.Windows.Forms.CheckBox();
            this.chckBB = new System.Windows.Forms.CheckBox();
            this.chckZD = new System.Windows.Forms.CheckBox();
            this.chckSW = new System.Windows.Forms.CheckBox();
            this.chckPD = new System.Windows.Forms.CheckBox();
            this.chckTest = new System.Windows.Forms.CheckBox();
            this.chckCharging = new System.Windows.Forms.CheckBox();
            this.chckSetBrandId = new System.Windows.Forms.CheckBox();
            this.chckPrtscr = new System.Windows.Forms.CheckBox();
            this.chckLabel = new System.Windows.Forms.CheckBox();
            this.lblPalette = new System.Windows.Forms.Label();
            this.cmbTypeOfPalette = new System.Windows.Forms.ComboBox();
            this.dateExpExp = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSOH = new System.Windows.Forms.Label();
            this.trackBarSOH = new System.Windows.Forms.TrackBar();
            this.numSOH = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblCapacity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSOH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSOH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(14, 10);
            this.lblBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(45, 15);
            this.lblBrand.TabIndex = 0;
            this.lblBrand.Text = "Brand*";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(14, 554);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(189, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(18, 29);
            this.txtBrand.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(181, 21);
            this.txtBrand.TabIndex = 2;
            // 
            // chckWD
            // 
            this.chckWD.AutoSize = true;
            this.chckWD.Location = new System.Drawing.Point(18, 59);
            this.chckWD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckWD.Name = "chckWD";
            this.chckWD.Size = new System.Drawing.Size(46, 19);
            this.chckWD.TabIndex = 3;
            this.chckWD.Text = "WD";
            this.chckWD.UseVisualStyleBackColor = true;
            // 
            // chckBB
            // 
            this.chckBB.AutoSize = true;
            this.chckBB.Location = new System.Drawing.Point(18, 85);
            this.chckBB.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckBB.Name = "chckBB";
            this.chckBB.Size = new System.Drawing.Size(42, 19);
            this.chckBB.TabIndex = 3;
            this.chckBB.Text = "BB";
            this.chckBB.UseVisualStyleBackColor = true;
            // 
            // chckZD
            // 
            this.chckZD.AutoSize = true;
            this.chckZD.Location = new System.Drawing.Point(18, 112);
            this.chckZD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckZD.Name = "chckZD";
            this.chckZD.Size = new System.Drawing.Size(42, 19);
            this.chckZD.TabIndex = 3;
            this.chckZD.Text = "ZD";
            this.chckZD.UseVisualStyleBackColor = true;
            // 
            // chckSW
            // 
            this.chckSW.AutoSize = true;
            this.chckSW.Location = new System.Drawing.Point(18, 138);
            this.chckSW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckSW.Name = "chckSW";
            this.chckSW.Size = new System.Drawing.Size(45, 19);
            this.chckSW.TabIndex = 3;
            this.chckSW.Text = "SW";
            this.chckSW.UseVisualStyleBackColor = true;
            // 
            // chckPD
            // 
            this.chckPD.AutoSize = true;
            this.chckPD.Location = new System.Drawing.Point(18, 165);
            this.chckPD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckPD.Name = "chckPD";
            this.chckPD.Size = new System.Drawing.Size(43, 19);
            this.chckPD.TabIndex = 3;
            this.chckPD.Text = "PD";
            this.chckPD.UseVisualStyleBackColor = true;
            // 
            // chckTest
            // 
            this.chckTest.AutoSize = true;
            this.chckTest.Location = new System.Drawing.Point(99, 59);
            this.chckTest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckTest.Name = "chckTest";
            this.chckTest.Size = new System.Drawing.Size(49, 19);
            this.chckTest.TabIndex = 3;
            this.chckTest.Text = "Test";
            this.chckTest.UseVisualStyleBackColor = true;
            // 
            // chckCharging
            // 
            this.chckCharging.AutoSize = true;
            this.chckCharging.Location = new System.Drawing.Point(99, 85);
            this.chckCharging.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckCharging.Name = "chckCharging";
            this.chckCharging.Size = new System.Drawing.Size(76, 19);
            this.chckCharging.TabIndex = 3;
            this.chckCharging.Text = "Charging";
            this.chckCharging.UseVisualStyleBackColor = true;
            // 
            // chckSetBrandId
            // 
            this.chckSetBrandId.AutoSize = true;
            this.chckSetBrandId.Location = new System.Drawing.Point(99, 112);
            this.chckSetBrandId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckSetBrandId.Name = "chckSetBrandId";
            this.chckSetBrandId.Size = new System.Drawing.Size(94, 19);
            this.chckSetBrandId.TabIndex = 3;
            this.chckSetBrandId.Text = "Set brand ID";
            this.chckSetBrandId.UseVisualStyleBackColor = true;
            // 
            // chckPrtscr
            // 
            this.chckPrtscr.AutoSize = true;
            this.chckPrtscr.Location = new System.Drawing.Point(99, 138);
            this.chckPrtscr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckPrtscr.Name = "chckPrtscr";
            this.chckPrtscr.Size = new System.Drawing.Size(91, 19);
            this.chckPrtscr.TabIndex = 3;
            this.chckPrtscr.Text = "Print screen";
            this.chckPrtscr.UseVisualStyleBackColor = true;
            // 
            // chckLabel
            // 
            this.chckLabel.AutoSize = true;
            this.chckLabel.Location = new System.Drawing.Point(99, 165);
            this.chckLabel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chckLabel.Name = "chckLabel";
            this.chckLabel.Size = new System.Drawing.Size(57, 19);
            this.chckLabel.TabIndex = 3;
            this.chckLabel.Text = "Label";
            this.chckLabel.UseVisualStyleBackColor = true;
            // 
            // lblPalette
            // 
            this.lblPalette.AutoSize = true;
            this.lblPalette.Location = new System.Drawing.Point(15, 202);
            this.lblPalette.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPalette.Name = "lblPalette";
            this.lblPalette.Size = new System.Drawing.Size(86, 15);
            this.lblPalette.TabIndex = 0;
            this.lblPalette.Text = "Type of palette";
            // 
            // cmbTypeOfPalette
            // 
            this.cmbTypeOfPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeOfPalette.FormattingEnabled = true;
            this.cmbTypeOfPalette.Items.AddRange(new object[] {
            "Euro"});
            this.cmbTypeOfPalette.Location = new System.Drawing.Point(18, 220);
            this.cmbTypeOfPalette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbTypeOfPalette.Name = "cmbTypeOfPalette";
            this.cmbTypeOfPalette.Size = new System.Drawing.Size(181, 23);
            this.cmbTypeOfPalette.TabIndex = 4;
            // 
            // dateExpExp
            // 
            this.dateExpExp.CustomFormat = "";
            this.dateExpExp.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateExpExp.Location = new System.Drawing.Point(18, 264);
            this.dateExpExp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateExpExp.Name = "dateExpExp";
            this.dateExpExp.Size = new System.Drawing.Size(181, 21);
            this.dateExpExp.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 246);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Expected expedition";
            // 
            // lblSOH
            // 
            this.lblSOH.AutoSize = true;
            this.lblSOH.Location = new System.Drawing.Point(15, 298);
            this.lblSOH.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSOH.Name = "lblSOH";
            this.lblSOH.Size = new System.Drawing.Size(33, 15);
            this.lblSOH.TabIndex = 0;
            this.lblSOH.Text = "SOH";
            // 
            // trackBarSOH
            // 
            this.trackBarSOH.Location = new System.Drawing.Point(17, 316);
            this.trackBarSOH.Maximum = 100;
            this.trackBarSOH.Name = "trackBarSOH";
            this.trackBarSOH.Size = new System.Drawing.Size(147, 45);
            this.trackBarSOH.TabIndex = 6;
            this.trackBarSOH.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackBarSOH.ValueChanged += new System.EventHandler(this.trackBarSOH_ValueChanged);
            // 
            // numSOH
            // 
            this.numSOH.Location = new System.Drawing.Point(18, 349);
            this.numSOH.Name = "numSOH";
            this.numSOH.Size = new System.Drawing.Size(146, 21);
            this.numSOH.TabIndex = 7;
            this.numSOH.ValueChanged += new System.EventHandler(this.numSOH_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 351);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "%";
            // 
            // numCapacity
            // 
            this.numCapacity.DecimalPlaces = 3;
            this.numCapacity.Location = new System.Drawing.Point(18, 403);
            this.numCapacity.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(146, 21);
            this.numCapacity.TabIndex = 7;
            this.numCapacity.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 405);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "mAh";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(14, 503);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(189, 45);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(15, 385);
            this.lblCapacity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(75, 15);
            this.lblCapacity.TabIndex = 0;
            this.lblCapacity.Text = "Capacity test";
            // 
            // AddRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 613);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.numSOH);
            this.Controls.Add(this.trackBarSOH);
            this.Controls.Add(this.dateExpExp);
            this.Controls.Add(this.cmbTypeOfPalette);
            this.Controls.Add(this.chckPD);
            this.Controls.Add(this.chckSW);
            this.Controls.Add(this.chckZD);
            this.Controls.Add(this.chckBB);
            this.Controls.Add(this.chckLabel);
            this.Controls.Add(this.chckSetBrandId);
            this.Controls.Add(this.chckPrtscr);
            this.Controls.Add(this.chckCharging);
            this.Controls.Add(this.chckTest);
            this.Controls.Add(this.chckWD);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.lblSOH);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPalette);
            this.Controls.Add(this.lblBrand);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(232, 652);
            this.MinimumSize = new System.Drawing.Size(232, 652);
            this.Name = "AddRepair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddRepair";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSOH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSOH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.CheckBox chckWD;
        private System.Windows.Forms.CheckBox chckBB;
        private System.Windows.Forms.CheckBox chckZD;
        private System.Windows.Forms.CheckBox chckSW;
        private System.Windows.Forms.CheckBox chckPD;
        private System.Windows.Forms.CheckBox chckTest;
        private System.Windows.Forms.CheckBox chckCharging;
        private System.Windows.Forms.CheckBox chckSetBrandId;
        private System.Windows.Forms.CheckBox chckPrtscr;
        private System.Windows.Forms.CheckBox chckLabel;
        private System.Windows.Forms.Label lblPalette;
        private System.Windows.Forms.ComboBox cmbTypeOfPalette;
        private System.Windows.Forms.DateTimePicker dateExpExp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSOH;
        private System.Windows.Forms.TrackBar trackBarSOH;
        private System.Windows.Forms.NumericUpDown numSOH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblCapacity;
    }
}