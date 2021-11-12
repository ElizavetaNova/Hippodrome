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
using System.Data.Entity;

namespace Hippodrome
{
    public partial class Logout : Form
    {
        int ClientIDLogout;
        public Logout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBoxAge.Text.ToString().Trim()[0] != '0') & (textBoxSurname.Text != "") & (textBoxName.Text != "") & (textBoxMidleName.Text != "") & (textBoxPhone.Text != "") & (textBoxAge.Text != ""))
            {
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {
                    connection.Open();
                    using (var command = new SqlCommand("insert into Client_table (ClientSurname, ClientName, ClientMiddleName, ClientAge, PhoneNumber) " +
                        "Values(@ClientSurname, @ClientName, @ClientMiddleName, @ClientAge, @PhoneNumber)", connection))
                    {
                        var c2 = new SqlCommand("SELECT MAX (IDENT_CURRENT('[Client_table]')) AS 'ClientID'", connection);
                        command.Parameters.AddWithValue("@ClientSurname", textBoxSurname.Text.Trim());
                        //command.Parameters.AddWithValue("@ClientID", ClientID);
                        command.Parameters.AddWithValue("@ClientName", textBoxName.Text.Trim());
                        command.Parameters.AddWithValue("@ClientMiddleName", textBoxMidleName.Text.Trim());
                        command.Parameters.AddWithValue("@ClientAge", textBoxAge.Text.Trim());
                        command.Parameters.AddWithValue("@PhoneNumber", textBoxPhone.Text.Trim());

                        try
                        {
                            using (var dataReader = command.ExecuteReader())
                            {
                                dataReader.Close();
                            }
                            
                            var clientIDLog = c2.ExecuteScalar();
                            clientIDLog = Int32.Parse(clientIDLog.ToString());
                            ClientIDLogout = (int)clientIDLog;
                            connection.Close();

                            Form form = new LogoutLoginPass(ClientIDLogout);
                            this.Close();
                            form.Show();
                        }
                        catch (SqlException)
                        {
                            MessageBox.Show("Неправильно введен номер телефона или ваш возраст менее 21 года");

                        }
                        connection.Close();
                    }
                }
            }
            else
                MessageBox.Show("Заполните все поля и введите корректно ваш возраст.");
            
        }

        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b')
            {
                e.Handled = true;
            }
        }

        private void textBoxAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
