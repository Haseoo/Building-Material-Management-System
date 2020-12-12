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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CompanyList = new BrightIdeasSoftware.ObjectListView();
            this.CompanyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyAddress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyCity = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyVoivodeship = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).BeginInit();
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(617, 329);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 36);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Select";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
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
            this.CompanyList.Location = new System.Drawing.Point(3, 3);
            this.CompanyList.Name = "CompanyList";
            this.CompanyList.ShowGroups = false;
            this.CompanyList.Size = new System.Drawing.Size(776, 320);
            this.CompanyList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.CompanyList.TabIndex = 2;
            this.CompanyList.UseCompatibleStateImageBehavior = false;
            this.CompanyList.View = System.Windows.Forms.View.Details;
            // 
            // CompanyName
            // 
            this.CompanyName.AspectName = "Name";
            this.CompanyName.FillsFreeSpace = true;
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
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private BrightIdeasSoftware.ObjectListView CompanyList;
        private new BrightIdeasSoftware.OLVColumn CompanyName;
        private BrightIdeasSoftware.OLVColumn CompanyAddress;
        private BrightIdeasSoftware.OLVColumn CompanyCity;
        private BrightIdeasSoftware.OLVColumn CompanyVoivodeship;
    }
}