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
        hippodromeContext context = new hippodromeContext();
        public Admin()
        {
            //InitializeComponent();
        }
        public Admin(string login)
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            context.Users.Load();
            dataGridViewUsers.DataSource = context.Users.ToList();
            dataGridViewUsers.Columns["UserID"].ReadOnly = true;
            dataGridViewUsers.Columns["Client"].Visible = false;
            dataGridViewUsers.AllowUserToDeleteRows = true;
            dataGridViewUsers.AllowUserToAddRows = true;
        }

        private void dataGridViewUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if ((string)dataGridViewUsers[4, row].Value != "")
            {
                int ClientIDAdmin = (int)dataGridViewUsers[4, row].Value;
                context.ClientTables.Load();
                dataGridViewClient.DataSource = context.ClientTables.Where(p => p.ClientId == ClientIDAdmin).ToList();
                dataGridViewClient.Columns["ClientID"].ReadOnly = true;

            }
            else
                MessageBox.Show("Данный пользователь не является клиентом");
            
        }
    }
}
