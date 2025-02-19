namespace PaymentsManagement
{
    partial class MoneyOut
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnConfirm = new MaterialSkin.Controls.MaterialButton();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtAmount = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtClientName = new MaterialSkin.Controls.MaterialTextBox();
            this.txtAccountId = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtAggrement = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDetails = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.cmbTranscationType = new MaterialSkin.Controls.MaterialComboBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(92, 106);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(58, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Client Id";
            // 
            // btnConfirm
            // 
            this.btnConfirm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConfirm.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnConfirm.Depth = 0;
            this.btnConfirm.HighEmphasis = true;
            this.btnConfirm.Icon = null;
            this.btnConfirm.Location = new System.Drawing.Point(300, 678);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(6, 9, 6, 9);
            this.btnConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnConfirm.Size = new System.Drawing.Size(86, 36);
            this.btnConfirm.TabIndex = 5;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnConfirm.UseAccentColor = false;
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel4.Location = new System.Drawing.Point(92, 236);
            this.materialLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(93, 19);
            this.materialLabel4.TabIndex = 14;
            this.materialLabel4.Text = "Amount(/Rs)";
            // 
            // txtAmount
            // 
            this.txtAmount.AnimateReadOnly = false;
            this.txtAmount.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmount.Depth = 0;
            this.txtAmount.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAmount.ForeColor = System.Drawing.SystemColors.Window;
            this.txtAmount.Hint = "Transcation Amount";
            this.txtAmount.LeadingIcon = null;
            this.txtAmount.Location = new System.Drawing.Point(92, 272);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAmount.MaxLength = 50;
            this.txtAmount.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAmount.Multiline = false;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(268, 50);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.Text = "";
            this.txtAmount.TrailingIcon = null;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(431, 108);
            this.materialLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(87, 19);
            this.materialLabel2.TabIndex = 12;
            this.materialLabel2.Text = "Client Name";
            // 
            // txtClientName
            // 
            this.txtClientName.AnimateReadOnly = false;
            this.txtClientName.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtClientName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClientName.Depth = 0;
            this.txtClientName.Enabled = false;
            this.txtClientName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtClientName.ForeColor = System.Drawing.SystemColors.Window;
            this.txtClientName.LeadingIcon = null;
            this.txtClientName.Location = new System.Drawing.Point(430, 148);
            this.txtClientName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtClientName.MaxLength = 50;
            this.txtClientName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtClientName.Multiline = false;
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.ReadOnly = true;
            this.txtClientName.Size = new System.Drawing.Size(272, 50);
            this.txtClientName.TabIndex = 11;
            this.txtClientName.Text = "";
            this.txtClientName.TrailingIcon = null;
            // 
            // txtAccountId
            // 
            this.txtAccountId.AnimateReadOnly = false;
            this.txtAccountId.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAccountId.Depth = 0;
            this.txtAccountId.Enabled = false;
            this.txtAccountId.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAccountId.ForeColor = System.Drawing.SystemColors.Window;
            this.txtAccountId.LeadingIcon = null;
            this.txtAccountId.Location = new System.Drawing.Point(92, 148);
            this.txtAccountId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAccountId.MaxLength = 50;
            this.txtAccountId.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAccountId.Multiline = false;
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.ReadOnly = true;
            this.txtAccountId.Size = new System.Drawing.Size(268, 50);
            this.txtAccountId.TabIndex = 9;
            this.txtAccountId.Text = "";
            this.txtAccountId.TrailingIcon = null;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(437, 238);
            this.materialLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(78, 19);
            this.materialLabel3.TabIndex = 17;
            this.materialLabel3.Text = "Aggrement";
            // 
            // txtAggrement
            // 
            this.txtAggrement.AnimateReadOnly = false;
            this.txtAggrement.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAggrement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAggrement.Depth = 0;
            this.txtAggrement.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAggrement.ForeColor = System.Drawing.SystemColors.Window;
            this.txtAggrement.Hint = "Write Aggrement";
            this.txtAggrement.LeadingIcon = null;
            this.txtAggrement.Location = new System.Drawing.Point(436, 272);
            this.txtAggrement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAggrement.MaxLength = 50;
            this.txtAggrement.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAggrement.Multiline = false;
            this.txtAggrement.Name = "txtAggrement";
            this.txtAggrement.Size = new System.Drawing.Size(266, 50);
            this.txtAggrement.TabIndex = 1;
            this.txtAggrement.Text = "";
            this.txtAggrement.TrailingIcon = null;
            this.txtAggrement.TextChanged += new System.EventHandler(this.materialTextBox1_TextChanged);
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(92, 481);
            this.materialLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(50, 19);
            this.materialLabel5.TabIndex = 19;
            this.materialLabel5.Text = "Details";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.dateTimePicker.Location = new System.Drawing.Point(93, 626);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(607, 26);
            this.dateTimePicker.TabIndex = 4;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel6.Location = new System.Drawing.Point(92, 594);
            this.materialLabel6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(34, 19);
            this.materialLabel6.TabIndex = 21;
            this.materialLabel6.Text = "Date";
            // 
            // txtDetails
            // 
            this.txtDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtDetails.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDetails.Depth = 0;
            this.txtDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtDetails.Location = new System.Drawing.Point(90, 512);
            this.txtDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDetails.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(609, 70);
            this.txtDetails.TabIndex = 3;
            this.txtDetails.Text = "";
            // 
            // cmbTranscationType
            // 
            this.cmbTranscationType.AutoResize = false;
            this.cmbTranscationType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbTranscationType.Depth = 0;
            this.cmbTranscationType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbTranscationType.DropDownHeight = 174;
            this.cmbTranscationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranscationType.DropDownWidth = 121;
            this.cmbTranscationType.Enabled = false;
            this.cmbTranscationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbTranscationType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbTranscationType.FormattingEnabled = true;
            this.cmbTranscationType.Hint = "Select Transcation Type";
            this.cmbTranscationType.IntegralHeight = false;
            this.cmbTranscationType.ItemHeight = 43;
            this.cmbTranscationType.Items.AddRange(new object[] {
            "Money Out",
            "Money In"});
            this.cmbTranscationType.Location = new System.Drawing.Point(92, 395);
            this.cmbTranscationType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTranscationType.MaxDropDownItems = 4;
            this.cmbTranscationType.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbTranscationType.Name = "cmbTranscationType";
            this.cmbTranscationType.Size = new System.Drawing.Size(607, 49);
            this.cmbTranscationType.StartIndex = 0;
            this.cmbTranscationType.TabIndex = 2;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(92, 360);
            this.materialLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(125, 19);
            this.materialLabel7.TabIndex = 22;
            this.materialLabel7.Text = "Transcation Type";
            // 
            // MoneyOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 833);
            this.Controls.Add(this.cmbTranscationType);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.txtDetails);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtAggrement);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.txtAccountId);
            this.Controls.Add(this.materialLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MoneyOut";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 4, 5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Money Out";
            this.Load += new System.EventHandler(this.MoneyOut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox txtAmount;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox txtClientName;
        private MaterialSkin.Controls.MaterialTextBox txtAccountId;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialTextBox txtAggrement;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialMultiLineTextBox txtDetails;
        public MaterialSkin.Controls.MaterialComboBox cmbTranscationType;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        public MaterialSkin.Controls.MaterialButton btnConfirm;
    }
}