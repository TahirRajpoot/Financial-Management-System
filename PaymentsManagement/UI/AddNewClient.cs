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
    public partial class AddNewClient : MaterialForm
    {
        public Client previousClient;
        public AddNewClient(int ClientId,string action)
        {
            InitializeComponent();
            this.previousClient = ClientDL.getClient(ClientId);
            if(action == "Edit Client" && previousClient!= null)
            {
                materialButton1.Text = "Edit Client";
                txtName.Text = previousClient.Name;
                txtAddress.Text = previousClient.Address;
                txtPhoneNumber.Text = previousClient.PhoneNumber;
                cmbAccount.Text = previousClient.Type.ToString();

            }
        }

        private void AddNewClient_Load(object sender, EventArgs e)
        {
            cmbAccount.SelectedIndex = 1;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if(materialButton1.Text == "Add Client" || materialButton1.Text == "Add Bank Account")
                {
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string phoneNumber = txtPhoneNumber.Text;
                    string type = cmbAccount.Text;
            
                    if(name == "" )
                    {
                        MessageBox.Show("Kindly Enter Name of Client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Create a new Client object.
                    Client client = new Client(name, address, phoneNumber,type);

                    // Add the Client object to the list of clients.
                    if(ClientDL.addClientToList(client) && AccountDL.addAccountToList(new Account(client.UniqueId, client.Name,type)))
                    {
                        
                        MessageBox.Show("Client Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Client Not Added!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                else if(materialButton1.Text == "Edit Client")
                {
                    string name = txtName.Text;
                    string address = txtAddress.Text;
                    string phoneNumber = txtPhoneNumber.Text;
                    string type = cmbAccount.Text;

                    if (name == "")
                    {
                        MessageBox.Show("Kindly Enter Name of Client!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Create a new Client object.
                    Client client = new Client(name, address, phoneNumber,type);
                    client.UniqueId = previousClient.UniqueId;

                    bool result = ClientDL.updateClient(previousClient,client);
                    if (result == true)
                    {
                        //Account ca = new Account(client.Id, client.Name);
                        //ClientDL.clientAccount.Add(ca);
                        MessageBox.Show("Client Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Client Not Updated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch
            {
                MessageBox.Show("There was an error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel4_Click(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
