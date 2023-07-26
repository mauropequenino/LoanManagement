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
        private int id;
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
                var dateModified = DateTime.UtcNow;

                Create(new User
                {
                    Name = userName,
                    Password = password,
                    DateCreated = dateCreated,
                    DateModified = dateModified
                });
            }
        }

        private void Create(User user)
        {
            try
            {
                var repo = new UserRepository(Database.Db.Conn);
                repo.Create(user);

                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao registar o utilizador. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja remover o utilizador ?", "Remover", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    if (usersListView.SelectedItems.Count > 0)
                    {
                        var repo = new UserRepository(Database.Db.Conn);
                        var user = repo.Get(id);

                        if (user != null)
                        {
                            repo.Delete(user);
                            LoadListView();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao remover o utilizador. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void usersListView_MouseClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt16(usersListView.SelectedItems[0].SubItems[0].Text);
            userNameTextBox.Text = usersListView.SelectedItems[0].SubItems[1].Text;
            passwordTextBox.Text = usersListView.SelectedItems[0].SubItems[2].Text;
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                var userName = userNameTextBox.Text.Replace(" ", "-").ToLower();
                var password = passwordTextBox.Text;
                var dateModified = DateTime.UtcNow;

                Update(new User
                {
                    Id = id,
                    Name = userName,
                    Password = password,
                    DateModified = dateModified
                });
            }
        }

        private void Update(User user)
        {
            try
            {
                var repo = new UserRepository(Database.Db.Conn);
                repo.Update(user);

                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao registar o utilizador. Detalhes do erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadListView()
        {
            ClearFields();
            usersListView.View = View.Details;
            usersListView.FullRowSelect = true;
            usersListView.Items.Clear();

            var repo = new UserRepository(Database.Db.Conn);
            var users = repo.Get();

            foreach (User user in users)
            {
                ListViewItem newItem = new ListViewItem(user.Id.ToString());
                newItem.SubItems.Add(user.Name);
                newItem.SubItems.Add(user.Password);
                newItem.SubItems.Add(user.DateCreated.ToString());
                newItem.SubItems.Add(user.DateModified.ToString());

                usersListView.Items.Add(newItem);
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
            else if (passwordTextBox.Text.Trim().Count() < 5)
            {
                MessageBox.Show("A palavra-passe deve posuuir no minimo de 6 caracteres", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextBox.Focus();
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            userNameTextBox.Clear();
            passwordTextBox.Clear();
        }
    }
}