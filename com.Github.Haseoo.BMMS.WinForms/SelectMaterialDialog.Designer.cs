namespace com.Github.Haseoo.BMMS.WinForms
{
    partial class SelectMaterialDialog
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
            this.MaterialList = new BrightIdeasSoftware.ObjectListView();
            this.MaterialName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Specification = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SelectBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialList)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.MaterialList, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(978, 348);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.MaterialList.FullRowSelect = true;
            this.MaterialList.HideSelection = false;
            this.MaterialList.Location = new System.Drawing.Point(3, 3);
            this.MaterialList.Name = "MaterialList";
            this.MaterialList.ShowGroups = false;
            this.MaterialList.Size = new System.Drawing.Size(972, 300);
            this.MaterialList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.MaterialList.TabIndex = 2;
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
            this.Specification.FillsFreeSpace = true;
            this.Specification.Text = "Specification";
            this.Specification.Width = 194;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.SelectBtn);
            this.flowLayoutPanel1.Controls.Add(this.CancelBtn);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(813, 309);
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
            this.SelectBtn.Click += new System.EventHandler(this.OnSelectBtnClick);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(3, 3);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 30);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.OnCancelBtnClick);
            // 
            // SelectMaterialDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SelectMaterialDialog";
            this.Text = "SelectMaterialDialog";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialList)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button SelectBtn;
        private System.Windows.Forms.Button CancelBtn;
        private BrightIdeasSoftware.ObjectListView MaterialList;
        private BrightIdeasSoftware.OLVColumn MaterialName;
        private BrightIdeasSoftware.OLVColumn Specification;
    }
}