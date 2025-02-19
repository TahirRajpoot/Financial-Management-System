using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MongoDB.Driver;
using MongoDB.Bson;
using PaymentsManagement.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Net.Mail;
using System.Net;
using PaymentsManagement.UI;

namespace PaymentsManagement
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager = null;


        public Form1()
        {
            InitializeComponent();

            

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE
            );
            
        }
        public void bindData()
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.Rows.Clear();
            

                dataGridView1.DataSource = null;
                BindingSource bindingSource = new BindingSource();            
                bindingSource.DataSource = ClientDL.getClientList();
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns["ObjectId"].Visible = false;

                BindingSource bindingSource2 = new BindingSource();
                bindingSource2.DataSource = AccountDL.getClientAccounts();
                dataGridView2.DataSource = bindingSource2;
                dataGridView2.Columns["ObjectId"].Visible = false;

                BindingSource bindingSource3 = new BindingSource();
                bindingSource3.DataSource = AccountDL.getBankAndPersonalAccounts();
                BankAccountsGV.DataSource = bindingSource3;
                BankAccountsGV.Columns["ObjectId"].Visible = false;
            }
            catch (Exception z)
            {
                MessageBox.Show("An error occurred showing the data! " +z.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
                
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                
                string msg = ClientDL.loadClientsFromDatabase();
                string msg2 = TranscationDL.loadTranscationsFromDatabase();
                string msg3 = AccountDL.loadAccountsFromDatabase();
                
                if(msg == "Error" || msg2 == "Error" || msg3 == "Error")
                {
                    MessageBox.Show("An error occurred while Connecting With Database. " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(msg  == "Successful")
                {
                    MessageBox.Show("Successfully Connected to the Database ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BindHomeData();
                
                try
                {
                    MailMessage mm = new MailMessage();
                    SmtpClient sc = new SmtpClient("smtp.gmail.com");
                    mm.From = new MailAddress("trajpoot2002@gmail.com");
                    mm.To.Add("ranat5177@gmail.com");
                    mm.Subject = "Email Verification";
                    mm.Body = "Toke is: 123789";
                    sc.Port = 587;
                    sc.Credentials = new System.Net.NetworkCredential("trajpoot2002@gmail.com", "");
                    sc.EnableSsl = true;
                    //sc.Send(mm);
                    //MessageBox.Show("Email has been sent.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception z)
            {
                MessageBox.Show("An error occurred while Connecting With Database. Make sure you have an active internet connection." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            
            bindData();            
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor =Color.FromArgb(33, 150, 243);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView2.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridView2.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView2.BackgroundColor = Color.White;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            BankAccountsGV.BorderStyle = BorderStyle.None;
            BankAccountsGV.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            BankAccountsGV.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            BankAccountsGV.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            BankAccountsGV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            BankAccountsGV.BackgroundColor = Color.White;

            BankAccountsGV.EnableHeadersVisualStyles = false;
            BankAccountsGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            BankAccountsGV.ColumnHeadersDefaultCellStyle.BackColor = Color.DeepSkyBlue;
            BankAccountsGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            // Resize the DataGridView to fill the available space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialMaskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text;
                bool flag = false;
                if (searchText != "")
                {

                    dataGridView1.DataSource = null;
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = ClientDL.searchClient(searchText.ToLower());
                    dataGridView1.Columns["ObjectId"].Visible = false;


                }
                else
                {
                    bindData();
                }
            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewClient anc = new AddNewClient(0,"Add Client");
                anc.ShowDialog();
                bindData();

            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            try
            {

                string searchText = txtSearch.Text.ToLower();
                
                if (searchText.Length > 0 )
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        // Iterate over all the cells in the row.
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // If the cell contains the search text, highlight the cell.
                            if (cell.Value.ToString().ToLower().Contains(searchText))
                            {
                                cell.Style.BackColor = Color.SkyBlue;
                            }
                        }
                    }

                }
                else
                {
                    bindData();
                }
            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Iterate over all the rows in the DataGridView.
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Replace yourCancelColumnIndex with the actual column index.
                {
                    int AccountId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = dataGridView2.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    History hs = new History(AccountId, ClientName);
                    hs.ShowDialog();
                    bindData();
                    string currentSearch = searchAccount.Text.ToString();
                    searchAccount.Text = "";
                    searchAccount.Text = currentSearch;


                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    int AccountId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = dataGridView2.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    MoneyOut mo = new MoneyOut(AccountId, ClientName);
                    mo.ShowDialog();
                    bindData();
                    string currentSearch = searchAccount.Text.ToString();
                    searchAccount.Text = "";
                    searchAccount.Text = currentSearch;
                }
                else if(e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    int AccountId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = dataGridView2.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    MoneyOut mo = new MoneyOut(AccountId, ClientName);
                    mo.Text = "Money In";

                    mo.ShowDialog();
                    bindData();
                    string currentSearch = searchAccount.Text.ToString();
                    searchAccount.Text = "";
                    searchAccount.Text = currentSearch;
                }
                else
                {
                    DataGridViewCell cell = dataGridView2[e.ColumnIndex, e.RowIndex];
                    string cellValue = cell.Value.ToString();
                    MessageBox.Show(cellValue);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialTabControl1_Leave(object sender, EventArgs e)
        {
            
        }

        private void cmbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtSearch.TabIndex = dataGridView1.TabIndex + 1;
            try
            {
                bool personal = false;
                bool all = false;
                bool bankAccount = false;
                if (btnRadioMoneyIn.Checked)
                {
                    personal = true;
                }
                else if (btnRadioAll.Checked) 
                {
                    bankAccount = true;
                }
                else if(btnRadioMoneyOut.Checked) 
                {
                    all = true;
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Replace yourCancelColumnIndex with the actual column index.
                {
                    int ClientId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UniqueId"].Value);
                    string ClientName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    AddNewClient anc = new AddNewClient(ClientId,"Edit Client");
                    anc.Text = "Edit Client";
                    anc.ShowDialog();
                    bindData();
                    if(personal)
                    {
                        btnRadioMoneyIn.Checked = false;
                        btnRadioMoneyIn.Checked = true;
                        
                    }
                    else if (bankAccount)
                    {
                        btnRadioAll.Checked = false;
                        btnRadioAll.Checked = true;

                    }
                    else if (all)
                    {
                        btnRadioMoneyOut.Checked = false;
                        btnRadioMoneyOut.Checked = true;

                    }



                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 1) // Replace yourCancelColumnIndex with the actual column index.
                {
                    int ClientId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["UniqueId"].Value);
                    string ClientName = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                    DialogResult result = MessageBox.Show("Are you sure you want to delete "+ClientName + "'s Account?", "Delete Account", MessageBoxButtons.OKCancel);

                    if (result == DialogResult.OK)
                    {
                        ClientDL.deleteClient(ClientId);
                        AccountDL.deleteAccount(ClientId);
                        TranscationDL.DeleteTransactionsByClientId(ClientId);
                        MessageBox.Show("Successfully Deleted " + ClientName+"'s Account" , "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bindData();
                    }                    


                }
                else if (e.ColumnIndex != 0 && e.ColumnIndex != 1)
                {
                    DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    string cellValue = cell.Value.ToString();
                    MessageBox.Show(cellValue);
                    
                }
                if (personal)
                {
                    btnRadioMoneyIn.Checked = false;
                    btnRadioMoneyIn.Checked = true;

                }
                else if (bankAccount)
                {
                    btnRadioAll.Checked = false;
                    btnRadioAll.Checked = true;

                }
                else if (all)
                {
                    btnRadioMoneyOut.Checked = false;
                    btnRadioMoneyOut.Checked = true;

                }
            }
            catch(Exception z)
            {
                MessageBox.Show("Exception: " + z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void searchAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = searchAccount.Text;
                bool flag = false;
                if (searchText != "")
                {

                    dataGridView2.DataSource = null;
                    dataGridView2.Refresh();
                    dataGridView2.DataSource = AccountDL.searchAccount(searchText.ToLower());
                    dataGridView2.Columns["ObjectId"].Visible = false;


                }
                else
                {
                    //bindData();
                }
            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            string searchText = searchAccount.Text.ToLower();
            

            if (searchText.Length > 0)
            {
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    // Iterate over all the cells in the row.
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // If the cell contains the search text, highlight the cell.
                        if (cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            cell.Style.BackColor = Color.SkyBlue;
                        }
                    }
                }

            }
            else
            {
                bindData();
            }
        }

        private void materialTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Home_Click(object sender, EventArgs e)
        {
            
               
            
        }
        public void BindHomeData()
        {
            try
            {
                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.CurrencySymbol = "Rs ";
                decimal totalMoneyOut = TranscationDL.getTotalMoneyOutByDate(DateTime.Now);
                string value1 = String.Format("{0:N2}", totalMoneyOut);

                decimal totalMoneyIn = TranscationDL.getTotalMoneyIn("Client");
                string value2 = String.Format("{0:N2}", totalMoneyIn);

                decimal totalMoneyRemaining = totalMoneyOut - totalMoneyIn;
                string value3 = String.Format("{0:N2}", totalMoneyRemaining);

                lblTotalMoneyOut.Text = value1;
                lblTotalMoneyIn.Text = value2;
                lblTotalMoneyRemaining.Text = value3;

                
                decimal totalMoneyOutPersonal = TranscationDL.getTotalMoneyOutPersonal();
                string MoneyOutPersonal = String.Format("{0:N2}", totalMoneyOutPersonal);

                decimal totalMoneyInPersonal = TranscationDL.getTotalMoneyIn("Personal");
                string MoneyInPersonal = String.Format("{0:N2}", totalMoneyInPersonal);

                decimal totalMoneyRemainingPersonal = totalMoneyOutPersonal - totalMoneyInPersonal;
                string TotalRemainingPersonal = String.Format("{0:N2}", totalMoneyRemainingPersonal);

                lblTotalMoneyOutPersonal.Text = MoneyOutPersonal;
                lblTotalMoneyInPersonal.Text = MoneyInPersonal;
                lblTotalMoneyRemainingPersonal.Text = TotalRemainingPersonal;


                decimal totalMoneyOutBank = TranscationDL.getTotalMoneyOutBank();
                string MoneyOutBank = String.Format("{0:N2}", totalMoneyOutBank);

                decimal totalMoneyInBank = TranscationDL.getTotalMoneyIn("Bank Account");
                string MoneyInBank = String.Format("{0:N2}", totalMoneyInBank);

                decimal totalMoneyRemainingBank = totalMoneyOutBank - totalMoneyInBank;
                string TotalRemainingBank = String.Format("{0:N2}", totalMoneyRemainingBank);

                lblTotalMoneyOutBank.Text = MoneyOutBank;
                lblTotalMoneyInBank.Text = MoneyInBank;
                lblTotalMoneyRemainingBank.Text = TotalRemainingBank;

            }
            catch (Exception z)
            {
                MessageBox.Show("Exception: " + z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedTabIndex = materialTabControl1.SelectedIndex;
                if(selectedTabIndex == 0)
                {
                    BindHomeData();
                }
                else if(selectedTabIndex == 3)
                {
                    bindData();
                }
                
            }
            catch(Exception z)
            {
                MessageBox.Show("Exception: " + z.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void lblTotalMoneyRemaining_Click(object sender, EventArgs e)
        {

        }

        private void BankAccountsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnAddBankAccount_Click(object sender, EventArgs e)
        {
            try
            {
                AddNewClient anc = new AddNewClient(0,"Add Bank Account");
                anc.materialButton1.Text = "Add Bank Account";                
                anc.Text = "Add Bank Account";                                
                anc.ShowDialog();
                bindData();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BankAccountsGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string currentSearch = txtSearchBankAccount.Text.ToString();
                bool personal = false;
                bool all = false;
                bool bankAccount = false;
                if (materialRadioButton1.Checked)
                {
                    personal = true;
                }
                else if (materialRadioButton2.Checked)
                {
                    bankAccount = true;
                }
                else if (materialRadioButton3.Checked)
                {
                    all = true;
                }
                if (e.RowIndex >= 0 && e.ColumnIndex == 0) // Replace yourCancelColumnIndex with the actual column index.
                {
                    int AccountId = Convert.ToInt32(BankAccountsGV.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = BankAccountsGV.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    History hs = new History(AccountId, ClientName);
                    hs.ShowDialog();
                    bindData();
                    


                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 1)
                {
                    int AccountId = Convert.ToInt32(BankAccountsGV.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = BankAccountsGV.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    MoneyOut mo = new MoneyOut(AccountId, ClientName);
                    mo.ShowDialog();
                    bindData();
                                       
                }
                else if (e.RowIndex >= 0 && e.ColumnIndex == 2)
                {
                    int AccountId = Convert.ToInt32(BankAccountsGV.Rows[e.RowIndex].Cells["ClientId"].Value);
                    string ClientName = BankAccountsGV.Rows[e.RowIndex].Cells["ClientName"].Value.ToString();

                    MoneyOut mo = new MoneyOut(AccountId, ClientName);
                    mo.Text = "Money In";

                    mo.ShowDialog();
                    bindData();
                    
                }
                else
                {
                    DataGridViewCell cell = BankAccountsGV[e.ColumnIndex, e.RowIndex];
                    string cellValue = cell.Value.ToString();
                    MessageBox.Show(cellValue);
                }
                if (personal)
                {
                    materialRadioButton1.Checked = false;
                    materialRadioButton1.Checked = true;

                }
                else if (bankAccount)
                {
                    materialRadioButton2.Checked = false;
                    materialRadioButton2.Checked = true;

                }
                else if (all)
                {
                    materialRadioButton3.Checked = false;
                    materialRadioButton3.Checked = true;

                }
                txtSearchBankAccount.Text = "";
                txtSearchBankAccount.Text = currentSearch;

            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an Error " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRadioMoneyIn_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ClientDL.getPersonalAccounts() ;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["ObjectId"].Visible = false;
        }

        private void btnRadioMoneyOut_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ClientDL.getClientList();
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["ObjectId"].Visible = false;
        }

        private void btnRadioAll_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = ClientDL.getBanks();
            dataGridView1.DataSource = bindingSource;
            dataGridView1.Columns["ObjectId"].Visible = false;
        }

        private void txtSearchBankAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBankAccount.Text;
                
                if (searchText != "")
                {

                    BankAccountsGV.DataSource = null;
                    BankAccountsGV.Refresh();
                    BankAccountsGV.DataSource = AccountDL.searchBankPersonalAccount(searchText.ToLower());
                    BankAccountsGV.Columns["ObjectId"].Visible = false;
                }
                else
                {
                    bindData();
                }
            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBankAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchBankAccount_Click(object sender, EventArgs e)
        {
            string searchText = txtSearchBankAccount.Text.ToLower();
            

            if (searchText.Length > 0)
            {
                foreach (DataGridViewRow row in BankAccountsGV.Rows)
                {
                    // Iterate over all the cells in the row.
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // If the cell contains the search text, highlight the cell.
                        if (cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            cell.Style.BackColor = Color.SkyBlue;
                        }
                    }
                }

            }
            else
            {
                bindData();
            }
        }

        private void materialTabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void btnRadioAll_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void btnRadioMoneyIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void btnRadioMoneyOut_KeyPress(object sender, KeyPressEventArgs e)
        {
                        
            
        }

        private void materialButton1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
                
        }

        private void materialButton2_KeyDown(object sender, KeyEventArgs e)
        {
            
            
        }

        private void materialTabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void btnRadioAll_KeyDown(object sender, KeyEventArgs e)
        {
            txtSearch.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Details ds = new Details();
            ds.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Details ds = new Details();
            ds.Text = "Bank Account Details";
            ds.ShowDialog();
        }

        private void btnResetClient_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure you want to Reset All Clients Data? " , "Reset Client's Data", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    MessageBox.Show("It Will Take Some Time...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TranscationDL.resetAllClientsTranscations();                  
                    MessageBox.Show("Successfully Cleared All Client's Data. Please Restart The Application! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }


            }
            catch
            {
                MessageBox.Show("Exception", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchBankAccount.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = AccountDL.getPersonalAccounts();
            BankAccountsGV.DataSource = bindingSource;
            BankAccountsGV.Columns["ObjectId"].Visible = false;
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchBankAccount.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = AccountDL.getBankAccounts();
            BankAccountsGV.DataSource = bindingSource;
            BankAccountsGV.Columns["ObjectId"].Visible = false;
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtSearchBankAccount.Text = "";
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = AccountDL.getBankAndPersonalAccounts();
            BankAccountsGV.DataSource = bindingSource;
            BankAccountsGV.Columns["ObjectId"].Visible = false;
        }
    }
    
}
