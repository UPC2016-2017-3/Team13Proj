using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Search
{
    public partial class FrmUserUpdate : Form
    {
        infor  _frmUser = new infor();

        private string _uname;

        public string Uname
        {
            get { return _uname; }
            set { _uname = value; }
        }
        private string _uID;

        public string UID
        {
            get { return _uID; }
            set { _uID = value; }
        }
        private string _uPhone;

        public string UPhone1
        {
            get { return _uPhone; }
            set { _uPhone = value; }
        }
        private string _uAddress;

        public string UAddress1
        {
            get { return _uAddress; }
            set { _uAddress = value; }
        }
        private string _uAccount;

        public string UAccount
        {
            get { return _uAccount; }
            set { _uAccount = value; }
        }
        private string _usex;

        public string Usex
        {
            get { return _usex; }
            set { _usex = value; }
        }
        
        public FrmUserUpdate(infor frmUser)
        {
            InitializeComponent();

            _frmUser = frmUser;
            txtUname.Text = _frmUser.name;
            txtUID.Text = _frmUser.UID;
            txtUPhone.Text = _frmUser.UPhone1;
            txtUAddress.Text = _frmUser.UAddress1;
            txtUAccount.Text = _frmUser.UAccount;
            txtUsex.Text = _frmUser._usex;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _uname = txtUname.Text.Trim();
            _uID = txtUID.Text.Trim();
            _uPhone = txtUPhone.Text.Trim();
            _uAddress = txtUAddress.Text.Trim();
            _uAccount = txtUAccount.Text.Trim();
            _usex = txtUsex.Text.Trim();

            if (_uname == "")
                MessageBox.Show("请输入姓名！", "错误提示", MessageBoxButtons.OK);
            else if (_uID == "")
            {
                MessageBox.Show("编号不能改变！", "错误提示", MessageBoxButtons.OK);
                return;
            }
            else if (_uAccount == "")
                MessageBox.Show("请输入账号！", "错误提示", MessageBoxButtons.OK);
            Close();

            MessageBox.Show("修改成功！");
            }
       

        private void FrmUserUpdate_Load(object sender, EventArgs e)
        {

        }

        private void txtUsex_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
