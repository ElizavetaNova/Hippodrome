
namespace Hippodrome
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.HorseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorseColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorseRideCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorseWinCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorseAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Coefficient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HorseNumber,
            this.HorseName,
            this.HorseColor,
            this.HorseRideCount,
            this.HorseWinCount,
            this.HorseAge,
            this.Coefficient});
            this.dataGridView1.GridColor = System.Drawing.Color.DarkSlateGray;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(764, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // HorseNumber
            // 
            this.HorseNumber.HeaderText = "Номер";
            this.HorseNumber.MinimumWidth = 6;
            this.HorseNumber.Name = "HorseNumber";
            this.HorseNumber.ReadOnly = true;
            this.HorseNumber.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseNumber.Width = 86;
            // 
            // HorseName
            // 
            this.HorseName.HeaderText = "Кличка";
            this.HorseName.MinimumWidth = 6;
            this.HorseName.Name = "HorseName";
            this.HorseName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseName.Width = 87;
            // 
            // HorseColor
            // 
            this.HorseColor.HeaderText = "Масть";
            this.HorseColor.MinimumWidth = 6;
            this.HorseColor.Name = "HorseColor";
            this.HorseColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseColor.Width = 80;
            // 
            // HorseRideCount
            // 
            this.HorseRideCount.HeaderText = "Кол-во заездов";
            this.HorseRideCount.MinimumWidth = 6;
            this.HorseRideCount.Name = "HorseRideCount";
            this.HorseRideCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseRideCount.Width = 146;
            // 
            // HorseWinCount
            // 
            this.HorseWinCount.HeaderText = "Кол-во побед";
            this.HorseWinCount.MinimumWidth = 6;
            this.HorseWinCount.Name = "HorseWinCount";
            this.HorseWinCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseWinCount.Width = 134;
            // 
            // HorseAge
            // 
            this.HorseAge.HeaderText = "Возраст";
            this.HorseAge.MinimumWidth = 6;
            this.HorseAge.Name = "HorseAge";
            this.HorseAge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HorseAge.Width = 93;
            // 
            // Coefficient
            // 
            this.Coefficient.HeaderText = "Коэффициент";
            this.Coefficient.MinimumWidth = 6;
            this.Coefficient.Name = "Coefficient";
            this.Coefficient.ReadOnly = true;
            this.Coefficient.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Coefficient.Width = 133;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1178, 640);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseRideCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseWinCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorseAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coefficient;
    }
}

