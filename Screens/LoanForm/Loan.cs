using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanManagement.Repository;

namespace LoanManagement.Screens.LoanForm
{
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void ClearFields()
        {
            idLoanTxtBox.Clear();
            idClientTxtBox.Clear();
            clientNameTxtBox.Clear();
            publicCheckBox.Checked = false;
            privateCheckBox.Checked = false;
            salaryTxtBox.Clear();
            creditAmountTxtBox.Clear();
            monthPaymentTxtBox.Clear();
            interestRateTxtBox.Clear();
            termMontthsTxtBox.Clear();
            describePurposeTxtBox.Clear();
            dateStartDateTimePicker.Value = dateStartDateTimePicker.MinDate;
            accountNumberTxtBox.Clear();
            accouuntNibTxtBox.Clear();
            bankNameTxtBox.Clear();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void simulatorBtn_Click(object sender, EventArgs e)
        {
            new Simulator().ShowDialog();
        }



        private void searchIdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var id = int.Parse(idClientTxtBox.Text);

                var repo = new ClientRepository(Database.Db.Conn);
                var client = repo.Get(id);

                if (client == null)
                {
                    MessageBox.Show("O cliente não foi encontado!", "Não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clientNameTxtBox.Text = client.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }



}
