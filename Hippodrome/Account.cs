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
    public partial class Account : Form
    {
        string loginClient;
        string passwordClient;
        int ClientID;
        public Account()
        {
            
        }

        public Account(string login)
        {
            InitializeComponent();
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            
            buttonSave.Visible = false;
            //AccountMoney.Text = String.Format("{0:f2}");

            using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Users.[Login], Users.[Password], Client_table.ClientSurname, Client_table.ClientName, Client_table.ClientMiddleName, Client_table.ClientAge, Client_table.PhoneNumber, Client_table.AccountMoney, Client_table.ClientBetCount,Client_table.ClientWinCount, Client_table.ClientWinSum, Users.ClientID FROM [Users] INNER JOIN [Client_table] ON Users.ClientID = Client_table.ClientID WHERE Users.[Login] = @login", connection);
                command.Parameters.AddWithValue("@login", login);


                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        textBoxlogin.Text = dataReader.GetValue(0).ToString().Trim();
                        textBoxPassword.Text = dataReader.GetValue(1).ToString().Trim();
                        textBoxSurname.Text = dataReader.GetValue(2).ToString().Trim();
                        textBoxName.Text = dataReader.GetValue(3).ToString().Trim();
                        textBoxMidleName.Text = dataReader.GetValue(4).ToString().Trim();
                        textBoxAge.Text = dataReader.GetInt32(5).ToString().Trim();
                        textBoxPhone.Text = dataReader.GetValue(6).ToString().Trim();
                        AccountMoney.Text = dataReader.GetValue(7).ToString().Trim();                        
                        BetCount.Text = dataReader.GetValue(8).ToString().Trim();
                        BetWinCount.Text = dataReader.GetValue(9).ToString().Trim();
                        SumWin.Text = dataReader.GetSqlMoney(10).ToString().Trim();
                        ClientID = dataReader.GetInt32(11);
                        break;
                    }
                }
                connection.Close();
            }

            loginClient = textBoxlogin.Text;
            passwordClient = textBoxPassword.Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBoxPassword.Text != "")&(textBoxPhone.Text != ""))
            {
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {

                    connection.Open();
                    var command = new SqlCommand("UPDATE [Users] SET [Password] = @password WHERE [Login] = @login", connection);
                    var commandPhone = new SqlCommand("Update [Client_table]  SET PhoneNumber = @phoneNumber WHERE ClientID=@ClientID", connection);
                    command.Parameters.AddWithValue("@login", textBoxlogin.Text.Trim());
                    command.Parameters.AddWithValue("@password", textBoxPassword.Text.Trim());
                    commandPhone.Parameters.AddWithValue("@phoneNumber", textBoxPhone.Text.Trim());
                    commandPhone.Parameters.AddWithValue("@ClientID", ClientID);
                    using (var dataReader = command.ExecuteReader())
                    {
                        dataReader.Close();
                    }
                    try
                    {
                        using (var dataReader = commandPhone.ExecuteReader())
                        {
                            dataReader.Close();
                        }
                        MessageBox.Show("Данные обновлены");
                        connection.Close();
                    }
                    catch(SqlException)
                    {
                        MessageBox.Show("Ошибка. Телефон введен неверно или он уже привязан к другому пользователю.");
                    }
                        connection.Close();
                }
            }
            else MessageBox.Show("Введите новый пароль");

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {               
            buttonSave.Visible = true;            
        }

        static bool IsNum(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c)) return false;
            }
            return true;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if ((IsNum(textBoxPay.Text) == true) & (textBoxPay.Text != ""))
            {
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {

                    connection.Open();
                    var command = new SqlCommand("Update Client_table Set AccountMoney += @Sum WHERE ClientID=@ClientID", connection);
                    
                    command.Parameters.AddWithValue("@Sum", textBoxPay.Text.Trim());
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    

                    using (var dataReader = command.ExecuteReader())
                    {
                        dataReader.Close();
                        MessageBox.Show("Баланс пополнен");
                    }
                    var commandMoney = new SqlCommand("SELECT AccountMoney FROM Client_table WHERE ClientID=@ClientID", connection);
                    commandMoney.Parameters.AddWithValue("@ClientID", ClientID);

                    using (var dataReader = commandMoney.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            AccountMoney.Text = dataReader.GetValue(0).ToString().Trim();
                            break;
                        }
                    }
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Ошибка. Данное поле может содержать только цифры");
        }

        private void textBoxPay_KeyPress(object sender, KeyPressEventArgs e)
        {            
                if (textBoxPay.Text.Length == 0)
                if ((e.KeyChar == '0')) e.Handled = true;
        }

        private void buttonClientChange_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new Auth();
            form.ShowDialog();
        }

        private void buttonOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
                Application.Exit();
            

        }
    }
}

        
 
