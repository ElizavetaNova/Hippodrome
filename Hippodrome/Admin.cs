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
        int DeleteUser = 0;
        int RaceNumber=0;
        string conect = "Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;";
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
            dataGridViewUsers.Columns["ClientID"].ReadOnly = true;
            dataGridViewUsers.Columns["Role"].ReadOnly = true;
            dataGridViewUsers.Columns["Login"].ReadOnly = true;
            //dataGridViewUsers.Columns["Login"].ToString().Trim();
            dataGridViewUsers.Columns["Client"].Visible = false;
            dataGridViewUsers.AllowUserToDeleteRows = true;
            dataGridViewUsers.AllowUserToAddRows = true;

            context.ClientTables.Load();
            dataGridViewClient.DataSource = context.ClientTables.Where(p => p.ClientId == -1).ToList();
            buttonBetClient.Visible = false;

            dataGridViewNo.Visible = false;

            context.RaceTables.Load();
            dataGridViewRace.DataSource = context.RaceTables.ToList();
            dataGridViewRace.Columns["RaceNumber"].ReadOnly = true;
            dataGridViewRace.Columns["RaceNumber"].HeaderText = "№ заезда";
            dataGridViewRace.Columns["BettingTables"].Visible = false;
            dataGridViewRace.Columns["MembersRaceTables"].Visible = false;
            dataGridViewRace.Columns["RaceDate"].HeaderText = "Дата заезда";
            dataGridViewRace.Columns["WinHorseNumber"].HeaderText = "Победитель";
            dataGridViewRace.Columns["RaceDuration"].HeaderText = "Время";

            //buttonDeleteUserClient.Visible = false;
        }

        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (dataGridViewUsers[4, row].Value != null)
            {
                ClientIDAdmin = (int)dataGridViewUsers[4, row].Value;
                DeleteUser = (int)dataGridViewUsers[0, row].Value;
                context.ClientTables.Load();
                dataGridViewClient.DataSource = context.ClientTables.Where(p => p.ClientId == ClientIDAdmin).ToList();
                dataGridViewClient.Columns["ClientID"].ReadOnly = true;
                buttonBetClient.Visible = true;
            }
            else
            {
                DeleteUser = (int)dataGridViewUsers[0, row].Value;
                ClientIDAdmin = 0;
                buttonBetClient.Visible = false;
                context.ClientTables.Load();
                dataGridViewClient.DataSource = context.ClientTables.Where(p => p.ClientId == -1).ToList();
                //MessageBox.Show("Данный пользователь не является клиентом");
                //dataGridViewClient.Rows.Clear();

            }    
                
            
        }

        private void buttonBetClient_Click(object sender, EventArgs e)
        {
            logging("Просмотр ставок клиента ID = "+ ClientIDAdmin);
            this.Hide();
            var form = new BetsClient(ClientIDAdmin, AdminLogin);
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
                using (var connection = new SqlConnection(conect))
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

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            Admin_Load(sender, e);
        }

        private void buttonSaveUser_Click(object sender, EventArgs e)
        {
            if ((textBoxPasswordNewUser.Text != "") && (textBoxloginNewUser.Text != ""))
            {
                string login = textBoxloginNewUser.Text;
                string password = textBoxPasswordNewUser.Text;
                using (var connection = new SqlConnection(conect))
                {
                    connection.Open();
                    using (var command = new SqlCommand("insert into Users ([Login], [Password], [Role]) Values (@Login, @password, 1)", connection))
                    {
                        command.Parameters.AddWithValue("@Login", login);
                        command.Parameters.AddWithValue("@password", password);
                        try
                        {
                            using (var dataReader = command.ExecuteReader())
                            {
                                dataReader.Close();
                            }
                            logging("Добавлен новый пользователь");
                            textBoxloginNewUser.Text = "";
                            textBoxPasswordNewUser.Text = "";
                            Admin_Load(sender, e);
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

        private void buttonDeleteUserClient_Click(object sender, EventArgs e)
        {
            if (DeleteUser != 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    using (var connection = new SqlConnection(conect))
                    {
                        connection.Open();
                        var commandUserDelete = new SqlCommand("delete From Users where UserID=@UserID", connection);
                        commandUserDelete.Parameters.AddWithValue("@UserID", DeleteUser);
                        var commandClientDelete = new SqlCommand("delete from Client_table where ClientID=@ClientID", connection);
                        commandClientDelete.Parameters.AddWithValue("@ClientID", ClientIDAdmin);
                        try
                        {
                            logging("Удаление пользователя");
                        var datareader = commandUserDelete.ExecuteReader();
                        datareader.Close();
                        datareader = commandClientDelete.ExecuteReader();
                        datareader.Close();
                        MessageBox.Show("Пользователь удален");
                        }
                        catch (Exception)
                        {
                        MessageBox.Show("Ошибка. Выберите пользователя для удаления двойным кликом");
                        }
                        connection.Close();

                    }
                    Admin_Load(sender, e);
                }
            }
            
        }

        //ЗАЕЗДЫ

        private void dataGridViewRace_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            RaceNumber = (int)dataGridViewRace[0, row].Value;
            context.ViewInfoMembers.Load();
            dataGridViewMembersRace.DataSource = context.ViewInfoMembers.Where(p => p.RaceNumber == RaceNumber).ToList();
            dataGridViewMembersRace.Columns["RaceNumber"].Visible = false;
            dataGridViewMembersRace.Columns["RaceDate"].Visible = false;
            

        }

        private void buttonAddRace_Click(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection(conect))
            {
                DateTime date = dateTimePicker1.Value;
                connection.Open();
                using (var command = new SqlCommand("insert into [Race_table] ([RaceDate]) values (@RaceDate)", connection))
                {
                    command.Parameters.AddWithValue("@RaceDate", date);
                    
                    try
                    {
                        using (var dataReader = command.ExecuteReader())
                        {
                            dataReader.Close();
                        }
                        logging("Добавлен новый заезд");
                        
                        Admin_Load(sender, e);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ошибка");

                    }
                }
                connection.Close();
            }
        }

        private void buttonSaveRaceChange_Click(object sender, EventArgs e)
        {
            try
            {
                context.SaveChanges();
            }
            catch(Exception)
            {
                Admin_Load(sender, e);
                MessageBox.Show("Ошибка. Вы пытаетесь добавить лошадь не учавствующую в этом заезде либо заезд еще не состоялся");
                context.RaceTables.Load();
                dataGridViewRace.DataSource = context.RaceTables.ToList();
            }
            Admin_Load(sender, e);
        }

        private void buttonDeleteRace_Click(object sender, EventArgs e)
        {
            if (RaceNumber != 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить заезд?", "Удаление", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    using (var connection = new SqlConnection(conect))
                    {
                        connection.Open();
                        SqlCommand comm = connection.CreateCommand();
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.CommandText = "DeleteRace";
                        comm.Parameters.AddWithValue("@RaceNumber", RaceNumber);
                        
                        try
                        {
                            comm.ExecuteReader();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ошибка");
                        }
                        Admin_Load(sender, e);
                    }
            }
            else
                MessageBox.Show("Выберите заезд для удаления");
        }
    }
}
