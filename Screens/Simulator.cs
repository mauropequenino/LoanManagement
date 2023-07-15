using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

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
            var amountRequest = double.Parse(amountTextBox.Text);
            var numMonths = int.Parse(monthsTextBox.Text);
            var anualInterestRate = double.Parse(rateTextBox.Text);
            var dateOfStart = loanDateStart.Value;

            var monthlyInterestRate = anualInterestRate / 12 / 100;
            var monthlyPaymentAmount = (amountRequest * monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), numMonths)) / (Math.Pow((1 + monthlyInterestRate), numMonths) - 1);
            var totalInrestRate = 0.00;
            var totalPayments = 0.00;
            var principal = 0.00;
            dateOfStart.AddMonths(1);


            for (int i = 1; i <= numMonths; i++)
            {
                //Data
                ListViewItem newItem = new ListViewItem(dateOfStart.AddMonths(i).ToShortDateString());

                //Num Prestacao
                newItem.SubItems.Add(i.ToString());

                //Juros
                totalInrestRate += monthlyPaymentAmount * monthlyInterestRate;
                newItem.SubItems.Add(totalInrestRate.ToString("N2"));

                //Valor da prestacao
                principal = monthlyPaymentAmount;
                newItem.SubItems.Add(principal.ToString("N2"));

                //Total
                totalPayments += principal;
                newItem.SubItems.Add(totalPayments.ToString("N2"));

                paymentsMapListView.Items.Add(newItem);
            }

            //Coluna de detalhes
            monthlyPaymentTextBox.Text = monthlyPaymentAmount.ToString("N2");
            rateTextBox2.Text = anualInterestRate.ToString("P");
            totalRateTextBox.Text = totalInrestRate.ToString("N2");
            totalPayTextBox.Text = totalPayments.ToString("N2");
            dateEnd.Value = dateOfStart.AddMonths(numMonths);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            paymentsMapListView.Clear();
            amountTextBox.Clear();
            monthsTextBox.Clear();
            rateTextBox.Clear();
            loanDateStart.Value = DateTime.Now;
            monthlyPaymentTextBox.Clear();
            rateTextBox2.Clear();
            totalRateTextBox.Clear();
            totalPayTextBox.Clear();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
