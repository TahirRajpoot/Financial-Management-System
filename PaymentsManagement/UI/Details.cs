using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using PaymentsManagement.DL;

namespace PaymentsManagement.UI
{
    public partial class Details : MaterialForm
    {
        public Details()
        {
            InitializeComponent();
        }

        private void Details_Load(object sender, EventArgs e)
        {
            bindData();
            

        }
        public void PopulateDataGridView(List<Transaction> transactions, int month, int year, List<int> clientIds)
        {
            // Filter transactions for the specified month and year
            transactions = transactions.Where(t => t.Date.Month == month && t.Date.Year == year ).ToList();

            // Group transactions by date and calculate totals including remaining money
            var groupedTransactions = transactions.GroupBy(t => t.Date.Date)
                                                 .Select(g => new
                                                 {
                                                     Date = g.Key,
                                                     TotalMoneyOut = g.Sum(t => t.MoneyOut),
                                                     TotalMoneyIn = g.Sum(t => t.MoneyIn),
                                                     RemainingMoney = g.Sum(t => t.MoneyOut) - g.Sum(t => t.MoneyIn)
                                                 });

            // Create DataTable and add columns
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Date", typeof(DateTime));
            dataTable.Columns.Add("TotalMoneyOut", typeof(decimal));
            dataTable.Columns.Add("TotalMoneyIn", typeof(decimal));
            dataTable.Columns.Add("RemainingMoney", typeof(decimal));

            // Populate DataTable with grouped data
            foreach (var group in groupedTransactions)
            {
                dataTable.Rows.Add(group.Date, group.TotalMoneyOut, group.TotalMoneyIn, group.RemainingMoney);
            }

            // Bind DataTable to existing DataGridView
            DetailsGV.DataSource = dataTable;
        }

        public void bindData()
        {
            DateTime dt = dateTimePicker1.Value;
            if(this.Text == "Client Details") 
            {                
                decimal totalMoneyOut = TranscationDL.getTotalMoneyOutByDate(dt);
                Console.WriteLine("Money Out client "+ totalMoneyOut);
                string value1 = String.Format("{0:N2}", totalMoneyOut);

                decimal totalMoneyIn = TranscationDL.getTotalMoneyInByDate("Client",dt);
                string value2 = String.Format("{0:N2}", totalMoneyIn);            
                lblTotalMoneyOut.Text = value1;
                lblTotalMoneyIn.Text = value2;            

            }
            else if (this.Text == "Bank Account Details")
            {
                decimal totalMoneyOutBank = TranscationDL.getTotalMoneyOutBankByDate(dt);
                string MoneyOutBank = String.Format("{0:N2}", totalMoneyOutBank);

                decimal totalMoneyInBank = TranscationDL.getTotalMoneyInByDate("Bank Account",dt);
                string MoneyInBank = String.Format("{0:N2}", totalMoneyInBank);                
                lblTotalMoneyOut.Text = MoneyOutBank;
                lblTotalMoneyIn.Text = MoneyInBank;
                
            }

            if (this.Text == "Client Details")
            {
                PopulateDataGridView(TranscationDL.getTranscationByAccountType("Client"), dateTimePicker1.Value.Month, dateTimePicker1.Value.Year, ClientDL.getAccountIds("Client"));
            }
            else if (this.Text == "Bank Account Details")
            {
                PopulateDataGridView(TranscationDL.getTranscationByAccountType("Bank Account"), dateTimePicker1.Value.Month, dateTimePicker1.Value.Year, ClientDL.getAccountIds("Bank Account"));

            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            bindData();
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
