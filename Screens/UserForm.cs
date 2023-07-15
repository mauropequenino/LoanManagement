using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanManagement.Models;
using LoanManagement.Repository;

namespace LoanManagement.Screens
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            LoadListView();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                var userName = userNameTextBox.Text.Replace(" ", "-").ToLower();
                var password = passwordTextBox.Text;
                var dateCreated = DateTime.UtcNow;
                var dateModidied = DateTime.UtcNow;

                Create(new User
                {
                    Name = userName,
                    Password = password,
                    DateCreated = dateCreated,
                    DateModified = dateModidied
                });
            }
        }

        private void Create(User user)
        {
            try
            {
                var repo = new Repository<User>(Database.Db.Conn);
                repo.Create(user);

                LoadListView();
                MessageBox.Show("Utilizador registado com sucesso", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao registar o utilizador. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isFormValid()
        {
            if (userNameTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, insira nome do utilizador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userNameTextBox.Focus();
                return false;
            }

            if (passwordTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, insira a palavra-passe!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return false;
            }

            return true;
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            userNameTextBox.Clear();
            passwordTextBox.Clear();
        }

        private void LoadListView()
        {
            usersListView.View = View.Details;
            usersListView.FullRowSelect = true;
            usersListView.Items.Clear();

            var repo = new Repository<User>(Database.Db.Conn);
            List<User> users = (List<User>)repo.Get();

            foreach (User user in users)
            {
                ListViewItem newItem = new ListViewItem(user.Name);
                newItem.SubItems.Add(user.Password);
                newItem.SubItems.Add(user.DateCreated.ToString());
                newItem.SubItems.Add(user.DateModified.ToString());

                usersListView.Items.Add(newItem);
            }

        }
    }
}