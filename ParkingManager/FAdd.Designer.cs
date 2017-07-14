namespace Search
{
    partial class FrmUserAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.txtUAddress = new System.Windows.Forms.TextBox();
            this.txtUPhone = new System.Windows.Forms.TextBox();
            this.txtUAccount = new System.Windows.Forms.TextBox();
            this.txtUsex = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "客户姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "登录账号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "联系地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "联系电话";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "客户车辆";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "性别";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(95, 17);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 5;
            // 
            // txtUID
            // 
            this.txtUID.Location = new System.Drawing.Point(95, 58);
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(100, 21);
            this.txtUID.TabIndex = 6;
            // 
            // txtUAddress
            // 
            this.txtUAddress.Location = new System.Drawing.Point(95, 99);
            this.txtUAddress.Name = "txtUAddress";
            this.txtUAddress.Size = new System.Drawing.Size(100, 21);
            this.txtUAddress.TabIndex = 7;
            // 
            // txtUPhone
            // 
            this.txtUPhone.Location = new System.Drawing.Point(95, 140);
            this.txtUPhone.Name = "txtUPhone";
            this.txtUPhone.Size = new System.Drawing.Size(100, 21);
            this.txtUPhone.TabIndex = 8;
            // 
            // txtUAccount
            // 
            this.txtUAccount.Location = new System.Drawing.Point(95, 182);
            this.txtUAccount.Name = "txtUAccount";
            this.txtUAccount.Size = new System.Drawing.Size(100, 21);
            this.txtUAccount.TabIndex = 9;
            this.txtUAccount.TextChanged += new System.EventHandler(this.txtUAccount_TextChanged);
            // 
            // txtUsex
            // 
            this.txtUsex.Location = new System.Drawing.Point(95, 221);
            this.txtUsex.Name = "txtUsex";
            this.txtUsex.Size = new System.Drawing.Size(100, 21);
            this.txtUsex.TabIndex = 10;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(95, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // FrmUserAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 291);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtUAccount);
            this.Controls.Add(this.txtUPhone);
            this.Controls.Add(this.txtUAddress);
            this.Controls.Add(this.txtUID);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtUsex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmUserAdd";
            this.Text = "添加用户";
            this.Load += new System.EventHandler(this.FrmUserAdd_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.TextBox txtUAddress;
        private System.Windows.Forms.TextBox txtUPhone;
        private System.Windows.Forms.TextBox txtUAccount;
        private System.Windows.Forms.TextBox txtUsex;
        private System.Windows.Forms.Button btnOK;
    }
}