using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagement.Screens
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private bool isFormValid()
        {
            var msg = "Por favor, é obrigatório preencher este campo!";

            if (idTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idTxtBox.Focus();
                return false;
            }

            if (nameTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTxtBox.Focus();
                return false;
            }

            if (biTxtBox.Text.Trim() == string.Empty || biTxtBox.Text.Trim().Count() < 14)
            {
                MessageBox.Show("Nº de identificação inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                biTxtBox.Focus();
                return false;
            }

            if (provinceCmb.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                provinceCmb.Focus();
                return false;
            }

            if (addressTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addressTxtBox.Focus();
                return false;
            }

            if (genreCmb.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                genreCmb.Focus();
                return false;
            }

            if (professionTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                professionTxtBox.Focus();
                return false;
            }

            if (incomeTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                incomeTxtBox.Focus();
                return false;
            }

            if (statusCmb.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusCmb.Focus();
                return false;
            }

            if (phoneNumberTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneNumberTxtBox.Focus();
                return false;
            }

            if (emailTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTxtBox.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            idTxtBox.Clear();
            nameTxtBox.Clear();
            biTxtBox.Clear();
            addressTxtBox.Clear();
            professionTxtBox.Clear();
            incomeTxtBox.Clear();
            phoneNumberTxtBox.Clear();
            emailTxtBox.Clear();
            statusCmb.Items.Clear();
            provinceCmb.Items.Clear();
            genreCmb.Items.Clear();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                var clientName = nameTxtBox.Text;
                var bI = biTxtBox.Text;
                var province = provinceCmb.SelectedValue.ToString();
                var 
            }
        }
    }


}
