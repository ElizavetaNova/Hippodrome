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
using System.Data.Entity;

namespace Hippodrome
{
    public partial class Account : Form
    {
        string loginClient;
        string passwordClient;
        int ClientID;
        int BetHorseNumberInForm;
        double BetCoefficientInForm;
        int BetRaceNumberInForm;
        public Account()
        {
            
        }

        public Account(string login)
        {
            InitializeComponent();
            buttonOkPay.Visible = false;
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
                        loginClient = (string)dataReader.GetValue(0);
                        textBoxPassword.Text = dataReader.GetValue(1).ToString().Trim();
                        textBoxSurname.Text = dataReader.GetValue(2).ToString().Trim();
                        textBoxName.Text = dataReader.GetValue(3).ToString().Trim();
                        textBoxMidleName.Text = dataReader.GetValue(4).ToString().Trim();
                        textBoxAge.Text = dataReader.GetInt32(5).ToString().Trim();
                        textBoxPhone.Text = dataReader.GetValue(6).ToString().Trim();
                        AccountMoney.Text = dataReader.GetValue(7).ToString().Trim();
                        AccountMoney.Text = AccountMoney.Text.Remove(AccountMoney.Text.Length - 2);
                        BetCount.Text = dataReader.GetValue(8).ToString().Trim();
                        BetWinCount.Text = dataReader.GetValue(9).ToString().Trim();
                        SumWin.Text = dataReader.GetSqlMoney(10).ToString().Trim();
                        ClientID = dataReader.GetInt32(11);
                        break;
                    }
                }

                var commandRaceUp = new SqlCommand("exec UpcommingRaces", connection);

