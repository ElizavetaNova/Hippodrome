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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            using (var connection = new SqlConnection("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;"))
            {
                connection.Open();
                var command = new SqlCommand("exec UpcommingRaces", connection);

                using (var dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add(new object[] {dataReader.GetInt32(dataReader.GetOrdinal("RaceNumber")),
                           dataReader.GetDateTime(dataReader.GetOrdinal("RaceDate")).ToShortDateString() } );
                        //int intColumn = dataReader.GetInt32(dataReader.GetOrdinal("intColumnName"));
                        //string stringColumn = dr.GetString(dr.GetOrdinal("stringColumnName"));
                       
                    }
                }
                connection.Close();
            }
            
        }
    }
    
}
