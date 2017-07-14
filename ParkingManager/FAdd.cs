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
    public partial class FrmUserAdd : Form
    {
        infor  _frmUser = new infor ();

        public FrmUserAdd()
        {
            InitializeComponent();
        }

        void ShowRecords()
        {//从数据库中读取把有的信息，然后显示出来

            string connStr, selectCmd;
            connStr = @"Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";  //数据库连接语句
            selectCmd = "Select * From vip ";            //数据库命令语句
            SqlConnection conn;                             //声明数据库连接对象
            conn = new SqlConnection(connStr);              // 创建数据库连接对象
            SqlDataAdapter myAdapter;                       //声明数据适配器对象
            myAdapter = new SqlDataAdapter(selectCmd, conn); // 创建数据适配器对象
            DataSet myDataSet = new DataSet();              // 创建数据集对象
            conn.Open();                                    // 连接数据库
            myAdapter.Fill(myDataSet, "vip");            // 使用数据适配器填充数据集中的PERSON表
            conn.Close();
            _frmUser.dataGridView1.DataSource = myDataSet.Tables["vip"];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim() == "")
                MessageBox.Show("请输入姓名！", "错误提示", MessageBoxButtons.OK);
            else if (txtUID.Text.Trim() == "")
                MessageBox.Show("请输入编号！", "错误提示", MessageBoxButtons.OK);
            else if (txtUAccount.Text.Trim() == "")
                MessageBox.Show("请输入车辆信息！", "错误提示", MessageBoxButtons.OK);
            else
            {
                string connStr = @"Data Source=Ting;initial catalog='DATA';Integrated Security=True";
                string insertCmd = "INSERT INTO vip(Account,vname,home,phone,CarNo,sex) VALUES('"
                    + txtUID.Text.Trim().Replace("'", "''") + "','" + txtUserName.Text.Trim().Replace("'", "''") + "','"
                    + txtUAddress.Text.Trim().Replace("'", "''") + "','" + txtUPhone.Text.Trim().Replace("'", "''") + "','"
                    + txtUAccount.Text.Trim().Replace("'", "''") + "','" + txtUsex.Text.Trim().Replace("'", "''") + "');INSERT INTO Login(Account) VALUES('" + txtUID.Text.Trim().Replace("'", "''") + "')";
               //"INSERT INTO Login(Account) VALUES('" + txtUID.Text.Trim().Replace("'", "''") + "')";
                SqlConnection conn;
                SqlCommand cmd;
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand(insertCmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowRecords();

                Close();
            }
        }

        private void FrmUserAdd_Load(object sender, EventArgs e)
        {

        }

        private void FrmUserAdd_Load_1(object sender, EventArgs e)
        {

        }

        private void txtUAccount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
