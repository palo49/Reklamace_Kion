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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblLoadingData = new System.Windows.Forms.Label();
            this.dataGrid1 = new ADGV.AdvancedDataGridView();
            this.CellContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridOpravy = new ADGV.AdvancedDataGridView();
            this.cellContextRepairs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.změnitHesloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.komponentyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatKomponentuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravitKomponentyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defektyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatDefektToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravitDefektyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblActionInfo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblActualDate = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.RefTime = new System.Windows.Forms.Timer(this.components);
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.opravyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatSoučástToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upravitSoučástiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kontaktyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přidatKontaktToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnResetFiltr = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.přidatKOpravámToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.StripMenuOpenDataRepairs = new System.Windows.Forms.ToolStripMenuItem();
            this.stripMenuOpenFolderRepairs = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelData = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnAddData = new System.Windows.Forms.Button();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.upravitKontaktyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.CellContext.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpravy)).BeginInit();
            this.cellContextRepairs.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(157)))), ((int)(((byte)(143)))));
            this.lblLevel.Location = new System.Drawing.Point(12, 32);
            this.lblLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(146, 16);
            this.lblLevel.TabIndex = 0;
            this.lblLevel.Text = "Level";
            this.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(165, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 543);
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
            this.tabPage1.Size = new System.Drawing.Size(821, 514);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.dataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.AutoGenerateContextFilters = true;
            this.dataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            this.dataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid1.ContextMenuStrip = this.CellContext;
            this.dataGrid1.DateWithTime = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGrid1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGrid1.Location = new System.Drawing.Point(0, 0);
            this.dataGrid1.MultiSelect = false;
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(163)))), ((int)(((byte)(115)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid1.Size = new System.Drawing.Size(822, 503);
            this.dataGrid1.TabIndex = 0;
            this.dataGrid1.TimeFilter = false;
            this.dataGrid1.SortStringChanged += new System.EventHandler(this.dataGrid1_SortStringChanged);
            this.dataGrid1.FilterStringChanged += new System.EventHandler(this.dataGrid1_FilterStringChanged);
            this.dataGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellDoubleClick);
            this.dataGrid1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid1_CellValueChanged);
            this.dataGrid1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid1_MouseDown);
            // 
            // CellContext
            // 
            this.CellContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatKOpravámToolStripMenuItem,
            this.toolStripShowFolder});
            this.CellContext.Name = "contextMenuStrip1";
            this.CellContext.Size = new System.Drawing.Size(165, 48);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridOpravy);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(821, 514);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridOpravy
            // 
            this.dataGridOpravy.AllowUserToAddRows = false;
            this.dataGridOpravy.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.dataGridOpravy.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridOpravy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridOpravy.AutoGenerateContextFilters = true;
            this.dataGridOpravy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridOpravy.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            this.dataGridOpravy.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridOpravy.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridOpravy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOpravy.ContextMenuStrip = this.cellContextRepairs;
            this.dataGridOpravy.DateWithTime = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(213)))), ((int)(((byte)(174)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridOpravy.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridOpravy.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridOpravy.Location = new System.Drawing.Point(0, 0);
            this.dataGridOpravy.MultiSelect = false;
            this.dataGridOpravy.Name = "dataGridOpravy";
            this.dataGridOpravy.ReadOnly = true;
            this.dataGridOpravy.RowHeadersVisible = false;
            this.dataGridOpravy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridOpravy.Size = new System.Drawing.Size(821, 514);
            this.dataGridOpravy.TabIndex = 0;
            this.dataGridOpravy.TimeFilter = false;
            this.dataGridOpravy.SortStringChanged += new System.EventHandler(this.dataGridOpravy_SortStringChanged);
            this.dataGridOpravy.FilterStringChanged += new System.EventHandler(this.dataGridOpravy_FilterStringChanged);
            this.dataGridOpravy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOpravy_CellDoubleClick);
            this.dataGridOpravy.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOpravy_CellValueChanged);
            this.dataGridOpravy.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridOpravy_MouseDown);
            // 
            // cellContextRepairs
            // 
            this.cellContextRepairs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuOpenDataRepairs,
            this.stripMenuOpenFolderRepairs});
            this.cellContextRepairs.Name = "contextMenuStrip1";
            this.cellContextRepairs.Size = new System.Drawing.Size(147, 48);
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
            this.komponentyToolStripMenuItem,
            this.defektyToolStripMenuItem,
            this.opravyToolStripMenuItem,
            this.kontaktyToolStripMenuItem});
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
            // defektyToolStripMenuItem
            // 
            this.defektyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatDefektToolStripMenuItem,
            this.upravitDefektyToolStripMenuItem});
            this.defektyToolStripMenuItem.Name = "defektyToolStripMenuItem";
            this.defektyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.defektyToolStripMenuItem.Text = "Defekty";
            // 
            // přidatDefektToolStripMenuItem
            // 
            this.přidatDefektToolStripMenuItem.Name = "přidatDefektToolStripMenuItem";
            this.přidatDefektToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.přidatDefektToolStripMenuItem.Text = "Přidat defekt";
            this.přidatDefektToolStripMenuItem.Click += new System.EventHandler(this.přidatDefektToolStripMenuItem_Click);
            // 
            // upravitDefektyToolStripMenuItem
            // 
            this.upravitDefektyToolStripMenuItem.Name = "upravitDefektyToolStripMenuItem";
            this.upravitDefektyToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.upravitDefektyToolStripMenuItem.Text = "Upravit defekty";
            this.upravitDefektyToolStripMenuItem.Click += new System.EventHandler(this.upravitDefektyToolStripMenuItem_Click);
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
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // RefTime
            // 
            this.RefTime.Enabled = true;
            this.RefTime.Interval = 1000;
            this.RefTime.Tick += new System.EventHandler(this.RefTime_Tick);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(165, 32);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(60, 16);
            this.lblSearch.TabIndex = 12;
            this.lblSearch.Text = "Vyhledat";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(165, 51);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(625, 22);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            // 
            // opravyToolStripMenuItem
            // 
            this.opravyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatSoučástToolStripMenuItem,
            this.upravitSoučástiToolStripMenuItem});
            this.opravyToolStripMenuItem.Name = "opravyToolStripMenuItem";
            this.opravyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opravyToolStripMenuItem.Text = "Opravy";
            // 
            // přidatSoučástToolStripMenuItem
            // 
            this.přidatSoučástToolStripMenuItem.Name = "přidatSoučástToolStripMenuItem";
            this.přidatSoučástToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.přidatSoučástToolStripMenuItem.Text = "Přidat součást";
            this.přidatSoučástToolStripMenuItem.Click += new System.EventHandler(this.přidatSoučástToolStripMenuItem_Click);
            // 
            // upravitSoučástiToolStripMenuItem
            // 
            this.upravitSoučástiToolStripMenuItem.Name = "upravitSoučástiToolStripMenuItem";
            this.upravitSoučástiToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.upravitSoučástiToolStripMenuItem.Text = "Upravit součásti";
            this.upravitSoučástiToolStripMenuItem.Click += new System.EventHandler(this.upravitSoučástiToolStripMenuItem_Click);
            // 
            // kontaktyToolStripMenuItem
            // 
            this.kontaktyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatKontaktToolStripMenuItem,
            this.upravitKontaktyToolStripMenuItem});
            this.kontaktyToolStripMenuItem.Name = "kontaktyToolStripMenuItem";
            this.kontaktyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.kontaktyToolStripMenuItem.Text = "Kontakty";
            // 
            // přidatKontaktToolStripMenuItem
            // 
            this.přidatKontaktToolStripMenuItem.Name = "přidatKontaktToolStripMenuItem";
            this.přidatKontaktToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.přidatKontaktToolStripMenuItem.Text = "Přidat kontakt";
            this.přidatKontaktToolStripMenuItem.Click += new System.EventHandler(this.přidatKontaktToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(796, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 39);
            this.btnSearch.TabIndex = 15;
            this.btnSearch.Text = "Hledat";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnResetFiltr
            // 
            this.btnResetFiltr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFiltr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnResetFiltr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetFiltr.FlatAppearance.BorderSize = 0;
            this.btnResetFiltr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnResetFiltr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetFiltr.Image = ((System.Drawing.Image)(resources.GetObject("btnResetFiltr.Image")));
            this.btnResetFiltr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetFiltr.Location = new System.Drawing.Point(896, 43);
            this.btnResetFiltr.Name = "btnResetFiltr";
            this.btnResetFiltr.Size = new System.Drawing.Size(94, 39);
            this.btnResetFiltr.TabIndex = 14;
            this.btnResetFiltr.Text = "Reset";
            this.btnResetFiltr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnResetFiltr.UseVisualStyleBackColor = false;
            this.btnResetFiltr.Click += new System.EventHandler(this.btnResetFiltr_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(12, 158);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(148, 36);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExport, "Exportuje právě aktivní tabulku do excelu.");
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // přidatKOpravámToolStripMenuItem
            // 
            this.přidatKOpravámToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("přidatKOpravámToolStripMenuItem.Image")));
            this.přidatKOpravámToolStripMenuItem.Name = "přidatKOpravámToolStripMenuItem";
            this.přidatKOpravámToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.přidatKOpravámToolStripMenuItem.Text = "Přidat k opravám";
            this.přidatKOpravámToolStripMenuItem.Click += new System.EventHandler(this.přidatKOpravámToolStripMenuItem_Click);
            // 
            // toolStripShowFolder
            // 
            this.toolStripShowFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripShowFolder.Image")));
            this.toolStripShowFolder.Name = "toolStripShowFolder";
            this.toolStripShowFolder.Size = new System.Drawing.Size(164, 22);
            this.toolStripShowFolder.Text = "Otevřit složku";
            this.toolStripShowFolder.Click += new System.EventHandler(this.toolStripShowFolder_Click);
            // 
            // StripMenuOpenDataRepairs
            // 
            this.StripMenuOpenDataRepairs.Image = ((System.Drawing.Image)(resources.GetObject("StripMenuOpenDataRepairs.Image")));
            this.StripMenuOpenDataRepairs.Name = "StripMenuOpenDataRepairs";
            this.StripMenuOpenDataRepairs.Size = new System.Drawing.Size(146, 22);
            this.StripMenuOpenDataRepairs.Text = "Data opravy";
            this.StripMenuOpenDataRepairs.Click += new System.EventHandler(this.StripMenuOpenDataRepairs_Click);
            // 
            // stripMenuOpenFolderRepairs
            // 
            this.stripMenuOpenFolderRepairs.Image = ((System.Drawing.Image)(resources.GetObject("stripMenuOpenFolderRepairs.Image")));
            this.stripMenuOpenFolderRepairs.Name = "stripMenuOpenFolderRepairs";
            this.stripMenuOpenFolderRepairs.Size = new System.Drawing.Size(146, 22);
            this.stripMenuOpenFolderRepairs.Text = "Otevřit složku";
            this.stripMenuOpenFolderRepairs.Click += new System.EventHandler(this.stripMenuOpenFolderRepairs_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(54)))), ((int)(((byte)(64)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(12, 593);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(148, 39);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Konec";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnExit, "Ukonči aplikaci.");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelData
            // 
            this.btnDelData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnDelData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelData.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDelData.FlatAppearance.BorderSize = 0;
            this.btnDelData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnDelData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelData.Image = ((System.Drawing.Image)(resources.GetObject("btnDelData.Image")));
            this.btnDelData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelData.Location = new System.Drawing.Point(12, 245);
            this.btnDelData.Name = "btnDelData";
            this.btnDelData.Size = new System.Drawing.Size(148, 39);
            this.btnDelData.TabIndex = 3;
            this.btnDelData.Text = "Smazat";
            this.btnDelData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnDelData, "Smaže vybrané data ze serveru.");
            this.btnDelData.UseVisualStyleBackColor = false;
            this.btnDelData.Click += new System.EventHandler(this.btnDelData_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(12, 548);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(148, 39);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "Uživatelé";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Visible = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnAddData
            // 
            this.btnAddData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnAddData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddData.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAddData.FlatAppearance.BorderSize = 0;
            this.btnAddData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnAddData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddData.Image = ((System.Drawing.Image)(resources.GetObject("btnAddData.Image")));
            this.btnAddData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddData.Location = new System.Drawing.Point(12, 200);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(148, 39);
            this.btnAddData.TabIndex = 3;
            this.btnAddData.Text = "Přidat";
            this.btnAddData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnAddData, "Přídá data na server.");
            this.btnAddData.UseVisualStyleBackColor = false;
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnReloadData
            // 
            this.btnReloadData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.btnReloadData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReloadData.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnReloadData.FlatAppearance.BorderSize = 0;
            this.btnReloadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(237)))), ((int)(((byte)(205)))));
            this.btnReloadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReloadData.Image = ((System.Drawing.Image)(resources.GetObject("btnReloadData.Image")));
            this.btnReloadData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReloadData.Location = new System.Drawing.Point(12, 113);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(148, 39);
            this.btnReloadData.TabIndex = 3;
            this.btnReloadData.Text = "Obnovit";
            this.btnReloadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.btnReloadData, "Znovu načte data ze serveru.");
            this.btnReloadData.UseVisualStyleBackColor = false;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
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
            // upravitKontaktyToolStripMenuItem
            // 
            this.upravitKontaktyToolStripMenuItem.Name = "upravitKontaktyToolStripMenuItem";
            this.upravitKontaktyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.upravitKontaktyToolStripMenuItem.Text = "Upravit kontakty";
            this.upravitKontaktyToolStripMenuItem.Click += new System.EventHandler(this.upravitKontaktyToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 689);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnResetFiltr);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
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
            this.CellContext.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOpravy)).EndInit();
            this.cellContextRepairs.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnResetFiltr;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip CellContext;
        private System.Windows.Forms.ToolStripMenuItem přidatKOpravámToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defektyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidatDefektToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravitDefektyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowFolder;
        private System.Windows.Forms.ContextMenuStrip cellContextRepairs;
        private System.Windows.Forms.ToolStripMenuItem stripMenuOpenFolderRepairs;
        private System.Windows.Forms.ToolStripMenuItem StripMenuOpenDataRepairs;
        private System.Windows.Forms.ToolStripMenuItem opravyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidatSoučástToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravitSoučástiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kontaktyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přidatKontaktToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upravitKontaktyToolStripMenuItem;
    }
}