                using (var dataReader = commandRaceUp.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        dataGridViewRaceUp.Rows.Add(new object[] {dataReader.GetInt32(dataReader.GetOrdinal("RaceNumber")),
                           dataReader.GetDateTime(dataReader.GetOrdinal("RaceDate")).ToShortDateString() });

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

        private void tabPage2_Layout(object sender, LayoutEventArgs e)
        {
            using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
            {

                connection.Open();
                var commandActiveBet = new SqlCommand("exec BetAccepted @ClientID", connection);

                commandActiveBet.Parameters.AddWithValue("@ClientID", ClientID);
                dataGridActiveBet.Rows.Clear();
                using (var dataReader = commandActiveBet.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        dataGridActiveBet.Rows.Add(new object[] {dataReader.GetInt32(dataReader.GetOrdinal("BetNumber")),
                            dataReader.GetInt32(dataReader.GetOrdinal("BetRaceNumber")),
                            dataReader.GetDateTime(dataReader.GetOrdinal("RaceDate")).ToShortDateString(),
                            dataReader.GetInt32(dataReader.GetOrdinal("BetHorseNumber")),
                            dataReader.GetSqlMoney(dataReader.GetOrdinal("BetSum")),
                            dataReader.GetDouble(dataReader.GetOrdinal("BetCoefficient"))});                        
                    }

                }
                var commandWinBet = new SqlCommand("exec WinBetClient @ClientID", connection);
                commandWinBet.Parameters.AddWithValue("@ClientID", ClientID);
                dataGridViewWin.Rows.Clear();
                using (var dataReader = commandWinBet.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        dataGridViewWin.Rows.Add(new object[] {dataReader.GetInt32(dataReader.GetOrdinal("BetNumber")),
                            dataReader.GetInt32(dataReader.GetOrdinal("RaceNumber")),
                            dataReader.GetDateTime(dataReader.GetOrdinal("RaceDate")).ToShortDateString(),
                            dataReader.GetInt32(dataReader.GetOrdinal("BetHorseNumber")),
                            dataReader.GetSqlMoney(dataReader.GetOrdinal("BetSum")),
                            dataReader.GetDouble(dataReader.GetOrdinal("BetCoefficient"))});
                        
                    }
                }

                using (hippodromeContext context = new hippodromeContext())
                {
                    dataGridBetHistory.DataSource = context.ViewBetClientHistories.Where(p => p.ClientId == ClientID).ToList();
                    dataGridBetHistory.Columns["ClientID"].Visible = false;
                    dataGridBetHistory.Columns["BetNumber"].HeaderText = "Номер ставки";
                    dataGridBetHistory.Columns["BetRaceNumber"].HeaderText = "Номер заезда";
                    dataGridBetHistory.Columns["RaceDate"].HeaderText = "Дата заезда";
                    dataGridBetHistory.Columns["BetHorseNumber"].HeaderText = "Номер лошади";
                    dataGridBetHistory.Columns["BetSum"].HeaderText = "Ставка";
                    dataGridBetHistory.Columns["BetSum"].DefaultCellStyle.Format = "C2";
                    dataGridBetHistory.Columns["BetCoefficient"].HeaderText = "Коэффициент";
                    dataGridBetHistory.Columns["WinHorseNumber"].HeaderText = "Победитель";                    
                }
                connection.Close();
            }
        }

        private void tabPage1_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void dataGridViewRaceUp_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridViewRaceUp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonOkPay.Visible = false;
            labelHorseNumber.Text = "";
            labelCoefficient.Text = "";
            int row = e.RowIndex;
            int colm = 0;
            labelRaceNumber.Text = dataGridViewRaceUp[colm, row].Value.ToString();
            int racenumber = (int)dataGridViewRaceUp[colm, row].Value;
            BetRaceNumberInForm = racenumber;
            using (hippodromeContext context = new hippodromeContext())
            {
                dataGridViewMem.DataSource = context.ViewInfoMembers.Where(p => p.RaceNumber == racenumber).ToList();
                dataGridViewMem.Columns["RaceNumber"].Visible = false;
                dataGridViewMem.Columns["RaceDate"].Visible = false;
                dataGridViewMem.Columns["HorseNumber"].HeaderText = "Номер лошади";
                dataGridViewMem.Columns["RiderNumber"].Visible = false;
                dataGridViewMem.Columns["HorseName"].HeaderText = "Кличка";
                dataGridViewMem.Columns["Coefficient"].HeaderText = "Коэффициент";
                dataGridViewMem.Columns["RiderSurname"].HeaderText = "Фамилия наездника";
                dataGridViewMem.Columns["RiderName"].HeaderText = "Имя наездника";
                //.Columns["BetSum"].DefaultCellStyle.Format = "C2";
                dataGridViewMem.Columns["RiderMiddleName"].HeaderText = "Отчество наездника";
                dataGridViewMem.Columns["Master"].HeaderText = "Мастерство";
            }
        }

        private void dataGridViewMem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;            
            labelHorseNumber.Text = dataGridViewMem[2, row].Value.ToString();
            labelCoefficient.Text = dataGridViewMem[5, row].Value.ToString();
            BetHorseNumberInForm = (int)dataGridViewMem[2, row].Value;
            BetCoefficientInForm = (double)dataGridViewMem[5, row].Value;
            buttonOkPay.Visible = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonOkPay_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {

                    connection.Open();
                    var command = new SqlCommand("insert into Betting_table (BetSum, ClientID, BetHorseNumber, BetRaceNumber) Values(@BetSumC, @ClientID, @BetHorseNumberC, @BetRaceNumberC)", connection);
                    command.Parameters.AddWithValue("@BetSumC", textBox1.Text.Trim());
                    command.Parameters.AddWithValue("@ClientID", ClientID);
                    command.Parameters.AddWithValue("@BetHorseNumberC", BetHorseNumberInForm);
                    command.Parameters.AddWithValue("@BetRaceNumberC", BetRaceNumberInForm);
                    
                    try
                    {
                        using (var dataReader = command.ExecuteReader())
                        {
                            dataReader.Close();
                        }
                        MessageBox.Show("Ставка принята. Удачи!");

                        connection.Close();
                     
                        Form form = new Account(loginClient);
                        this.Close();
                        form.Show();
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Недостаточно средств");
                    }
                    connection.Close();
                }
            }
            else
                MessageBox.Show("Введите сумму ставки");
        }
    }
}

        
 
