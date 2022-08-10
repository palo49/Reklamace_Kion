namespace Reklamace_Kion
{
    partial class AddData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddData));
            this.lblClm = new System.Windows.Forms.Label();
            this.txtCLM = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.lblCustomerReq = new System.Windows.Forms.Label();
            this.txtCustomerRequest = new System.Windows.Forms.TextBox();
            this.lblDateOfCustomerSend = new System.Windows.Forms.Label();
            this.DateOfCustomerSend = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfSaftAcceptance = new System.Windows.Forms.Label();
            this.DateOfSaftAcceptance = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfRepair = new System.Windows.Forms.Label();
            this.DateOfRepair = new System.Windows.Forms.DateTimePicker();
            this.lblDateOfSaftSend = new System.Windows.Forms.Label();
            this.DateOfSaftSend = new System.Windows.Forms.DateTimePicker();
            this.lblFault = new System.Windows.Forms.Label();
            this.txtFault = new System.Windows.Forms.TextBox();
            this.lblCW = new System.Windows.Forms.Label();
            this.lblDefectBMS = new System.Windows.Forms.Label();
            this.lblLocationOfBattery = new System.Windows.Forms.Label();
            this.txtLocationOfBattery = new System.Windows.Forms.TextBox();
            this.lblClaimedComponent = new System.Windows.Forms.Label();
            this.cmbClaimedComponent = new System.Windows.Forms.ComboBox();
            this.lblReplacementSend = new System.Windows.Forms.Label();
            this.cmbReplacementSend = new System.Windows.Forms.ComboBox();
            this.lblDateOfReplacementSend = new System.Windows.Forms.Label();
            this.DateOfReplacementSend = new System.Windows.Forms.DateTimePicker();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbResult = new System.Windows.Forms.ComboBox();
            this.lblResultDescription = new System.Windows.Forms.Label();
            this.txtResultDescription = new System.Windows.Forms.TextBox();
            this.lblCostOfRepair = new System.Windows.Forms.Label();
            this.txtCostOfRepair = new System.Windows.Forms.TextBox();
            this.cmbCW = new System.Windows.Forms.ComboBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbDefects = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPNBattery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSNBattery = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPNComponent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSNComponent = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClm
            // 
            this.lblClm.AutoSize = true;
            this.lblClm.Location = new System.Drawing.Point(14, 10);
            this.lblClm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClm.Name = "lblClm";
            this.lblClm.Size = new System.Drawing.Size(38, 15);
            this.lblClm.TabIndex = 0;
            this.lblClm.Text = "CLM*";
            // 
            // txtCLM
            // 
            this.txtCLM.Location = new System.Drawing.Point(18, 29);
            this.txtCLM.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCLM.Name = "txtCLM";
            this.txtCLM.Size = new System.Drawing.Size(138, 21);
            this.txtCLM.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(13, 61);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(46, 15);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "Status*";
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "Open",
            "Closed"});
            this.cmbState.Location = new System.Drawing.Point(18, 79);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(138, 23);
            this.cmbState.TabIndex = 2;
            // 
            // lblCustomerReq
            // 
            this.lblCustomerReq.AutoSize = true;
            this.lblCustomerReq.Location = new System.Drawing.Point(489, 61);
            this.lblCustomerReq.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCustomerReq.Name = "lblCustomerReq";
            this.lblCustomerReq.Size = new System.Drawing.Size(142, 15);
            this.lblCustomerReq.TabIndex = 0;
            this.lblCustomerReq.Text = "Požadavek od zákazníka";
            // 
            // txtCustomerRequest
            // 
            this.txtCustomerRequest.Location = new System.Drawing.Point(492, 79);
            this.txtCustomerRequest.Multiline = true;
            this.txtCustomerRequest.Name = "txtCustomerRequest";
            this.txtCustomerRequest.Size = new System.Drawing.Size(311, 73);
            this.txtCustomerRequest.TabIndex = 3;
            this.toolTip1.SetToolTip(this.txtCustomerRequest, "Pište bez použití klávesy Enter.\r\nPokud budete používat Enter, text se při zápisu" +
        " do databáze spojí.\r\nNapř. \r\nŘádek 1\r\nŘádek 2\r\n\r\nse spojí takto: Řádek 1Řádek2\r\n" +
        "");
            // 
            // lblDateOfCustomerSend
            // 
            this.lblDateOfCustomerSend.AutoSize = true;
            this.lblDateOfCustomerSend.Location = new System.Drawing.Point(15, 121);
            this.lblDateOfCustomerSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfCustomerSend.Name = "lblDateOfCustomerSend";
            this.lblDateOfCustomerSend.Size = new System.Drawing.Size(131, 15);
            this.lblDateOfCustomerSend.TabIndex = 0;
            this.lblDateOfCustomerSend.Text = "Odeslání od zákazníka";
            // 
            // DateOfCustomerSend
            // 
            this.DateOfCustomerSend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfCustomerSend.Location = new System.Drawing.Point(18, 139);
            this.DateOfCustomerSend.Name = "DateOfCustomerSend";
            this.DateOfCustomerSend.Size = new System.Drawing.Size(138, 21);
            this.DateOfCustomerSend.TabIndex = 4;
            // 
            // lblDateOfSaftAcceptance
            // 
            this.lblDateOfSaftAcceptance.AutoSize = true;
            this.lblDateOfSaftAcceptance.Location = new System.Drawing.Point(15, 172);
            this.lblDateOfSaftAcceptance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfSaftAcceptance.Name = "lblDateOfSaftAcceptance";
            this.lblDateOfSaftAcceptance.Size = new System.Drawing.Size(109, 15);
            this.lblDateOfSaftAcceptance.TabIndex = 0;
            this.lblDateOfSaftAcceptance.Text = "Datum přijetí SAFT";
            // 
            // DateOfSaftAcceptance
            // 
            this.DateOfSaftAcceptance.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfSaftAcceptance.Location = new System.Drawing.Point(18, 190);
            this.DateOfSaftAcceptance.Name = "DateOfSaftAcceptance";
            this.DateOfSaftAcceptance.Size = new System.Drawing.Size(138, 21);
            this.DateOfSaftAcceptance.TabIndex = 5;
            // 
            // lblDateOfRepair
            // 
            this.lblDateOfRepair.AutoSize = true;
            this.lblDateOfRepair.Location = new System.Drawing.Point(15, 224);
            this.lblDateOfRepair.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfRepair.Name = "lblDateOfRepair";
            this.lblDateOfRepair.Size = new System.Drawing.Size(82, 15);
            this.lblDateOfRepair.TabIndex = 0;
            this.lblDateOfRepair.Text = "Datum opravy";
            // 
            // DateOfRepair
            // 
            this.DateOfRepair.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfRepair.Location = new System.Drawing.Point(18, 242);
            this.DateOfRepair.Name = "DateOfRepair";
            this.DateOfRepair.Size = new System.Drawing.Size(138, 21);
            this.DateOfRepair.TabIndex = 6;
            // 
            // lblDateOfSaftSend
            // 
            this.lblDateOfSaftSend.AutoSize = true;
            this.lblDateOfSaftSend.Location = new System.Drawing.Point(15, 276);
            this.lblDateOfSaftSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfSaftSend.Name = "lblDateOfSaftSend";
            this.lblDateOfSaftSend.Size = new System.Drawing.Size(142, 15);
            this.lblDateOfSaftSend.TabIndex = 0;
            this.lblDateOfSaftSend.Text = "Datum odeslání ze SAFT";
            // 
            // DateOfSaftSend
            // 
            this.DateOfSaftSend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfSaftSend.Location = new System.Drawing.Point(18, 294);
            this.DateOfSaftSend.Name = "DateOfSaftSend";
            this.DateOfSaftSend.Size = new System.Drawing.Size(138, 21);
            this.DateOfSaftSend.TabIndex = 7;
            // 
            // lblFault
            // 
            this.lblFault.AutoSize = true;
            this.lblFault.Location = new System.Drawing.Point(188, 276);
            this.lblFault.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFault.Name = "lblFault";
            this.lblFault.Size = new System.Drawing.Size(47, 15);
            this.lblFault.TabIndex = 0;
            this.lblFault.Text = "Závada";
            // 
            // txtFault
            // 
            this.txtFault.Location = new System.Drawing.Point(191, 294);
            this.txtFault.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFault.Multiline = true;
            this.txtFault.Name = "txtFault";
            this.txtFault.Size = new System.Drawing.Size(267, 73);
            this.txtFault.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtFault, "Pište bez použití klávesy Enter.\r\nPokud budete používat Enter, text se při zápisu" +
        " do databáze spojí.\r\nNapř. \r\nŘádek 1\r\nŘádek 2\r\n\r\nse spojí takto: Řádek 1Řádek2");
            // 
            // lblCW
            // 
            this.lblCW.AutoSize = true;
            this.lblCW.Location = new System.Drawing.Point(188, 380);
            this.lblCW.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCW.Name = "lblCW";
            this.lblCW.Size = new System.Drawing.Size(35, 15);
            this.lblCW.TabIndex = 0;
            this.lblCW.Text = "C / W";
            // 
            // lblDefectBMS
            // 
            this.lblDefectBMS.AutoSize = true;
            this.lblDefectBMS.Location = new System.Drawing.Point(188, 432);
            this.lblDefectBMS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefectBMS.Name = "lblDefectBMS";
            this.lblDefectBMS.Size = new System.Drawing.Size(72, 15);
            this.lblDefectBMS.TabIndex = 0;
            this.lblDefectBMS.Text = "Defekt BMS";
            // 
            // lblLocationOfBattery
            // 
            this.lblLocationOfBattery.AutoSize = true;
            this.lblLocationOfBattery.Location = new System.Drawing.Point(489, 9);
            this.lblLocationOfBattery.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocationOfBattery.Name = "lblLocationOfBattery";
            this.lblLocationOfBattery.Size = new System.Drawing.Size(84, 15);
            this.lblLocationOfBattery.TabIndex = 0;
            this.lblLocationOfBattery.Text = "Lokace baterií";
            // 
            // txtLocationOfBattery
            // 
            this.txtLocationOfBattery.Location = new System.Drawing.Point(492, 27);
            this.txtLocationOfBattery.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtLocationOfBattery.Name = "txtLocationOfBattery";
            this.txtLocationOfBattery.Size = new System.Drawing.Size(267, 21);
            this.txtLocationOfBattery.TabIndex = 14;
            // 
            // lblClaimedComponent
            // 
            this.lblClaimedComponent.AutoSize = true;
            this.lblClaimedComponent.Location = new System.Drawing.Point(188, 172);
            this.lblClaimedComponent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClaimedComponent.Name = "lblClaimedComponent";
            this.lblClaimedComponent.Size = new System.Drawing.Size(78, 15);
            this.lblClaimedComponent.TabIndex = 0;
            this.lblClaimedComponent.Text = "Komponenta";
            // 
            // cmbClaimedComponent
            // 
            this.cmbClaimedComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClaimedComponent.FormattingEnabled = true;
            this.cmbClaimedComponent.Location = new System.Drawing.Point(191, 190);
            this.cmbClaimedComponent.Name = "cmbClaimedComponent";
            this.cmbClaimedComponent.Size = new System.Drawing.Size(267, 23);
            this.cmbClaimedComponent.TabIndex = 8;
            // 
            // lblReplacementSend
            // 
            this.lblReplacementSend.AutoSize = true;
            this.lblReplacementSend.Location = new System.Drawing.Point(14, 328);
            this.lblReplacementSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReplacementSend.Name = "lblReplacementSend";
            this.lblReplacementSend.Size = new System.Drawing.Size(109, 15);
            this.lblReplacementSend.TabIndex = 0;
            this.lblReplacementSend.Text = "Náhrada odeslána";
            // 
            // cmbReplacementSend
            // 
            this.cmbReplacementSend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReplacementSend.FormattingEnabled = true;
            this.cmbReplacementSend.Items.AddRange(new object[] {
            "Ano",
            "Ne"});
            this.cmbReplacementSend.Location = new System.Drawing.Point(16, 344);
            this.cmbReplacementSend.Name = "cmbReplacementSend";
            this.cmbReplacementSend.Size = new System.Drawing.Size(138, 23);
            this.cmbReplacementSend.TabIndex = 15;
            // 
            // lblDateOfReplacementSend
            // 
            this.lblDateOfReplacementSend.AutoSize = true;
            this.lblDateOfReplacementSend.Location = new System.Drawing.Point(15, 381);
            this.lblDateOfReplacementSend.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateOfReplacementSend.Name = "lblDateOfReplacementSend";
            this.lblDateOfReplacementSend.Size = new System.Drawing.Size(141, 15);
            this.lblDateOfReplacementSend.TabIndex = 0;
            this.lblDateOfReplacementSend.Text = "Datum odeslání náhrady";
            // 
            // DateOfReplacementSend
            // 
            this.DateOfReplacementSend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfReplacementSend.Location = new System.Drawing.Point(17, 399);
            this.DateOfReplacementSend.Name = "DateOfReplacementSend";
            this.DateOfReplacementSend.Size = new System.Drawing.Size(138, 21);
            this.DateOfReplacementSend.TabIndex = 16;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(489, 171);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(55, 15);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Výsledek";
            // 
            // cmbResult
            // 
            this.cmbResult.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResult.FormattingEnabled = true;
            this.cmbResult.Items.AddRange(new object[] {
            "Opraveno",
            "Neopraveno"});
            this.cmbResult.Location = new System.Drawing.Point(492, 189);
            this.cmbResult.Name = "cmbResult";
            this.cmbResult.Size = new System.Drawing.Size(311, 23);
            this.cmbResult.TabIndex = 17;
            // 
            // lblResultDescription
            // 
            this.lblResultDescription.AutoSize = true;
            this.lblResultDescription.Location = new System.Drawing.Point(489, 222);
            this.lblResultDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultDescription.Name = "lblResultDescription";
            this.lblResultDescription.Size = new System.Drawing.Size(87, 15);
            this.lblResultDescription.TabIndex = 0;
            this.lblResultDescription.Text = "Popis výsledku";
            // 
            // txtResultDescription
            // 
            this.txtResultDescription.Location = new System.Drawing.Point(492, 240);
            this.txtResultDescription.Multiline = true;
            this.txtResultDescription.Name = "txtResultDescription";
            this.txtResultDescription.Size = new System.Drawing.Size(311, 72);
            this.txtResultDescription.TabIndex = 18;
            this.toolTip1.SetToolTip(this.txtResultDescription, "Pište bez použití klávesy Enter.\r\nPokud budete používat Enter, text se při zápisu" +
        " do databáze spojí.\r\nNapř. \r\nŘádek 1\r\nŘádek 2\r\n\r\nse spojí takto: Řádek 1Řádek2\r\n" +
        "");
            // 
            // lblCostOfRepair
            // 
            this.lblCostOfRepair.AutoSize = true;
            this.lblCostOfRepair.Location = new System.Drawing.Point(489, 326);
            this.lblCostOfRepair.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostOfRepair.Name = "lblCostOfRepair";
            this.lblCostOfRepair.Size = new System.Drawing.Size(74, 15);
            this.lblCostOfRepair.TabIndex = 0;
            this.lblCostOfRepair.Text = "Cena opravy";
            // 
            // txtCostOfRepair
            // 
            this.txtCostOfRepair.Location = new System.Drawing.Point(492, 342);
            this.txtCostOfRepair.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCostOfRepair.Name = "txtCostOfRepair";
            this.txtCostOfRepair.Size = new System.Drawing.Size(311, 21);
            this.txtCostOfRepair.TabIndex = 19;
            this.txtCostOfRepair.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostOfRepair_KeyPress);
            // 
            // cmbCW
            // 
            this.cmbCW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCW.FormattingEnabled = true;
            this.cmbCW.Items.AddRange(new object[] {
            "C",
            "W"});
            this.cmbCW.Location = new System.Drawing.Point(191, 396);
            this.cmbCW.Name = "cmbCW";
            this.cmbCW.Size = new System.Drawing.Size(267, 23);
            this.cmbCW.TabIndex = 12;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(489, 378);
            this.lblContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(106, 15);
            this.lblContact.TabIndex = 0;
            this.lblContact.Text = "Kontakt zákazníka";
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(492, 396);
            this.txtContact.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(311, 21);
            this.txtContact.TabIndex = 20;
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(9, 477);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 43);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(692, 477);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 43);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Uložit";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 10;
            this.toolTip1.AutoPopDelay = 0;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 2;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Doporučení";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-7, 526);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 54);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(834, 2);
            this.label1.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(31, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(77, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cmbDefects
            // 
            this.cmbDefects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefects.FormattingEnabled = true;
            this.cmbDefects.Location = new System.Drawing.Point(191, 448);
            this.cmbDefects.Name = "cmbDefects";
            this.cmbDefects.Size = new System.Drawing.Size(267, 23);
            this.cmbDefects.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 25;
            this.label2.Text = "PN baterie";
            // 
            // txtPNBattery
            // 
            this.txtPNBattery.Location = new System.Drawing.Point(188, 28);
            this.txtPNBattery.Name = "txtPNBattery";
            this.txtPNBattery.Size = new System.Drawing.Size(267, 21);
            this.txtPNBattery.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "S/N baterie";
            // 
            // txtSNBattery
            // 
            this.txtSNBattery.Location = new System.Drawing.Point(188, 79);
            this.txtSNBattery.Name = "txtSNBattery";
            this.txtSNBattery.Size = new System.Drawing.Size(267, 21);
            this.txtSNBattery.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(188, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "PN komponenty*";
            // 
            // txtPNComponent
            // 
            this.txtPNComponent.Location = new System.Drawing.Point(188, 139);
            this.txtPNComponent.Name = "txtPNComponent";
            this.txtPNComponent.Size = new System.Drawing.Size(267, 21);
            this.txtPNComponent.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "S/N Komponenty*";
            // 
            // txtSNComponent
            // 
            this.txtSNComponent.Location = new System.Drawing.Point(188, 242);
            this.txtSNComponent.Name = "txtSNComponent";
            this.txtSNComponent.Size = new System.Drawing.Size(267, 21);
            this.txtSNComponent.TabIndex = 26;
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 573);
            this.ControlBox = false;
            this.Controls.Add(this.txtPNComponent);
            this.Controls.Add(this.txtSNComponent);
            this.Controls.Add(this.txtSNBattery);
            this.Controls.Add(this.txtPNBattery);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDefects);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.DateOfSaftSend);
            this.Controls.Add(this.DateOfRepair);
            this.Controls.Add(this.DateOfSaftAcceptance);
            this.Controls.Add(this.DateOfReplacementSend);
            this.Controls.Add(this.DateOfCustomerSend);
            this.Controls.Add(this.txtResultDescription);
            this.Controls.Add(this.txtCustomerRequest);
            this.Controls.Add(this.cmbResult);
            this.Controls.Add(this.cmbReplacementSend);
            this.Controls.Add(this.cmbCW);
            this.Controls.Add(this.cmbClaimedComponent);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.txtLocationOfBattery);
            this.Controls.Add(this.txtContact);
            this.Controls.Add(this.txtCostOfRepair);
            this.Controls.Add(this.txtFault);
            this.Controls.Add(this.txtCLM);
            this.Controls.Add(this.lblDateOfSaftSend);
            this.Controls.Add(this.lblDateOfRepair);
            this.Controls.Add(this.lblDateOfSaftAcceptance);
            this.Controls.Add(this.lblDateOfReplacementSend);
            this.Controls.Add(this.lblDateOfCustomerSend);
            this.Controls.Add(this.lblResultDescription);
            this.Controls.Add(this.lblCustomerReq);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblReplacementSend);
            this.Controls.Add(this.lblClaimedComponent);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.lblLocationOfBattery);
            this.Controls.Add(this.lblDefectBMS);
            this.Controls.Add(this.lblContact);
            this.Controls.Add(this.lblCostOfRepair);
            this.Controls.Add(this.lblCW);
            this.Controls.Add(this.lblFault);
            this.Controls.Add(this.lblClm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 612);
            this.MinimumSize = new System.Drawing.Size(834, 612);
            this.Name = "AddData";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Přidej data";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AddData_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClm;
        private System.Windows.Forms.TextBox txtCLM;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.Label lblCustomerReq;
        private System.Windows.Forms.TextBox txtCustomerRequest;
        private System.Windows.Forms.Label lblDateOfCustomerSend;
        private System.Windows.Forms.DateTimePicker DateOfCustomerSend;
        private System.Windows.Forms.Label lblDateOfSaftAcceptance;
        private System.Windows.Forms.DateTimePicker DateOfSaftAcceptance;
        private System.Windows.Forms.Label lblDateOfRepair;
        private System.Windows.Forms.DateTimePicker DateOfRepair;
        private System.Windows.Forms.Label lblDateOfSaftSend;
        private System.Windows.Forms.DateTimePicker DateOfSaftSend;
        private System.Windows.Forms.Label lblFault;
        private System.Windows.Forms.TextBox txtFault;
        private System.Windows.Forms.Label lblCW;
        private System.Windows.Forms.Label lblDefectBMS;
        private System.Windows.Forms.Label lblLocationOfBattery;
        private System.Windows.Forms.TextBox txtLocationOfBattery;
        private System.Windows.Forms.Label lblClaimedComponent;
        private System.Windows.Forms.ComboBox cmbClaimedComponent;
        private System.Windows.Forms.Label lblReplacementSend;
        private System.Windows.Forms.ComboBox cmbReplacementSend;
        private System.Windows.Forms.Label lblDateOfReplacementSend;
        private System.Windows.Forms.DateTimePicker DateOfReplacementSend;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbResult;
        private System.Windows.Forms.Label lblResultDescription;
        private System.Windows.Forms.TextBox txtResultDescription;
        private System.Windows.Forms.Label lblCostOfRepair;
        private System.Windows.Forms.TextBox txtCostOfRepair;
        private System.Windows.Forms.ComboBox cmbCW;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.TextBox txtContact;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDefects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPNBattery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSNBattery;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPNComponent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSNComponent;
    }
}