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

            clientListView.View = View.Details;
            clientListView.FullRowSelect = true;
            clientListView.Items.Clear();

            var repo = new Repository<Client>(Database.Db.Conn);
            var clients = repo.Get();

            foreach (var client in clients)
            {
                ListViewItem newItem = new ListViewItem(client.Id.ToString());
                newItem.SubItems.Add(client.Name);
                newItem.SubItems.Add(client.Bi);
                newItem.SubItems.Add(client.Province);
                newItem.SubItems.Add(client.Genre.ToString());
                newItem.SubItems.Add(client.BirthDate.ToString());
                newItem.SubItems.Add(client.Address);
                newItem.SubItems.Add(client.Profession);
                newItem.SubItems.Add(client.Income.ToString("F2"));
                newItem.SubItems.Add(client.PhoneNumber);
                newItem.SubItems.Add(client.Email);

                clientListView.Items.Add(newItem);
            }

        }

        private bool isFormValid()
        {
            var msg = "Por favor, é obrigatório preencher todos os campos!";

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

            if (addressTxtBox.Text == string.Empty)
            {
                MessageBox.Show(msg, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addressTxtBox.Focus();
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

        }



        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                var clientName = nameTxtBox.Text;
                var bI = biTxtBox.Text;
                var province = provinceCmb.SelectedItem.ToString();
                var genre = char.Parse(genreCmb.SelectedItem.ToString());
                var birthDate = DateTime.Parse(birthDatePicker.Value.ToString());
                var address = addressTxtBox.Text;
                var profession = professionTxtBox.Text;
                var income = decimal.Parse(incomeTxtBox.Text.Trim());
                var phoneNumber = phoneNumberTxtBox.Text.Trim();
                var email = emailTxtBox.Text.Trim();

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
            if (MessageBox.Show("Deseja remover este cliente ?", "Remover", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {

                    if (clientListView.SelectedItems.Count > 0)
                    {
                        var id = int.Parse(clientListView.SelectedItems[0].SubItems[0].Text);
                        var repo = new Repository<Client>(Database.Db.Conn);
                        var client = repo.Get(id);

                        if (client != null)
                        {
                            repo.Delete(client);
                            LoadListView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao remover o cliente. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clientListView_MouseClick(object sender, MouseEventArgs e)
        {
            idTxtBox.Text = clientListView.SelectedItems[0].SubItems[0].Text;
            nameTxtBox.Text = clientListView.SelectedItems[0].SubItems[1].Text;
            biTxtBox.Text = clientListView.SelectedItems[0].SubItems[2].Text;
            provinceCmb.Items.Add(clientListView.SelectedItems[0].SubItems[3].Text);
            genreCmb.Items.Add(clientListView.SelectedItems[0].SubItems[4].Text);
            birthDatePicker.Value = DateTime.Parse(clientListView.SelectedItems[0].SubItems[5].Text);
            addressTxtBox.Text = clientListView.SelectedItems[0].SubItems[6].Text;
            professionTxtBox.Text = clientListView.SelectedItems[0].SubItems[7].Text;
            incomeTxtBox.Text = clientListView.SelectedItems[0].SubItems[8].Text;
            phoneNumberTxtBox.Text = clientListView.SelectedItems[0].SubItems[9].Text;
            emailTxtBox.Text = clientListView.SelectedItems[0].SubItems[10].Text;
        }
    }


}
