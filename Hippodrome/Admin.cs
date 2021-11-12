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
            InitializeComponent();
            AdminLogin = login;
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
            this.Hide();
            var form = new BetsClient(ClientIDAdmin);
            form.ShowDialog();
        }
    }
}
