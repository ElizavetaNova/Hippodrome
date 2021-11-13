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
using System.Data.SqlClient;

namespace Hippodrome
{
    public partial class Admin : Form
    {
        string AdminLogin;
        int ClientIDAdmin;
        hippodromeContext context = new hippodromeContext();
        public Admin()
        {
            //InitializeComponent();
        }
        public Admin(string login)
        {
            AdminLogin = login;
            logging("Вход в систему");
            InitializeComponent();
            
            textBoxlogin.Text = login;
            context.Users.Load();
            dataGridViewNo.DataSource = context.Users.Where(p => p.Login == login).ToList();
            textBoxPassword.Text = dataGridViewNo[2, 0].Value.ToString().Trim();
            textBoxrole.Text = dataGridViewNo[3, 0].Value.ToString().Trim();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            context.Users.Load();
            dataGridViewUsers.DataSource = context.Users.ToList();
            dataGridViewUsers.Columns["UserID"].ReadOnly = true;
            dataGridViewUsers.Columns["Client"].Visible = false;
            dataGridViewUsers.AllowUserToDeleteRows = true;
            dataGridViewUsers.AllowUserToAddRows = true;
            buttonBetClient.Visible = false;
            dataGridViewNo.Visible = false;
        }

        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (dataGridViewUsers[4, row].Value != null)
            {
                ClientIDAdmin = (int)dataGridViewUsers[4, row].Value;
                context.ClientTables.Load();
                dataGridViewClient.DataSource = context.ClientTables.Where(p => p.ClientId == ClientIDAdmin).ToList();
                dataGridViewClient.Columns["ClientID"].ReadOnly = true;
                buttonBetClient.Visible = true;
            }
            else
                MessageBox.Show("Данный пользователь не является клиентом");
            
        }

        private void buttonBetClient_Click(object sender, EventArgs e)
        {
            logging("Просмотр ставок клиента ID = "+ ClientIDAdmin);
            this.Hide();
            var form = new BetsClient(ClientIDAdmin);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logging("Смена пользователя");
            this.Hide();
            var form = new Auth();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {            
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                logging("Выход из системы");
                Application.Exit();
            }                    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text != "")
            {
                string password = textBoxPassword.Text.Trim();
                using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
                {

                    connection.Open();
                    var command = new SqlCommand("UPDATE [Users] SET [Password] = @password WHERE [Login] = @login", connection);
                    
                    command.Parameters.AddWithValue("@login", AdminLogin);
                    command.Parameters.AddWithValue("@password", password);
                    
                    using (var dataReader = command.ExecuteReader())
                    {
                        //logging("Смена пароля");
                        dataReader.Close();
                        logging("Смена пароля");
                        MessageBox.Show("Пароль изменен");
                    }
                    
                    connection.Close();
                }
            }
            else MessageBox.Show("Введите новый пароль");
        }

        public void logging(string action)
        {
            using (hippodromeContext context = new hippodromeContext())
            {
                Logging log = new Logging()
                { Login = AdminLogin, Action = action, Date = DateTime.Parse(DateTime.Now.ToLongTimeString()) };
                context.Loggings.Add(log);
                context.SaveChanges();
            }
        }
    }
}
