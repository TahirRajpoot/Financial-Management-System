using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using PaymentsManagement.DL;

namespace PaymentsManagement
{
    public partial class History : MaterialForm
    {
        int ClientId;
        string ClientName;
        public History(int ClientId,string ClientName)
        {
            InitializeComponent();
            lblClientId.Text = ClientId.ToString();
            LBLClientName.Text = ClientName.ToString();
            this.ClientId = ClientId;
            this.ClientName = ClientName;
        }

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView3.BorderStyle = BorderStyle.None;
            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView3.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView3.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridView3.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView3.BackgroundColor = Color.White;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
        public void bindHistory(int ClientId, TransactionType transactionType)
        {
            try
            {

                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = TranscationDL.History(ClientId, transactionType);

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.CurrencySymbol = "Rs ";

                dataGridView3.DataSource = bindingSource3;
                dataGridView3.Columns["ObjectId"].Visible = false;
                dataGridView3.Columns["Type"].Visible = false;
                dataGridView3.Columns["Amount"].Visible = false;

                decimal PaymentReceived = TranscationDL.PaymentReceived(ClientId);
                string value1 = String.Format("{0:N2}", PaymentReceived);

                Account a = AccountDL.getAccount(ClientId);
                decimal balance = -a.Balance;
                string value2 = String.Format("{0:N2}", balance);

                decimal totalMoneyOut = TranscationDL.getTotalMoneyOut(ClientId);
                string value3 = String.Format("{0:N2}", totalMoneyOut);

                lblPaymentReeived.Text = value1;

                lblPaymentRemaining.Text = value2;
                LBLClientName.Text = a.ClientName.ToString();
                lblClientId.Text = ClientId.ToString();
                lbltotalMoneyOut.Text = value3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error showing the data! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void bindHistory(int ClientId)
        {
            try
            {
                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = TranscationDL.History(ClientId);


                dataGridView3.DataSource = bindingSource3;
                dataGridView3.Columns["ObjectId"].Visible = false;
                dataGridView3.Columns["Type"].Visible = false;
                dataGridView3.Columns["Amount"].Visible = false;

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();                
                numberFormatInfo.CurrencySymbol = "Rs ";

                decimal PaymentReceived = TranscationDL.PaymentReceived(ClientId);
                string value1 = String.Format("{0:N2}", PaymentReceived);

                Account a = AccountDL.getAccount(ClientId);
                decimal balance = -a.Balance;
                string value2 = String.Format("{0:N2}", balance);

                decimal totalMoneyOut = TranscationDL.getTotalMoneyOut(ClientId);
                string value3 = String.Format("{0:N2}", totalMoneyOut);

                lblPaymentReeived.Text = value1;

                lblPaymentRemaining.Text = value2;
                LBLClientName.Text = a.ClientName.ToString();
                lblClientId.Text = ClientId.ToString();
                lbltotalMoneyOut.Text = value3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error showing the data! " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRadioMoneyOut_CheckedChanged(object sender, EventArgs e)
        {
            bindHistory(ClientId, TransactionType.MoneyOut);
        }

        private void btnRadioMoneyIn_CheckedChanged(object sender, EventArgs e)
        {
            bindHistory(ClientId, TransactionType.MoneyIn);
        }

        private void btnRadioAll_CheckedChanged(object sender, EventArgs e)
        {
            bindHistory(ClientId);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Replace yourCancelColumnIndex with the actual column index.
                {
                    int TranscationId = Convert.ToInt32(dataGridView3.Rows[e.RowIndex].Cells["TranscationId"].Value);
                    Transaction t = TranscationDL.getTranscation(TranscationId);
                    if(t != null) 
                    {
                        if(t.Type == TransactionType.MoneyOut)
                        {
                            MoneyOut EditTranscation = new MoneyOut(ClientId,ClientName,t);
                            EditTranscation.cmbTranscationType.Enabled = true;
                            EditTranscation.cmbTranscationType.Text = "Money Out";
                            EditTranscation.Text = "Edit Money Out";
                            EditTranscation.btnConfirm.Text = "Confirm Changes";
                            EditTranscation.ShowDialog();
                            AccountDL.calculateBalance(ClientId);
                            bindHistory(ClientId);
                        }
                        else if(t.Type == TransactionType.MoneyIn)
                        {
                            MoneyOut EditTranscation = new MoneyOut(ClientId, ClientName,t);
                            EditTranscation.cmbTranscationType.Enabled = true;
                            EditTranscation.cmbTranscationType.Text = "Money In";
                            EditTranscation.Text = "Edit Money In";
                            EditTranscation.btnConfirm.Text = "Confirm Changes";
                            EditTranscation.ShowDialog();
                            AccountDL.calculateBalance(ClientId);
                            bindHistory(ClientId);
                        }
                    }


                }
                else
                {
                    DataGridViewCell cell = dataGridView3[e.ColumnIndex, e.RowIndex];
                    string cellValue = cell.Value.ToString();
                    MessageBox.Show(cellValue);

                }
            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
