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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (hippodromeContext db = new hippodromeContext())
            {
                var horses = (from horse in db.HorseTables
                              select new
                              {
                                  horse.HorseNumber,
                                  horse.HorseName,
                                  horse.HorseColor,
                                  horse.HorseRideCount,
                                  horse.HorseWinCount,
                                  horse.HorseAge,
                                  horse.Coefficient
                              }).ToList();
                foreach (var horse in horses)
                {

                    dataGridView1.Rows.Add(horse.HorseNumber, horse.HorseName.Trim(), horse.HorseColor.Trim(), horse.HorseRideCount,
                        horse.HorseWinCount, horse.HorseAge, horse.Coefficient);
                }
            }
        }
    }
}
