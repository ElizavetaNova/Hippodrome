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
        string conect = "Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;";
        int ClientIDAdmin;
        int BetNumberDelete;
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
            buttonCancelBet.Visible = false;
            context.ViewBetClientHistories.Load();
            dataGridView1.DataSource = context.ViewBetClientHistories.Where(p => p.ClientId == ClientIDAdmin).ToList();
            dataGridView1.Columns["ClientID"].Visible = false;
            dataGridView1.Columns["BetNumber"].ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = true;
            dataGridView1.AllowUserToAddRows = true;

            using (var connection = new SqlConnection(conect))
            {
                connection.Open();
                SqlCommand comm = connection.CreateCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "BetAccepted";
                comm.Parameters.AddWithValue("@ClientID", ClientIDAdmin);
                DataTable dt = new DataTable();
                dt.Load(comm.ExecuteReader());
                dataGridView2.DataSource = dt.DefaultView;
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonCancelBet.Visible = true;
            int row = e.RowIndex;
            BetNumberDelete = (int)dataGridView2[0, row].Value;

        }

        private void buttonCancelBet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить ставку номер"+BetNumberDelete, "Удаление", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                using (var connection = new SqlConnection(conect))
                {
                    connection.Open();
                    SqlCommand comm = connection.CreateCommand();
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.CommandText = "DeleteActiveBet";
                    comm.Parameters.AddWithValue("@BetNumber", BetNumberDelete);
                    DataTable dt = new DataTable();
                    dt.Load(comm.ExecuteReader());
                    BetsClient_Load(sender, e);
                }
            }
            else
                buttonCancelBet.Visible = false;

        }
    }
}
