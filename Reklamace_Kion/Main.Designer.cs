namespace Reklamace_Kion
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblLoadingData = new System.Windows.Forms.Label();
            this.dataGrid1 = new ADGV.AdvancedDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridOpravy = new ADGV.AdvancedDataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelData = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.změnitHesloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblActionInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.komponentyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatKomponentuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravitKomponentyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblActualDate = new System.Windows.Forms.Label();
            this.RefTime = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpravy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(12, 48);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(146, 16);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(12, 64);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(146, 16);
            this.lblLastName.TabIndex = 0;
            this.lblLastName.Text = "Last name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevel
            // 
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblLevel.Location = new System.Drawing.Point(12, 32);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(146, 16);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReloadData
            // 
            this.btnReloadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadData.Location = new System.Drawing.Point(12, 108);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(148, 39);
            this.btnReloadData.TabIndex = 3;
            this.btnReloadData.Text = "Obnovit";
            this.toolTip1.SetToolTip(this.btnReloadData, "Znovu načte data ze serveru.");
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(165, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 599);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblLoadingData);
            this.tabPage1.Controls.Add(this.dataGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(821, 570);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblLoadingData
            // 
            this.lblLoadingData.AutoSize = true;
            this.lblLoadingData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            this.lblLoadingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLoadingData.Location = new System.Drawing.Point(353, 258);
            this.lblLoadingData.Name = "lblLoadingData";
            this.lblLoadingData.Size = new System.Drawing.Size(129, 29);
            this.lblLoadingData.TabIndex = 1;
            this.lblLoadingData.Text = "Načítám...";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowUserToAddRows = false;
            this.dataGrid1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.dataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.AutoGenerateContextFilters = true;
            this.dataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.DateWithTime = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.MultiSelect = false;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid1.Size = new System.Drawing.Size(822, 571);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TimeFilter = false;
            this.dataGrid1.SortStringChanged += new System.EventHandler(this.dataGrid1_SortStringChanged);
            this.dataGrid1.FilterStringChanged += new System.EventHandler(this.dataGrid1_FilterStringChanged);
            this.dataGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellDoubleClick);
            this.dataGrid1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridOpravy);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(821, 570);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridOpravy
            // 
            this.dataGridOpravy.AllowUserToAddRows = false;
            this.dataGridOpravy.AllowUserToDeleteRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.dataGridOpravy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridOpravy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOpravy.AutoGenerateContextFilters = true;
            this.dataGridOpravy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOpravy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            this.dataGridOpravy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOpravy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridOpravy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOpravy.DateWithTime = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridOpravy.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridOpravy.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridOpravy.Location = new System.Drawing.Point(0, 0);
            this.dataGridOpravy.MultiSelect = false;
            this.dataGridOpravy.Name = "dataGridOpravy";
            this.dataGridOpravy.ReadOnly = true;
            this.dataGridOpravy.RowHeadersVisible = false;
            this.dataGridOpravy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOpravy.Size = new System.Drawing.Size(821, 570);
            this.dataGridOpravy.TabIndex = 0;
            this.dataGridOpravy.TimeFilter = false;
            this.dataGridOpravy.SortStringChanged += new System.EventHandler(this.dataGridOpravy_SortStringChanged);
            this.dataGridOpravy.FilterStringChanged += new System.EventHandler(this.dataGridOpravy_FilterStringChanged);
            this.dataGridOpravy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOpravy_CellDoubleClick);
            this.dataGridOpravy.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOpravy_CellValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddData
            // 
            this.btnAddData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddData.Location = new System.Drawing.Point(12, 195);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(148, 39);
            this.btnAddData.TabIndex = 3;
            this.btnAddData.Text = "Přidat";
            this.toolTip1.SetToolTip(this.btnAddData, "Přídá data na server.");
            this.btnAddData.UseVisualStyleBackColor = true;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.Location = new System.Drawing.Point(12, 548);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(148, 39);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Uživatelé";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Visible = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Location = new System.Drawing.Point(12, 593);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(148, 39);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Konec";
            this.toolTip1.SetToolTip(this.btnExit, "Ukonči aplikaci.");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelData
            // 
            this.btnDelData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelData.Location = new System.Drawing.Point(12, 240);
            this.btnDelData.Name = "btnDelData";
            this.btnDelData.Size = new System.Drawing.Size(148, 39);
            this.btnDelData.TabIndex = 3;
            this.btnDelData.Text = "Smazat";
            this.toolTip1.SetToolTip(this.btnDelData, "Smaže vybrané data ze serveru.");
            this.btnDelData.UseVisualStyleBackColor = true;
            this.btnDelData.Click += new System.EventHandler(this.btnDelData_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.Location = new System.Drawing.Point(12, 153);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(148, 36);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.toolTip1.SetToolTip(this.btnExport, "Exportuje právě aktivní tabulku do excelu.");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.oAplikaciToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.změnitHesloToolStripMenuItem,
            this.komponentyToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.SettingsToolStripMenuItem.Text = "Nastavení";
            // 
            // změnitHesloToolStripMenuItem
            // 
            this.změnitHesloToolStripMenuItem.Name = "změnitHesloToolStripMenuItem";
            this.změnitHesloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.změnitHesloToolStripMenuItem.Text = "Změnit heslo";
            this.změnitHesloToolStripMenuItem.Click += new System.EventHandler(this.změnitHesloToolStripMenuItem_Click);
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.oAplikaciToolStripMenuItem.Text = "O aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.oAplikaciToolStripMenuItem_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Info";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1005, 2);
            this.label1.TabIndex = 8;
            // 
            // lblActionInfo
            // 
            this.lblActionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblActionInfo.AutoSize = true;
            this.lblActionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.lblActionInfo.Location = new System.Drawing.Point(167, 19);
            this.lblActionInfo.Name = "lblActionInfo";
            this.lblActionInfo.Size = new System.Drawing.Size(79, 16);
            this.lblActionInfo.TabIndex = 9;
            this.lblActionInfo.Text = "lblActionInfo";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 636);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1005, 2);
            this.label2.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.panel1.Controls.Add(this.lblActualDate);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblActionInfo);
            this.panel1.Location = new System.Drawing.Point(0, 636);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 61);
            this.panel1.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // komponentyToolStripMenuItem
            // 
            this.komponentyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatKomponentuToolStripMenuItem,
            this.upravitKomponentyToolStripMenuItem});
            this.komponentyToolStripMenuItem.Name = "komponentyToolStripMenuItem";
            this.komponentyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.komponentyToolStripMenuItem.Text = "Komponenty";
            // 
            // přidatKomponentuToolStripMenuItem
            // 
            this.přidatKomponentuToolStripMenuItem.Name = "přidatKomponentuToolStripMenuItem";
            this.přidatKomponentuToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.přidatKomponentuToolStripMenuItem.Text = "Přidat komponentu";
            this.přidatKomponentuToolStripMenuItem.Click += new System.EventHandler(this.přidatKomponentuToolStripMenuItem_Click);
            // 
            // upravitKomponentyToolStripMenuItem
            // 
            this.upravitKomponentyToolStripMenuItem.Name = "upravitKomponentyToolStripMenuItem";
            this.upravitKomponentyToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.upravitKomponentyToolStripMenuItem.Text = "Upravit komponenty";
            this.upravitKomponentyToolStripMenuItem.Click += new System.EventHandler(this.upravitKomponentyToolStripMenuItem_Click);
            // 
            // lblActualDate
            // 
            this.lblActualDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualDate.AutoSize = true;
            this.lblActualDate.Location = new System.Drawing.Point(854, 19);
            this.lblActualDate.Name = "lblActualDate";
            this.lblActualDate.Size = new System.Drawing.Size(38, 16);
            this.lblActualDate.TabIndex = 10;
            this.lblActualDate.Text = "Time";
            // 
            // RefTime
            // 
            this.RefTime.Enabled = true;
            this.RefTime.Interval = 1000;
            this.RefTime.Tick += new System.EventHandler(this.RefTime_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 689);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelData);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnAddData);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1024, 728);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reklamace Kion - Hlavní okno";
            this.Load += new System.EventHandler(this.Main_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpravy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddData;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelData;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem změnitHesloToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private ADGV.AdvancedDataGridView dataGrid1;
        private System.Windows.Forms.TabPage tabPage2;
        private ADGV.AdvancedDataGridView dataGridOpravy;
        private System.Windows.Forms.Label lblActionInfo;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblLoadingData;
        private System.Windows.Forms.ToolStripMenuItem komponentyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidatKomponentuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravitKomponentyToolStripMenuItem;
        private System.Windows.Forms.Label lblActualDate;
        private System.Windows.Forms.Timer RefTime;
    }
}