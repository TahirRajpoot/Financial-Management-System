using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class MoneyOut : MaterialForm
    {
        private int AccountId;
        private string ClientName;
        private Transaction previousTranscation;
        public MoneyOut(int AccountId,string ClientName)
        {
            InitializeComponent();
            this.AccountId = AccountId;
            this.ClientName= ClientName;
            this.MaximizeBox = false;
        }
        public MoneyOut(int AccountId, string ClientName,Transaction t)
        {
            InitializeComponent();
            this.AccountId = AccountId;
            this.ClientName = ClientName;
            this.previousTranscation = t;
            if(t!= null ) 
            {
                txtAmount.Text = t.Amount.ToString();
                txtAggrement.Text = t.Aggrement.ToString();
                txtDetails.Text = t.Details.ToString();
                dateTimePicker.Value = t.Date;
            }
        }

        private void MoneyOut_Load(object sender, EventArgs e)
        {
            txtAccountId.Text = AccountId.ToString();
            txtClientName.Text = ClientName;
            
            if(this.Text == "Money Out")
            {
                cmbTranscationType.Text = "Money Out";
            }
            else if (this.Text == "Money In")
            {
                cmbTranscationType.Text = "Money In";
            }
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                string Aggrement = txtAggrement.Text;
                string details = txtDetails.Text;

                if(txtAmount.Text == "")
                {
                    MessageBox.Show("Kindly Enter Amount! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DateTime dt = DateTime.Now;
                if(this.Text == "Money Out")
                {
                    if(AccountDL.MoneyOut(AccountId, amount, TransactionType.MoneyOut))
                    {
                        decimal remaining = AccountDL.getbalance(AccountId);
                        Transaction ts = new Transaction(AccountId, amount, -remaining,details, Aggrement, TransactionType.MoneyOut, dt);
                        if(TranscationDL.addTranscationToList(ts))
                        {
                            MessageBox.Show("Transcation Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }

                }

                else if (this.Text == "Money In")
                {
                    if (AccountDL.MoneyOut(AccountId, amount, TransactionType.MoneyIn))
                    {
                        decimal remaining = AccountDL.getbalance(AccountId);
                        Transaction ts = new Transaction(AccountId, amount, -remaining, details, Aggrement, TransactionType.MoneyIn, dt);
                        if (TranscationDL.addTranscationToList(ts))
                        {
                            MessageBox.Show("Transcation Successfull!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                }
                else if(this.Text == "Edit Money Out")
                {
                    string TranscationType = cmbTranscationType.Text;
                    if(TranscationType == "Money Out")
                    {   
                        decimal addition = amount - previousTranscation.Amount;
                        decimal remaining = previousTranscation.RemainingAmount + addition;                                                
                        Transaction newTranscation = new Transaction(previousTranscation.TranscationId,AccountId, amount, remaining, details, Aggrement, TransactionType.MoneyOut,dt);
                        
                        if(TranscationDL.EditMoneyOutTranscation(newTranscation,addition))
                        {
                            MessageBox.Show("Successfully Edited the Transcation with ID: " + previousTranscation.TranscationId.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else if(TranscationType == "Money In")
                    {
                        decimal minus = amount + previousTranscation.Amount;
                        decimal remaining = previousTranscation.RemainingAmount - minus;
                       
                        Transaction newTranscation = new Transaction(previousTranscation.TranscationId,AccountId, amount, remaining, details, Aggrement, TransactionType.MoneyIn, dt);
                        if(TranscationDL.EditMoneyOutTranscation(newTranscation, -minus))
                        {
                            MessageBox.Show("Successfully Edited the Transcation with ID: " + previousTranscation.TranscationId.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    
                }
                else if (this.Text == "Edit Money In")
                {
                    string TranscationType = cmbTranscationType.Text;
                    if (TranscationType == "Money In")
                    {
                        decimal reverseTranscation = previousTranscation.Amount + previousTranscation.RemainingAmount;

                        decimal remaining = reverseTranscation - amount;
                        decimal change = previousTranscation.RemainingAmount - remaining;
                        Transaction newTranscation = new Transaction(previousTranscation.TranscationId,AccountId, amount, remaining, details, Aggrement, TransactionType.MoneyIn, dt);
                        
                        if(TranscationDL.EditMoneyInTranscation(newTranscation, -change))
                        {
                            MessageBox.Show("Successfully Edited the Transcation with ID: " + previousTranscation.TranscationId.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        
                    }
                    else if (TranscationType == "Money Out")
                    {
                        decimal reverseTranscation = previousTranscation.Amount + previousTranscation.RemainingAmount;
                        decimal remaining = reverseTranscation + amount;
                        decimal change = previousTranscation.RemainingAmount - remaining;
                        Transaction newTranscation = new Transaction(previousTranscation.TranscationId,AccountId, amount, remaining, details, Aggrement, TransactionType.MoneyOut, dt);
                        if(TranscationDL.EditMoneyInTranscation(newTranscation, -change))
                        {
                            MessageBox.Show("Successfully Edited the Transcation with ID: " + previousTranscation.TranscationId.ToString(), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                       
                    }
                    
                }

            }
            catch (Exception z)
            {
                MessageBox.Show("There was an Error: "+z.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }


        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
