namespace CosmaticShop.Forms.PurchaseForm
{
    partial class FrmNewPurchase
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblContructNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSupplyerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSaleUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPerUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPerQty = new System.Windows.Forms.TextBox();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblItemCost = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lkkk = new System.Windows.Forms.Label();
            this.lblSaleUnitePrice = new System.Windows.Forms.Label();
            this.ll = new System.Windows.Forms.Label();
            this.lblCurrentPurchaseUnitePrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentQty = new System.Windows.Forms.Label();
            this.dgvPurchaseCart = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurchaseUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSaleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotalItemCost = new System.Windows.Forms.Label();
            this.chkisPayment = new System.Windows.Forms.CheckBox();
            this.btnPurchaseCancle = new System.Windows.Forms.Button();
            this.btnPurchaseConfirm = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.lblContructNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblSupplyerName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(775, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Supplyer";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(7, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(189, 20);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lblContructNo
            // 
            this.lblContructNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContructNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContructNo.Location = new System.Drawing.Point(491, 37);
            this.lblContructNo.Name = "lblContructNo";
            this.lblContructNo.Size = new System.Drawing.Size(189, 20);
            this.lblContructNo.TabIndex = 0;
            this.lblContructNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(491, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Contract No.";
            // 
            // lblSupplyerName
            // 
            this.lblSupplyerName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSupplyerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplyerName.Location = new System.Drawing.Point(238, 37);
            this.lblSupplyerName.Name = "lblSupplyerName";
            this.lblSupplyerName.Size = new System.Drawing.Size(189, 20);
            this.lblSupplyerName.TabIndex = 0;
            this.lblSupplyerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(238, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Supplyer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Supplyer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtSaleUnitPrice);
            this.groupBox2.Controls.Add(this.txtPerUnitPrice);
            this.groupBox2.Controls.Add(this.txtPerQty);
            this.groupBox2.Controls.Add(this.cmbProduct);
            this.groupBox2.Controls.Add(this.cmbCategory);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblItemCost);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Products";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(136, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 36);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.PowderBlue;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClear.Location = new System.Drawing.Point(136, 230);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 36);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Orange;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdate.Location = new System.Drawing.Point(217, 229);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(62, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(217, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 36);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSaleUnitPrice
            // 
            this.txtSaleUnitPrice.Location = new System.Drawing.Point(7, 195);
            this.txtSaleUnitPrice.Name = "txtSaleUnitPrice";
            this.txtSaleUnitPrice.Size = new System.Drawing.Size(281, 20);
            this.txtSaleUnitPrice.TabIndex = 1;
            this.txtSaleUnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSaleUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleUnitPrice_KeyPress);
            // 
            // txtPerUnitPrice
            // 
            this.txtPerUnitPrice.Location = new System.Drawing.Point(6, 160);
            this.txtPerUnitPrice.Name = "txtPerUnitPrice";
            this.txtPerUnitPrice.Size = new System.Drawing.Size(281, 20);
            this.txtPerUnitPrice.TabIndex = 1;
            this.txtPerUnitPrice.TextChanged += new System.EventHandler(this.txtPerUnitPrice_TextChanged);
            this.txtPerUnitPrice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtPerUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerUnitPrice_KeyPress);
            // 
            // txtPerQty
            // 
            this.txtPerQty.Location = new System.Drawing.Point(6, 119);
            this.txtPerQty.Name = "txtPerQty";
            this.txtPerQty.Size = new System.Drawing.Size(281, 20);
            this.txtPerQty.TabIndex = 1;
            this.txtPerQty.TextChanged += new System.EventHandler(this.txtPerQty_TextChanged);
            this.txtPerQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPerQty_KeyPress);
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(6, 74);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(281, 21);
            this.cmbProduct.TabIndex = 6;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(6, 33);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(281, 21);
            this.cmbCategory.TabIndex = 6;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Item Cost";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sale Unite Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Purchase Unite Price";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Purchase Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select Product";
            // 
            // lblItemCost
            // 
            this.lblItemCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCost.Location = new System.Drawing.Point(6, 237);
            this.lblItemCost.Name = "lblItemCost";
            this.lblItemCost.Size = new System.Drawing.Size(125, 20);
            this.lblItemCost.TabIndex = 0;
            this.lblItemCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Select Category";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lkkk);
            this.groupBox3.Controls.Add(this.lblSaleUnitePrice);
            this.groupBox3.Controls.Add(this.ll);
            this.groupBox3.Controls.Add(this.lblCurrentPurchaseUnitePrice);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblCurrentQty);
            this.groupBox3.Location = new System.Drawing.Point(13, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(297, 158);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Product Status";
            // 
            // lkkk
            // 
            this.lkkk.AutoSize = true;
            this.lkkk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkkk.Location = new System.Drawing.Point(6, 104);
            this.lkkk.Name = "lkkk";
            this.lkkk.Size = new System.Drawing.Size(125, 17);
            this.lkkk.TabIndex = 0;
            this.lkkk.Text = "Sale Unite Price";
            // 
            // lblSaleUnitePrice
            // 
            this.lblSaleUnitePrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSaleUnitePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaleUnitePrice.Location = new System.Drawing.Point(6, 125);
            this.lblSaleUnitePrice.Name = "lblSaleUnitePrice";
            this.lblSaleUnitePrice.Size = new System.Drawing.Size(285, 24);
            this.lblSaleUnitePrice.TabIndex = 0;
            this.lblSaleUnitePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ll
            // 
            this.ll.AutoSize = true;
            this.ll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.Location = new System.Drawing.Point(6, 56);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(220, 17);
            this.ll.TabIndex = 0;
            this.ll.Text = "Current Purchase Unite Price";
            // 
            // lblCurrentPurchaseUnitePrice
            // 
            this.lblCurrentPurchaseUnitePrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentPurchaseUnitePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPurchaseUnitePrice.Location = new System.Drawing.Point(6, 77);
            this.lblCurrentPurchaseUnitePrice.Name = "lblCurrentPurchaseUnitePrice";
            this.lblCurrentPurchaseUnitePrice.Size = new System.Drawing.Size(285, 24);
            this.lblCurrentPurchaseUnitePrice.TabIndex = 0;
            this.lblCurrentPurchaseUnitePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Current Qty";
            // 
            // lblCurrentQty
            // 
            this.lblCurrentQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentQty.Location = new System.Drawing.Point(6, 34);
            this.lblCurrentQty.Name = "lblCurrentQty";
            this.lblCurrentQty.Size = new System.Drawing.Size(285, 24);
            this.lblCurrentQty.TabIndex = 0;
            this.lblCurrentQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvPurchaseCart
            // 
            this.dgvPurchaseCart.AllowUserToAddRows = false;
            this.dgvPurchaseCart.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvPurchaseCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchaseCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProduct,
            this.colCategoryId,
            this.colCategory,
            this.colQty,
            this.colPurchaseUnitPrice,
            this.colSaleUnitPrice,
            this.colItemCost});
            this.dgvPurchaseCart.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPurchaseCart.Location = new System.Drawing.Point(327, 131);
            this.dgvPurchaseCart.MultiSelect = false;
            this.dgvPurchaseCart.Name = "dgvPurchaseCart";
            this.dgvPurchaseCart.ReadOnly = true;
            this.dgvPurchaseCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchaseCart.Size = new System.Drawing.Size(459, 309);
            this.dgvPurchaseCart.TabIndex = 2;
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ID";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // colProduct
            // 
            this.colProduct.HeaderText = "Item";
            this.colProduct.Name = "colProduct";
            this.colProduct.ReadOnly = true;
            // 
            // colCategoryId
            // 
            this.colCategoryId.HeaderText = "CategoryID";
            this.colCategoryId.Name = "colCategoryId";
            this.colCategoryId.ReadOnly = true;
            this.colCategoryId.Visible = false;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colQty
            // 
            this.colQty.HeaderText = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.ReadOnly = true;
            // 
            // colPurchaseUnitPrice
            // 
            this.colPurchaseUnitPrice.HeaderText = "Purchase U-P";
            this.colPurchaseUnitPrice.Name = "colPurchaseUnitPrice";
            this.colPurchaseUnitPrice.ReadOnly = true;
            // 
            // colSaleUnitPrice
            // 
            this.colSaleUnitPrice.HeaderText = "Sale U-P";
            this.colSaleUnitPrice.Name = "colSaleUnitPrice";
            this.colSaleUnitPrice.ReadOnly = true;
            // 
            // colItemCost
            // 
            this.colItemCost.HeaderText = "Item Cost";
            this.colItemCost.Name = "colItemCost";
            this.colItemCost.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(329, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "Purchase Cart";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(573, 458);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Total Cost";
            // 
            // lblTotalItemCost
            // 
            this.lblTotalItemCost.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalItemCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemCost.Location = new System.Drawing.Point(661, 458);
            this.lblTotalItemCost.Name = "lblTotalItemCost";
            this.lblTotalItemCost.Size = new System.Drawing.Size(125, 20);
            this.lblTotalItemCost.TabIndex = 0;
            this.lblTotalItemCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkisPayment
            // 
            this.chkisPayment.AutoSize = true;
            this.chkisPayment.Checked = true;
            this.chkisPayment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkisPayment.Location = new System.Drawing.Point(329, 456);
            this.chkisPayment.Name = "chkisPayment";
            this.chkisPayment.Size = new System.Drawing.Size(120, 17);
            this.chkisPayment.TabIndex = 3;
            this.chkisPayment.Text = "isPaymentSucced ?";
            this.chkisPayment.UseVisualStyleBackColor = true;
            this.chkisPayment.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnPurchaseCancle
            // 
            this.btnPurchaseCancle.BackColor = System.Drawing.Color.Red;
            this.btnPurchaseCancle.FlatAppearance.BorderSize = 0;
            this.btnPurchaseCancle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseCancle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseCancle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPurchaseCancle.Location = new System.Drawing.Point(329, 502);
            this.btnPurchaseCancle.Name = "btnPurchaseCancle";
            this.btnPurchaseCancle.Size = new System.Drawing.Size(89, 35);
            this.btnPurchaseCancle.TabIndex = 11;
            this.btnPurchaseCancle.Text = "Cancel";
            this.btnPurchaseCancle.UseVisualStyleBackColor = false;
            this.btnPurchaseCancle.Click += new System.EventHandler(this.btnPurchaseCancle_Click);
            // 
            // btnPurchaseConfirm
            // 
            this.btnPurchaseConfirm.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btnPurchaseConfirm.FlatAppearance.BorderSize = 0;
            this.btnPurchaseConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseConfirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPurchaseConfirm.Location = new System.Drawing.Point(697, 504);
            this.btnPurchaseConfirm.Name = "btnPurchaseConfirm";
            this.btnPurchaseConfirm.Size = new System.Drawing.Size(91, 36);
            this.btnPurchaseConfirm.TabIndex = 12;
            this.btnPurchaseConfirm.Text = "Confirm";
            this.btnPurchaseConfirm.UseVisualStyleBackColor = false;
            this.btnPurchaseConfirm.Click += new System.EventHandler(this.btnPurchaseConfirm_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(424, 502);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(267, 38);
            this.txtComment.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(421, 486);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Purchase Comment";
            // 
            // FrmNewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 549);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnPurchaseCancle);
            this.Controls.Add(this.btnPurchaseConfirm);
            this.Controls.Add(this.chkisPayment);
            this.Controls.Add(this.dgvPurchaseCart);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblTotalItemCost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Purchase";
            this.Load += new System.EventHandler(this.FrmNewPurchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchaseCart)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblContructNo;
        public System.Windows.Forms.Label lblSupplyerName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label lblItemCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lkkk;
        public System.Windows.Forms.Label lblSaleUnitePrice;
        private System.Windows.Forms.Label ll;
        public System.Windows.Forms.Label lblCurrentPurchaseUnitePrice;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblCurrentQty;
        private System.Windows.Forms.TextBox txtSaleUnitPrice;
        private System.Windows.Forms.TextBox txtPerUnitPrice;
        private System.Windows.Forms.TextBox txtPerQty;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DataGridView dgvPurchaseCart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Button btnPurchaseCancle;
        private System.Windows.Forms.Button btnPurchaseConfirm;
        private System.Windows.Forms.CheckBox chkisPayment;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label lblTotalItemCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurchaseUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSaleUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCost;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label11;
    }
}