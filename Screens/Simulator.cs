using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagement.Screens
{
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
        }

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            var amountRequest = decimal.Parse(amountTextBox.Text);
            var numMonths = int.Parse(monthsTextBox.Text);
            var anualInterestRate = decimal.Parse(rateTextBox.Text);
            var dateOfStar = loanDateStart.Value;

            decimal monthlyInterestRate = anualInterestRate / 12 / 100;
            decimal monthlyPaymentAmount = amountRequest / numMonths;
            decimal totalInrestRate = 0;
            decimal totalPayments = 0;

            dateOfStar.AddMonths(1);

            for (int i = 1; i <= numMonths; i++)
            {
                //Data
                ListViewItem newItem = new ListViewItem(dateOfStar.AddMonths(i).ToShortDateString());

                //Num Prestacao
                newItem.SubItems.Add(i.ToString());

                //Juros
                totalInrestRate += amountRequest * amountRequest;
                newItem.SubItems.Add(totalInrestRate.ToString());

                //Valor da prestacao
                decimal principal = monthlyPaymentAmount - totalInrestRate;
                newItem.SubItems.Add(principal.ToString());

                //Total
                totalPayments += principal + totalInrestRate;
                newItem.SubItems.Add(totalPayments.ToString());

                paymentsMapListView.Items.Add(newItem);

            }


        }
    }
}
