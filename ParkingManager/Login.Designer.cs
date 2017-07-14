namespace CarManager
{
    partial class Login
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
            this.LogBu = new System.Windows.Forms.Button();
            this.ReinBu = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Account = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LogBu
            // 
            this.LogBu.Location = new System.Drawing.Point(141, 200);
            this.LogBu.Name = "LogBu";
            this.LogBu.Size = new System.Drawing.Size(75, 23);
            this.LogBu.TabIndex = 0;
            this.LogBu.Text = "确认登录";
            this.LogBu.UseVisualStyleBackColor = true;
            this.LogBu.Click += new System.EventHandler(this.LogBu_Click);
            // 
            // ReinBu
            // 
            this.ReinBu.Location = new System.Drawing.Point(141, 243);
            this.ReinBu.Name = "ReinBu";
            this.ReinBu.Size = new System.Drawing.Size(75, 23);
            this.ReinBu.TabIndex = 1;
            this.ReinBu.Text = "重新输入";
            this.ReinBu.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "管理员",
            "会员"});
            this.comboBox1.Location = new System.Drawing.Point(150, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "账号类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "密码";
            // 
            // Account
            // 
            this.Account.Location = new System.Drawing.Point(150, 105);
            this.Account.Name = "Account";
            this.Account.Size = new System.Drawing.Size(121, 20);
            this.Account.TabIndex = 6;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(150, 149);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(121, 20);
            this.Password.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 301);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Account);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ReinBu);
            this.Controls.Add(this.LogBu);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LogBu;
        private System.Windows.Forms.Button ReinBu;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Account;
        private System.Windows.Forms.TextBox Password;
    }
}