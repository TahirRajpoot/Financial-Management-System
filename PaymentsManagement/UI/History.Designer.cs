namespace PaymentsManagement
{
    partial class History
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltotalMoneyOut = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.btnRadioAll = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblClientId = new MaterialSkin.Controls.MaterialLabel();
            this.lblClientIdText = new MaterialSkin.Controls.MaterialLabel();
            this.btnRadioMoneyIn = new MaterialSkin.Controls.MaterialRadioButton();
            this.btnRadioMoneyOut = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblPaymentRemaining = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.lblPaymentReeived = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.LBLClientName = new MaterialSkin.Controls.MaterialLabel();
            this.lblClientNameText = new MaterialSkin.Controls.MaterialLabel();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.dataGridView3, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 98);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1170, 652);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 4F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(196)))), ((int)(((byte)(185)))));
            this.dataGridView3.Location = new System.Drawing.Point(3, 329);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersWidth = 62;
            this.dataGridView3.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView3.RowTemplate.Height = 28;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView3.ShowEditingIcon = false;
            this.dataGridView3.Size = new System.Drawing.Size(1164, 320);
            this.dataGridView3.TabIndex = 9;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // Delete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            this.Delete.DefaultCellStyle = dataGridViewCellStyle2;
            this.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Delete.HeaderText = "Edit";
            this.Delete.MinimumWidth = 8;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "Edit";
            this.Delete.ToolTipText = "Edit the Transcation";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbltotalMoneyOut);
            this.panel1.Controls.Add(this.materialLabel6);
            this.panel1.Controls.Add(this.btnRadioAll);
            this.panel1.Controls.Add(this.lblClientId);
            this.panel1.Controls.Add(this.lblClientIdText);
            this.panel1.Controls.Add(this.btnRadioMoneyIn);
            this.panel1.Controls.Add(this.btnRadioMoneyOut);
            this.panel1.Controls.Add(this.lblPaymentRemaining);
            this.panel1.Controls.Add(this.materialLabel4);
            this.panel1.Controls.Add(this.lblPaymentReeived);
            this.panel1.Controls.Add(this.materialLabel3);
            this.panel1.Controls.Add(this.LBLClientName);
            this.panel1.Controls.Add(this.lblClientNameText);
            this.panel1.Location = new System.Drawing.Point(4, 27);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1162, 272);
            this.panel1.TabIndex = 0;
            // 
            // lbltotalMoneyOut
            // 
            this.lbltotalMoneyOut.AutoSize = true;
            this.lbltotalMoneyOut.Depth = 0;
            this.lbltotalMoneyOut.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lbltotalMoneyOut.Location = new System.Drawing.Point(831, 100);
            this.lbltotalMoneyOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalMoneyOut.MouseState = MaterialSkin.MouseState.HOVER;
            this.lbltotalMoneyOut.Name = "lbltotalMoneyOut";
            this.lbltotalMoneyOut.Size = new System.Drawing.Size(29, 19);
            this.lbltotalMoneyOut.TabIndex = 17;
            this.lbltotalMoneyOut.Text = "N/A";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(260, 100);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(119, 19);
            this.materialLabel6.TabIndex = 16;
            this.materialLabel6.Text = "Total Money Out";
            // 
            // btnRadioAll
            // 
            this.btnRadioAll.AutoSize = true;
            this.btnRadioAll.Depth = 0;
            this.btnRadioAll.Location = new System.Drawing.Point(258, 222);
            this.btnRadioAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnRadioAll.MouseLocation = new System.Drawing.Point(-1, -1);
            this.btnRadioAll.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRadioAll.Name = "btnRadioAll";
            this.btnRadioAll.Ripple = true;
            this.btnRadioAll.Size = new System.Drawing.Size(53, 37);
            this.btnRadioAll.TabIndex = 0;
            this.btnRadioAll.TabStop = true;
            this.btnRadioAll.Text = "All";
            this.btnRadioAll.UseVisualStyleBackColor = true;
            this.btnRadioAll.CheckedChanged += new System.EventHandler(this.btnRadioAll_CheckedChanged);
            // 
            // lblClientId
            // 
            this.lblClientId.AutoSize = true;
            this.lblClientId.Depth = 0;
            this.lblClientId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientId.Location = new System.Drawing.Point(831, 9);
            this.lblClientId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientId.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientId.Name = "lblClientId";
            this.lblClientId.Size = new System.Drawing.Size(29, 19);
            this.lblClientId.TabIndex = 15;
            this.lblClientId.Text = "N/A";
            // 
            // lblClientIdText
            // 
            this.lblClientIdText.AutoSize = true;
            this.lblClientIdText.Depth = 0;
            this.lblClientIdText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientIdText.Location = new System.Drawing.Point(260, 9);
            this.lblClientIdText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientIdText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientIdText.Name = "lblClientIdText";
            this.lblClientIdText.Size = new System.Drawing.Size(58, 19);
            this.lblClientIdText.TabIndex = 14;
            this.lblClientIdText.Text = "Client Id";
            // 
            // btnRadioMoneyIn
            // 
            this.btnRadioMoneyIn.AutoSize = true;
            this.btnRadioMoneyIn.Depth = 0;
            this.btnRadioMoneyIn.Location = new System.Drawing.Point(746, 222);
            this.btnRadioMoneyIn.Margin = new System.Windows.Forms.Padding(0);
            this.btnRadioMoneyIn.MouseLocation = new System.Drawing.Point(-1, -1);
            this.btnRadioMoneyIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRadioMoneyIn.Name = "btnRadioMoneyIn";
            this.btnRadioMoneyIn.Ripple = true;
            this.btnRadioMoneyIn.Size = new System.Drawing.Size(132, 37);
            this.btnRadioMoneyIn.TabIndex = 13;
            this.btnRadioMoneyIn.TabStop = true;
            this.btnRadioMoneyIn.Text = "Only MoneyIn";
            this.btnRadioMoneyIn.UseVisualStyleBackColor = true;
            this.btnRadioMoneyIn.CheckedChanged += new System.EventHandler(this.btnRadioMoneyIn_CheckedChanged);
            // 
            // btnRadioMoneyOut
            // 
            this.btnRadioMoneyOut.AutoSize = true;
            this.btnRadioMoneyOut.Depth = 0;
            this.btnRadioMoneyOut.Location = new System.Drawing.Point(453, 220);
            this.btnRadioMoneyOut.Margin = new System.Windows.Forms.Padding(0);
            this.btnRadioMoneyOut.MouseLocation = new System.Drawing.Point(-1, -1);
            this.btnRadioMoneyOut.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRadioMoneyOut.Name = "btnRadioMoneyOut";
            this.btnRadioMoneyOut.Ripple = true;
            this.btnRadioMoneyOut.Size = new System.Drawing.Size(144, 37);
            this.btnRadioMoneyOut.TabIndex = 12;
            this.btnRadioMoneyOut.TabStop = true;
            this.btnRadioMoneyOut.Text = "Only MoneyOut";
            this.btnRadioMoneyOut.UseVisualStyleBackColor = true;
            this.btnRadioMoneyOut.CheckedChanged += new System.EventHandler(this.btnRadioMoneyOut_CheckedChanged);
            // 
            // lblPaymentRemaining
            // 
            this.lblPaymentRemaining.AutoSize = true;
            this.lblPaymentRemaining.Depth = 0;
            this.lblPaymentRemaining.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPaymentRemaining.Location = new System.Drawing.Point(831, 185);
            this.lblPaymentRemaining.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentRemaining.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPaymentRemaining.Name = "lblPaymentRemaining";
            this.lblPaymentRemaining.Size = new System.Drawing.Size(29, 19);
            this.lblPaymentRemaining.TabIndex = 11;
            this.lblPaymentRemaining.Text = "N/A";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(260, 185);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(144, 19);
            this.materialLabel4.TabIndex = 10;
            this.materialLabel4.Text = "Payment Remaining";
            // 
            // lblPaymentReeived
            // 
            this.lblPaymentReeived.AutoSize = true;
            this.lblPaymentReeived.Depth = 0;
            this.lblPaymentReeived.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPaymentReeived.Location = new System.Drawing.Point(831, 142);
            this.lblPaymentReeived.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentReeived.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblPaymentReeived.Name = "lblPaymentReeived";
            this.lblPaymentReeived.Size = new System.Drawing.Size(29, 19);
            this.lblPaymentReeived.TabIndex = 9;
            this.lblPaymentReeived.Text = "N/A";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(260, 142);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(131, 19);
            this.materialLabel3.TabIndex = 8;
            this.materialLabel3.Text = "Payment Received";
            // 
            // LBLClientName
            // 
            this.LBLClientName.AutoSize = true;
            this.LBLClientName.Depth = 0;
            this.LBLClientName.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.LBLClientName.Location = new System.Drawing.Point(831, 55);
            this.LBLClientName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LBLClientName.MouseState = MaterialSkin.MouseState.HOVER;
            this.LBLClientName.Name = "LBLClientName";
            this.LBLClientName.Size = new System.Drawing.Size(29, 19);
            this.LBLClientName.TabIndex = 7;
            this.LBLClientName.Text = "N/A";
            // 
            // lblClientNameText
            // 
            this.lblClientNameText.AutoSize = true;
            this.lblClientNameText.Depth = 0;
            this.lblClientNameText.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblClientNameText.Location = new System.Drawing.Point(260, 55);
            this.lblClientNameText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClientNameText.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblClientNameText.Name = "lblClientNameText";
            this.lblClientNameText.Size = new System.Drawing.Size(87, 19);
            this.lblClientNameText.TabIndex = 6;
            this.lblClientNameText.Text = "Client Name";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 755);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "History";
            this.Padding = new System.Windows.Forms.Padding(4, 98, 4, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        public System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialLabel lblClientId;
        private MaterialSkin.Controls.MaterialRadioButton btnRadioMoneyIn;
        private MaterialSkin.Controls.MaterialRadioButton btnRadioMoneyOut;
        private MaterialSkin.Controls.MaterialLabel lblPaymentRemaining;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel lblPaymentReeived;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel LBLClientName;
        private MaterialSkin.Controls.MaterialRadioButton btnRadioAll;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private MaterialSkin.Controls.MaterialLabel lbltotalMoneyOut;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        public MaterialSkin.Controls.MaterialLabel lblClientIdText;
        public MaterialSkin.Controls.MaterialLabel lblClientNameText;
    }
}