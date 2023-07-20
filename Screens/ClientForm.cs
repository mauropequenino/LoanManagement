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
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private bool isFormValid()
        {
            if (idTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, insira nome do utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                idTxtBox.Focus();
                return false;
            }

            if (nameTxtBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, insira a palavra-passe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nameTxtBox.Focus();
                return false;
            }

            if (biTxtBox.Text.Trim().Count() < 14)
            {
                MessageBox.Show("Nº de identificação inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                biTxtBox.Focus();
                return false;
            }

            if (provinceCmb.SelectedValue.ToString() == string.Empty)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                biTxtBox.Focus();
                return false;
            }


            if (addressTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addressTxtBox.Focus();
                return false;
            }


            if (professionTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                biTxtBox.Focus();
                return false;
            }


            if (professionTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                professionTxtBox.Focus();
                return false;
            }

            if (incomeTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                incomeTxtBox.Focus();
                return false;
            }

            if (incomeTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                incomeTxtBox.Focus();
                return false;
            }

            if (phoneNumberTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                phoneNumberTxtBox.Focus();
                return false;
            }

            if (emailTxtBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTxtBox.Focus();
                return false;
            }

            return true;
        }
    }


}
