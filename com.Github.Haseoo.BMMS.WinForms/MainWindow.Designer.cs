namespace com.Github.Haseoo.BMMS.WinForms
{
    partial class MainWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.offerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Materials = new System.Windows.Forms.TabPage();
            this.Comapnies = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.CompanySearchField = new System.Windows.Forms.TextBox();
            this.CompanyRefreshBtn = new System.Windows.Forms.Button();
            this.CompanySearchBtn = new System.Windows.Forms.Button();
            this.CompanyList = new BrightIdeasSoftware.ObjectListView();
            this.CompanyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyCity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyVoivodeship = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.MaterialSearchBtn = new System.Windows.Forms.Button();
            this.MaterialRefreshBtn = new System.Windows.Forms.Button();
            this.MaterialSearchField = new System.Windows.Forms.TextBox();
            this.MaterialList = new BrightIdeasSoftware.ObjectListView();
            this.MaterialName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Specification = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.Materials.SuspendLayout();
            this.Comapnies.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialList)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(850, 490);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.addToolStripMenuItem1,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(850, 28);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.addToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.OnQuit);
            // 
            // addToolStripMenuItem1
            // 
            this.addToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.materialToolStripMenuItem,
            this.offerToolStripMenuItem});
            this.addToolStripMenuItem1.Name = "addToolStripMenuItem1";
            this.addToolStripMenuItem1.Size = new System.Drawing.Size(51, 24);
            this.addToolStripMenuItem1.Text = "Add";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.companyToolStripMenuItem.Text = "Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.OnAddCompany);
            // 
            // materialToolStripMenuItem
            // 
            this.materialToolStripMenuItem.Name = "materialToolStripMenuItem";
            this.materialToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.materialToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.materialToolStripMenuItem.Text = "Material";
            this.materialToolStripMenuItem.Click += new System.EventHandler(this.OnMaterialAdd);
            // 
            // offerToolStripMenuItem
            // 
            this.offerToolStripMenuItem.Name = "offerToolStripMenuItem";
            this.offerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.O)));
            this.offerToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.offerToolStripMenuItem.Text = "Offer";
            this.offerToolStripMenuItem.Click += new System.EventHandler(this.OnAddOffer);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.rToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.editToolStripMenuItem.Text = "Entry";
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.E)));
            this.editToolStripMenuItem1.Size = new System.Drawing.Size(201, 26);
            this.editToolStripMenuItem1.Text = "Edit ";
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.rToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.rToolStripMenuItem.Text = "Remove";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.H)));
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(206, 26);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // Materials
            // 
            this.Materials.Controls.Add(this.tableLayoutPanel4);
            this.Materials.Location = new System.Drawing.Point(4, 25);
            this.Materials.Name = "Materials";
            this.Materials.Padding = new System.Windows.Forms.Padding(3);
            this.Materials.Size = new System.Drawing.Size(832, 423);
            this.Materials.TabIndex = 1;
            this.Materials.Text = "Materials";
            this.Materials.UseVisualStyleBackColor = true;
            // 
            // Comapnies
            // 
            this.Comapnies.AccessibleDescription = "";
            this.Comapnies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Comapnies.Controls.Add(this.tableLayoutPanel2);
            this.Comapnies.Location = new System.Drawing.Point(4, 25);
            this.Comapnies.Margin = new System.Windows.Forms.Padding(0);
            this.Comapnies.Name = "Comapnies";
            this.Comapnies.Padding = new System.Windows.Forms.Padding(8);
            this.Comapnies.Size = new System.Drawing.Size(832, 423);
            this.Comapnies.TabIndex = 0;
            this.Comapnies.Text = "Companies";
            this.Comapnies.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.CompanyList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(830, 421);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.CompanySearchBtn, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.CompanyRefreshBtn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.CompanySearchField, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(824, 36);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // CompanySearchField
            // 
            this.CompanySearchField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanySearchField.Location = new System.Drawing.Point(3, 10);
            this.CompanySearchField.Name = "CompanySearchField";
            this.CompanySearchField.Size = new System.Drawing.Size(793, 22);
            this.CompanySearchField.TabIndex = 2;
            // 
            // CompanyRefreshBtn
            // 
            this.CompanyRefreshBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CompanyRefreshBtn.Location = new System.Drawing.Point(883, 6);
            this.CompanyRefreshBtn.Name = "CompanyRefreshBtn";
            this.CompanyRefreshBtn.Size = new System.Drawing.Size(75, 30);
            this.CompanyRefreshBtn.TabIndex = 1;
            this.CompanyRefreshBtn.Text = "Refresh";
            this.CompanyRefreshBtn.UseVisualStyleBackColor = true;
            // 
            // CompanySearchBtn
            // 
            this.CompanySearchBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CompanySearchBtn.Location = new System.Drawing.Point(802, 6);
            this.CompanySearchBtn.Name = "CompanySearchBtn";
            this.CompanySearchBtn.Size = new System.Drawing.Size(75, 30);
            this.CompanySearchBtn.TabIndex = 0;
            this.CompanySearchBtn.Text = "Search";
            this.CompanySearchBtn.UseVisualStyleBackColor = true;
            // 
            // CompanyList
            // 
            this.CompanyList.AllColumns.Add(this.CompanyName);
            this.CompanyList.AllColumns.Add(this.CompanyAddress);
            this.CompanyList.AllColumns.Add(this.CompanyCity);
            this.CompanyList.AllColumns.Add(this.CompanyVoivodeship);
            this.CompanyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompanyList.CellEditUseWholeCell = false;
            this.CompanyList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CompanyName,
            this.CompanyAddress,
            this.CompanyCity,
            this.CompanyVoivodeship});
            this.CompanyList.Cursor = System.Windows.Forms.Cursors.Default;
            this.CompanyList.HideSelection = false;
            this.CompanyList.Location = new System.Drawing.Point(0, 50);
            this.CompanyList.Margin = new System.Windows.Forms.Padding(0);
            this.CompanyList.Name = "CompanyList";
            this.CompanyList.ShowGroups = false;
            this.CompanyList.Size = new System.Drawing.Size(830, 371);
            this.CompanyList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.CompanyList.TabIndex = 3;
            this.CompanyList.UseCompatibleStateImageBehavior = false;
            this.CompanyList.View = System.Windows.Forms.View.Details;
            // 
            // CompanyName
            // 
            this.CompanyName.AspectName = "Name";
            this.CompanyName.Text = "Company Name";
            this.CompanyName.Width = 303;
            // 
            // CompanyAddress
            // 
            this.CompanyAddress.AspectName = "Address";
            this.CompanyAddress.Text = "Address";
            this.CompanyAddress.Width = 285;
            // 
            // CompanyCity
            // 
            this.CompanyCity.AspectName = "City";
            this.CompanyCity.Text = "City";
            this.CompanyCity.Width = 180;
            // 
            // CompanyVoivodeship
            // 
            this.CompanyVoivodeship.AspectName = "Voivodeship";
            this.CompanyVoivodeship.Text = "Voivodeship";
            this.CompanyVoivodeship.Width = 190;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Comapnies);
            this.tabControl1.Controls.Add(this.Materials);
            this.tabControl1.Location = new System.Drawing.Point(5, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 452);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.OnTabChange);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.MaterialList, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(830, 421);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.MaterialSearchBtn, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.MaterialRefreshBtn, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.MaterialSearchField, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(824, 36);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // MaterialSearchBtn
            // 
            this.MaterialSearchBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaterialSearchBtn.Location = new System.Drawing.Point(665, 3);
            this.MaterialSearchBtn.Name = "MaterialSearchBtn";
            this.MaterialSearchBtn.Size = new System.Drawing.Size(75, 30);
            this.MaterialSearchBtn.TabIndex = 0;
            this.MaterialSearchBtn.Text = "Search";
            this.MaterialSearchBtn.UseVisualStyleBackColor = true;
            // 
            // MaterialRefreshBtn
            // 
            this.MaterialRefreshBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MaterialRefreshBtn.Location = new System.Drawing.Point(746, 3);
            this.MaterialRefreshBtn.Name = "MaterialRefreshBtn";
            this.MaterialRefreshBtn.Size = new System.Drawing.Size(75, 30);
            this.MaterialRefreshBtn.TabIndex = 1;
            this.MaterialRefreshBtn.Text = "Refresh";
            this.MaterialRefreshBtn.UseVisualStyleBackColor = true;
            // 
            // MaterialSearchField
            // 
            this.MaterialSearchField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialSearchField.Location = new System.Drawing.Point(3, 7);
            this.MaterialSearchField.Name = "MaterialSearchField";
            this.MaterialSearchField.Size = new System.Drawing.Size(656, 22);
            this.MaterialSearchField.TabIndex = 2;
            // 
            // MaterialList
            // 
            this.MaterialList.AllColumns.Add(this.MaterialName);
            this.MaterialList.AllColumns.Add(this.Specification);
            this.MaterialList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaterialList.CellEditUseWholeCell = false;
            this.MaterialList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaterialName,
            this.Specification});
            this.MaterialList.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaterialList.HideSelection = false;
            this.MaterialList.Location = new System.Drawing.Point(0, 50);
            this.MaterialList.Margin = new System.Windows.Forms.Padding(0);
            this.MaterialList.Name = "MaterialList";
            this.MaterialList.ShowGroups = false;
            this.MaterialList.Size = new System.Drawing.Size(830, 371);
            this.MaterialList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.MaterialList.TabIndex = 3;
            this.MaterialList.UseCompatibleStateImageBehavior = false;
            this.MaterialList.View = System.Windows.Forms.View.Details;
            // 
            // MaterialName
            // 
            this.MaterialName.AspectName = "Name";
            this.MaterialName.Text = "Material name";
            this.MaterialName.Width = 172;
            // 
            // Specification
            // 
            this.Specification.AspectName = "Specification";
            this.Specification.Text = "Specification";
            this.Specification.Width = 737;
            // 
            // MainWindow
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(848, 491);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "Building Material Management System";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.Materials.ResumeLayout(false);
            this.Comapnies.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem offerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Comapnies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private BrightIdeasSoftware.ObjectListView CompanyList;
        private BrightIdeasSoftware.OLVColumn CompanyName;
        private BrightIdeasSoftware.OLVColumn CompanyAddress;
        private BrightIdeasSoftware.OLVColumn CompanyCity;
        private BrightIdeasSoftware.OLVColumn CompanyVoivodeship;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button CompanySearchBtn;
        private System.Windows.Forms.Button CompanyRefreshBtn;
        private System.Windows.Forms.TextBox CompanySearchField;
        private System.Windows.Forms.TabPage Materials;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button MaterialSearchBtn;
        private System.Windows.Forms.Button MaterialRefreshBtn;
        private System.Windows.Forms.TextBox MaterialSearchField;
        private BrightIdeasSoftware.ObjectListView MaterialList;
        private BrightIdeasSoftware.OLVColumn MaterialName;
        private BrightIdeasSoftware.OLVColumn Specification;
    }
}