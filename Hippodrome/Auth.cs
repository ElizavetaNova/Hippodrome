using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome
{
    
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }

        enum Role { Admin, Client, Fall}

        static Role GetRole(string login, string password)
        {
            Role role = Role.Fall;
            using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
            {
                connection.Open();
                var command = new SqlCommand("Select [Role] From Users WHERE login=@login AND password=@password", connection);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                using (var dataReader = command.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        switch ((int)dataReader["Role"])
                        {
                            case 2: role = Role.Client; break;
                            case 1: role = Role.Admin; break;
                        }
                    }
                }
                connection.Close();
            }
            return role;
        }
        private void login()
        {
            Role role = GetRole(textBoxLogin.Text, textBoxPassword.Text);
            if (role == Role.Fall)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
            else
            {
                if (role == Role.Admin)
                {
                    this.Hide();
                    var form = new Admin(textBoxLogin.Text.Trim());
                    form.ShowDialog();
                }
                else if (role == Role.Client)
                {
                    this.Hide();
                    var form = new Account(textBoxLogin.Text.Trim());
                    form.ShowDialog();
                }
            }
        }

        private void Registr_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Logout();
            form.ShowDialog();
        }
    }
}
