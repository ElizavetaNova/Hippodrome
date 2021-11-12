using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hippodrome
{
    public partial class LogoutLoginPass : Form
    {
        int ClientID;
        public LogoutLoginPass()
        {
            //InitializeComponent();
        }
        public LogoutLoginPass(int IDClient)
        {
            InitializeComponent();
            this.ClientID = IDClient;
        }

        private void buttonRegist_Click(object sender, EventArgs e)
        {
            if ((textBoxLogin.Text != "") && (textBoxPassword.Text != "") && (textBoxPassword2.Text != "") && (textBoxPassword.Text == textBoxPassword2.Text))
            {
                string login = textBoxLogin.Text;
                string password = textBoxPassword.Text;
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {
                    connection.Open();
                    using (var command = new SqlCommand("insert into Users ([Login], [Password], [Role], ClientID) Values (@Login, @password, 2, @ClientID)", connection))
                    {
                        
                        command.Parameters.AddWithValue("@ClientID", ClientID);
                        command.Parameters.AddWithValue("@Login", login);                        
                        command.Parameters.AddWithValue("@password", password);
                        try
                        {
                            using (var dataReader = command.ExecuteReader())
                            {
                                dataReader.Close();
                            }

                            
                            Form form = new Account(login);
                            this.Close();
                            form.Show();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");

                        }
                    }
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Заполнены не все поля или пароль подтвержден не верно");
        }
    }
}
