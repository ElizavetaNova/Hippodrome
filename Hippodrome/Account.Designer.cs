
namespace Hippodrome
{
    partial class Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AccountPage = new System.Windows.Forms.TabPage();
            this.buttonClientChange = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.textBoxPay = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxAge = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SumWin = new System.Windows.Forms.Label();
            this.BetWinCount = new System.Windows.Forms.Label();
            this.BetCount = new System.Windows.Forms.Label();
            this.AccountMoney = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxMidleName = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxlogin = new System.Windows.Forms.TextBox();
            this.buttonPay = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonOut = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.AccountPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AccountPage);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(923, 476);
            this.tabControl1.TabIndex = 0;
            // 
            // AccountPage
            // 
            this.AccountPage.Controls.Add(this.buttonOut);
            this.AccountPage.Controls.Add(this.buttonClientChange);
            this.AccountPage.Controls.Add(this.label12);
            this.AccountPage.Controls.Add(this.labelMoney);
            this.AccountPage.Controls.Add(this.textBoxPay);
            this.AccountPage.Controls.Add(this.buttonSave);
            this.AccountPage.Controls.Add(this.textBoxAge);
            this.AccountPage.Controls.Add(this.label11);
            this.AccountPage.Controls.Add(this.SumWin);
            this.AccountPage.Controls.Add(this.BetWinCount);
            this.AccountPage.Controls.Add(this.BetCount);
            this.AccountPage.Controls.Add(this.AccountMoney);
            this.AccountPage.Controls.Add(this.textBoxPhone);
            this.AccountPage.Controls.Add(this.textBoxMidleName);
            this.AccountPage.Controls.Add(this.textBoxName);
            this.AccountPage.Controls.Add(this.textBoxSurname);
            this.AccountPage.Controls.Add(this.textBoxPassword);
            this.AccountPage.Controls.Add(this.textBoxlogin);
            this.AccountPage.Controls.Add(this.buttonPay);
            this.AccountPage.Controls.Add(this.label10);
            this.AccountPage.Controls.Add(this.label9);
            this.AccountPage.Controls.Add(this.label8);
            this.AccountPage.Controls.Add(this.label7);
            this.AccountPage.Controls.Add(this.label6);
            this.AccountPage.Controls.Add(this.label5);
            this.AccountPage.Controls.Add(this.label4);
            this.AccountPage.Controls.Add(this.label3);
            this.AccountPage.Controls.Add(this.label2);
            this.AccountPage.Controls.Add(this.label1);
            this.AccountPage.Location = new System.Drawing.Point(4, 33);
            this.AccountPage.Margin = new System.Windows.Forms.Padding(2);
            this.AccountPage.Name = "AccountPage";
            this.AccountPage.Padding = new System.Windows.Forms.Padding(2);
            this.AccountPage.Size = new System.Drawing.Size(915, 439);
            this.AccountPage.TabIndex = 0;
            this.AccountPage.Text = "Акаунт";
            this.AccountPage.UseVisualStyleBackColor = true;
            // 
            // buttonClientChange
            // 
            this.buttonClientChange.Location = new System.Drawing.Point(724, 330);
            this.buttonClientChange.Name = "buttonClientChange";
            this.buttonClientChange.Size = new System.Drawing.Size(173, 58);
            this.buttonClientChange.TabIndex = 27;
            this.buttonClientChange.Text = "Сменить пользователя";
            this.buttonClientChange.UseVisualStyleBackColor = true;
            this.buttonClientChange.Click += new System.EventHandler(this.buttonClientChange_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(386, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(360, 102);
            this.label12.TabIndex = 26;
            this.label12.Text = "Чтобы сменить пароль или номер телефона, внесите изменения в соответствующие поля" +
    " и  нажмите кнопку";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMoney
            // 
            this.labelMoney.Location = new System.Drawing.Point(386, 232);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(334, 50);
            this.labelMoney.TabIndex = 25;
            this.labelMoney.Text = "Введите сумму для пополнения счета";
            // 
            // textBoxPay
            // 
            this.textBoxPay.Location = new System.Drawing.Point(386, 295);
            this.textBoxPay.Name = "textBoxPay";
            this.textBoxPay.Size = new System.Drawing.Size(169, 30);
            this.textBoxPay.TabIndex = 24;
            this.textBoxPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPay_KeyPress);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(386, 132);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(169, 59);
            this.buttonSave.TabIndex = 23;
            this.buttonSave.Text = "Сохранить изменения";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBoxAge
            // 
            this.textBoxAge.Location = new System.Drawing.Point(128, 200);
            this.textBoxAge.Name = "textBoxAge";
            this.textBoxAge.ReadOnly = true;
            this.textBoxAge.Size = new System.Drawing.Size(184, 30);
            this.textBoxAge.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 206);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 24);
            this.label11.TabIndex = 21;
            this.label11.Text = "Возраст";
            // 
            // SumWin
            // 
            this.SumWin.AutoSize = true;
            this.SumWin.Location = new System.Drawing.Point(262, 402);
            this.SumWin.Name = "SumWin";
            this.SumWin.Size = new System.Drawing.Size(50, 24);
            this.SumWin.TabIndex = 20;
            this.SumWin.Text = "hjgh";
            // 
            // BetWinCount
            // 
            this.BetWinCount.AutoSize = true;
            this.BetWinCount.Location = new System.Drawing.Point(262, 368);
            this.BetWinCount.Name = "BetWinCount";
            this.BetWinCount.Size = new System.Drawing.Size(50, 24);
            this.BetWinCount.TabIndex = 19;
            this.BetWinCount.Text = "hjgh";
            // 
            // BetCount
            // 
            this.BetCount.AutoSize = true;
            this.BetCount.Location = new System.Drawing.Point(262, 333);
            this.BetCount.Name = "BetCount";
            this.BetCount.Size = new System.Drawing.Size(50, 24);
            this.BetCount.TabIndex = 18;
            this.BetCount.Text = "hjgh";
            // 
            // AccountMoney
            // 
            this.AccountMoney.AutoSize = true;
            this.AccountMoney.Location = new System.Drawing.Point(128, 285);
            this.AccountMoney.Name = "AccountMoney";
            this.AccountMoney.Size = new System.Drawing.Size(50, 24);
            this.AccountMoney.TabIndex = 17;
            this.AccountMoney.Text = "hjgh";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(128, 252);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(184, 30);
            this.textBoxPhone.TabIndex = 16;
            // 
            // textBoxMidleName
            // 
            this.textBoxMidleName.Location = new System.Drawing.Point(128, 164);
            this.textBoxMidleName.Name = "textBoxMidleName";
            this.textBoxMidleName.ReadOnly = true;
            this.textBoxMidleName.Size = new System.Drawing.Size(184, 30);
            this.textBoxMidleName.TabIndex = 15;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(128, 132);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(184, 30);
            this.textBoxName.TabIndex = 14;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(128, 101);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.ReadOnly = true;
            this.textBoxSurname.Size = new System.Drawing.Size(184, 30);
            this.textBoxSurname.TabIndex = 13;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(128, 54);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(184, 30);
            this.textBoxPassword.TabIndex = 12;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxlogin
            // 
            this.textBoxlogin.Location = new System.Drawing.Point(128, 23);
            this.textBoxlogin.Name = "textBoxlogin";
            this.textBoxlogin.ReadOnly = true;
            this.textBoxlogin.Size = new System.Drawing.Size(184, 30);
            this.textBoxlogin.TabIndex = 11;
            // 
            // buttonPay
            // 
            this.buttonPay.Location = new System.Drawing.Point(386, 333);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(169, 36);
            this.buttonPay.TabIndex = 10;
            this.buttonPay.Text = "Пополнить счет";
            this.buttonPay.UseVisualStyleBackColor = true;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 368);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(205, 24);
            this.label10.TabIndex = 9;
            this.label10.Text = "Выигрышные ставки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 402);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(187, 24);
            this.label9.TabIndex = 8;
            this.label9.Text = "Сумма выигрышей";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "Количество ставок";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 285);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Баланс";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 252);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Телефон";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 136);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 101);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(915, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonOut
            // 
            this.buttonOut.Location = new System.Drawing.Point(724, 394);
            this.buttonOut.Name = "buttonOut";
            this.buttonOut.Size = new System.Drawing.Size(173, 37);
            this.buttonOut.TabIndex = 28;
            this.buttonOut.Text = "Выйти";
            this.buttonOut.UseVisualStyleBackColor = true;
            this.buttonOut.Click += new System.EventHandler(this.buttonOut_Click);
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 485);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Name = "Account";
            this.Text = "Account";
            this.tabControl1.ResumeLayout(false);
            this.AccountPage.ResumeLayout(false);
            this.AccountPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AccountPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SumWin;
        private System.Windows.Forms.Label BetWinCount;
        private System.Windows.Forms.Label BetCount;
        private System.Windows.Forms.Label AccountMoney;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxMidleName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxlogin;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAge;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.TextBox textBoxPay;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonClientChange;
        private System.Windows.Forms.Button buttonOut;
    }
}