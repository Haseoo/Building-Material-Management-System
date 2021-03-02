namespace com.Github.Haseoo.BMMS.WinForms
{
    partial class OfferListWindow
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
            this.OfferList = new BrightIdeasSoftware.ObjectListView();
            this.MaterialName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.CompanyName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.UnitPrice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Unit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Comments = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.LastModification = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.EditBtn = new System.Windows.Forms.Button();
            this.RemoveBtn = new System.Windows.Forms.Button();
            this.ShowMaterialBtn = new System.Windows.Forms.Button();
            this.ShowCompanyBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OfferList)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.OfferList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(737, 328);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // OfferList
            // 
            this.OfferList.AllColumns.Add(this.MaterialName);
            this.OfferList.AllColumns.Add(this.CompanyName);
            this.OfferList.AllColumns.Add(this.UnitPrice);
            this.OfferList.AllColumns.Add(this.Unit);
            this.OfferList.AllColumns.Add(this.Comments);
            this.OfferList.AllColumns.Add(this.LastModification);
            this.OfferList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OfferList.CellEditUseWholeCell = false;
            this.OfferList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaterialName,
            this.CompanyName,
            this.UnitPrice,
            this.Unit,
            this.Comments,
            this.LastModification});
            this.OfferList.Cursor = System.Windows.Forms.Cursors.Default;
            this.OfferList.FullRowSelect = true;
            this.OfferList.HideSelection = false;
            this.OfferList.Location = new System.Drawing.Point(3, 43);
            this.OfferList.MultiSelect = false;
            this.OfferList.Name = "OfferList";
            this.OfferList.ShowGroups = false;
            this.OfferList.Size = new System.Drawing.Size(731, 240);
            this.OfferList.TabIndex = 0;
            this.OfferList.UseCompatibleStateImageBehavior = false;
            this.OfferList.View = System.Windows.Forms.View.Details;
            this.OfferList.ItemActivate += new System.EventHandler(this.OnShowOffer);
            // 
            // MaterialName
            // 
            this.MaterialName.AspectName = "MaterialName";
            this.MaterialName.Text = "Material";
            this.MaterialName.Width = 127;
            // 
            // CompanyName
            // 
            this.CompanyName.AspectName = "CompanyName";
            this.CompanyName.Text = "Company";
            this.CompanyName.Width = 137;
            // 
            // UnitPrice
            // 
            this.UnitPrice.AspectName = "UnitPrice";
            this.UnitPrice.Text = "Price per unit";
            this.UnitPrice.Width = 108;
            // 
            // Unit
            // 
            this.Unit.AspectName = "Unit";
            this.Unit.Text = "Unit";
            this.Unit.Width = 82;
            // 
            // Comments
            // 
            this.Comments.AspectName = "Comments";
            this.Comments.Text = "Comments";
            this.Comments.Width = 264;
            // 
            // LastModification
            // 
            this.LastModification.AspectName = "LastModification";
            this.LastModification.Text = "Last modification";
            this.LastModification.Width = 143;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.EditBtn);
            this.flowLayoutPanel1.Controls.Add(this.RemoveBtn);
            this.flowLayoutPanel1.Controls.Add(this.ShowMaterialBtn);
            this.flowLayoutPanel1.Controls.Add(this.ShowCompanyBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 289);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(731, 36);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // EditBtn
            // 
            this.EditBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBtn.Location = new System.Drawing.Point(653, 3);
            this.EditBtn.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 30);
            this.EditBtn.TabIndex = 0;
            this.EditBtn.Text = "Edit";
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.OnShowOffer);
            // 
            // RemoveBtn
            // 
            this.RemoveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveBtn.Location = new System.Drawing.Point(525, 3);
            this.RemoveBtn.Margin = new System.Windows.Forms.Padding(50, 3, 3, 3);
            this.RemoveBtn.Name = "RemoveBtn";
            this.RemoveBtn.Size = new System.Drawing.Size(75, 30);
            this.RemoveBtn.TabIndex = 3;
            this.RemoveBtn.Text = "Remove";
            this.RemoveBtn.UseVisualStyleBackColor = true;
            this.RemoveBtn.Click += new System.EventHandler(this.OnRemoveBtnClick);
            // 
            // ShowMaterialBtn
            // 
            this.ShowMaterialBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowMaterialBtn.Location = new System.Drawing.Point(358, 3);
            this.ShowMaterialBtn.Name = "ShowMaterialBtn";
            this.ShowMaterialBtn.Size = new System.Drawing.Size(114, 30);
            this.ShowMaterialBtn.TabIndex = 1;
            this.ShowMaterialBtn.Text = "Show material";
            this.ShowMaterialBtn.UseVisualStyleBackColor = true;
            this.ShowMaterialBtn.Click += new System.EventHandler(this.OnShowMaterialBtnClick);
            // 
            // ShowCompanyBtn
            // 
            this.ShowCompanyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowCompanyBtn.Location = new System.Drawing.Point(230, 3);
            this.ShowCompanyBtn.Name = "ShowCompanyBtn";
            this.ShowCompanyBtn.Size = new System.Drawing.Size(122, 30);
            this.ShowCompanyBtn.TabIndex = 2;
            this.ShowCompanyBtn.Text = "Show company";
            this.ShowCompanyBtn.UseVisualStyleBackColor = true;
            this.ShowCompanyBtn.Click += new System.EventHandler(this.OnCompanyBtnClick);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Font = new System.Drawing.Font("Wingdings 3", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(697, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "Q";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RefreshOffers);
            // 
            // OfferListWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 352);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OfferListWindow";
            this.Text = "OfferListWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OfferList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BrightIdeasSoftware.ObjectListView OfferList;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button ShowMaterialBtn;
        private System.Windows.Forms.Button ShowCompanyBtn;
        private System.Windows.Forms.Button button1;
        private BrightIdeasSoftware.OLVColumn MaterialName;
        private BrightIdeasSoftware.OLVColumn UnitPrice;
        private BrightIdeasSoftware.OLVColumn Unit;
        private BrightIdeasSoftware.OLVColumn Comments;
        private BrightIdeasSoftware.OLVColumn LastModification;
        private System.Windows.Forms.Button RemoveBtn;
        private new BrightIdeasSoftware.OLVColumn CompanyName;
    }
}