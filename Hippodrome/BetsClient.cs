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
    public partial class BetsClient : Form
    {
        int ClientIDAdmin;
        hippodromeContext context = new hippodromeContext();
        public BetsClient()
        {
            
        }
        public BetsClient(int clientIDAdmin)
        {
            ClientIDAdmin = clientIDAdmin;
            InitializeComponent();
        }

        private void BetsClient_Load(object sender, EventArgs e)
        {
            context.BettingTables.Load().;
            dataGridView1.DataSource = context.Users.ToList();
            dataGridView1.Columns["Userid"].ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AllowUserToAddRows = true;

        }
    }
}
