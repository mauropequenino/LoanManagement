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
using LoanManagement.Models;
using LoanManagement.Repository;

namespace LoanManagement.Screens
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
            LoadListView();
        }

        private void LoadListView()
        {

        }

        private bool isFormValid()
        {
            var msg = "Por favor, é obrigatório preencher todos os campos!";

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

            if (addressTxtBox.Text == string.Empty)
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

            if (professionTxtBox.Text == string.Empty)
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
                var genre = char.Parse(genreCmb.SelectedValue.ToString());
                var birthDate = DateTime.Parse(birthDatePicker.Value.ToString());
                var address = addressTxtBox.Text;
                var profession = professionTxtBox.Text;
                var income = decimal.Parse(incomeTxtBox.Text.Trim());
                var phoneNumber = phoneNumberTxtBox.Text.Trim();
                var email = professionTxtBox.Text.Trim();

                Create(new Client
                {
                    Name = clientName,
                    Bi = bI,
                    Province = province,
                    Address = address,
                    BirthDate = birthDate,
                    Genre = genre,
                    Profession = profession,
                    Income = income,
                    PhoneNumber = phoneNumber,
                    Email = email
                });
            }
        }

        private void Create(Client client)
        {
            try
            {
                var repo = new Repository<Client>(Database.Db.Conn);
                repo.Create(client);

                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao registar o cliente. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja remover o cliente ?", "Remover", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    /*
                    if (usersListView.SelectedItems.Count > 0)
                    {
                        var repo = new Repository<Client>(Database.Db.Conn);
                        var client = repo.Get(id);

                        if (client != null)
                        {
                            repo.Delete(client);
                            LoadListView();
                        }
                    }
                    */
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao remover o cliente. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


}
