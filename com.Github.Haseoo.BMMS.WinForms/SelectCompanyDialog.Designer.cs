namespace com.Github.Haseoo.BMMS.WinForms
{
    partial class SelectCompanyDialog
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
            this.CompanyList = new BrightIdeasSoftware.ObjectListView();
            this.CompanyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyCity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyVoivodeship = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.CompanyList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(782, 368);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.CompanyList.FullRowSelect = true;
            this.CompanyList.HideSelection = false;
            this.CompanyList.Location = new System.Drawing.Point(3, 3);
            this.CompanyList.Name = "CompanyList";
            this.CompanyList.ShowGroups = false;
            this.CompanyList.Size = new System.Drawing.Size(776, 320);
            this.CompanyList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.CompanyList.TabIndex = 2;
            this.CompanyList.UseCompatibleStateImageBehavior = false;
            this.CompanyList.View = System.Windows.Forms.View.Details;
            this.CompanyList.ItemActivate += new System.EventHandler(this.OnSelect);
            // 
            // CompanyName
            // 
            this.CompanyName.AspectName = "Name";
            this.CompanyName.Text = "Company Name";
            this.CompanyName.Width = 172;
            // 
            // CompanyAddress
            // 
            this.CompanyAddress.AspectName = "Address";
            this.CompanyAddress.Text = "Address";
            this.CompanyAddress.Width = 194;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.SelectBtn);
            this.flowLayoutPanel1.Controls.Add(this.CancelBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(617, 329);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // SelectBtn
            // 
            this.SelectBtn.Location = new System.Drawing.Point(84, 3);
            this.SelectBtn.Name = "SelectBtn";
            this.SelectBtn.Size = new System.Drawing.Size(75, 30);
            this.SelectBtn.TabIndex = 0;
            this.SelectBtn.Text = "Select";
            this.SelectBtn.UseVisualStyleBackColor = true;
            this.SelectBtn.Click += new System.EventHandler(this.OnSelect);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(3, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 30);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.OnCancel);
            // 
            // SelectCompanyDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectCompanyDialog";
            this.Text = "SelectCompanyDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CancelBtn;
        private BrightIdeasSoftware.ObjectListView CompanyList;
        private new BrightIdeasSoftware.OLVColumn CompanyName;
        private BrightIdeasSoftware.OLVColumn CompanyAddress;
        private BrightIdeasSoftware.OLVColumn CompanyCity;
        private BrightIdeasSoftware.OLVColumn CompanyVoivodeship;
    }
}