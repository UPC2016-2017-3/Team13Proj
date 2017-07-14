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
    public partial class infor : Form
    {
        private string _uname;

        public string name//--//
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
        public string _usex;
        public string usex
        {
            get { return _usex; }
            set { _usex = value; }
        }
        public infor()
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
            //dataGridView1.DataSource = myDataSet.Tables["T_User"];

            BindingSource bs = new BindingSource();
            bs.DataSource = myDataSet.Tables["vip"];
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;
        }

        private void infor_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Ting;initial catalog='DATA';Integrated Security=True");

            con.Open();
            string strSql = "SELECT * FROM vip;";
            SqlDataAdapter da = new SqlDataAdapter(strSql, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "vip");
            con.Close();

            //设置绑定
            BindingSource bs = new BindingSource();
            bs.DataSource = ds.Tables[0];
            dataGridView1.DataSource = bs;
            bindingNavigator1.BindingSource = bs;

            cboQueryWay.SelectedItem = cboQueryWay.Items[0];

        }

        private void btnQuery_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Ting;initial catalog='DATA';Integrated Security=True");

            string strInput = txtInput.Text.Trim();
            string strSql;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            BindingSource bs = new BindingSource();
            bool b = true;

            if (cboQueryWay.SelectedItem == cboQueryWay.Items[0])
            {
                if (strInput == "")
                    MessageBox.Show("请输入查询内容！");
                else
                {
                    con.Open();
                    strSql = string.Format("SELECT * FROM vip WHERE vname='{0}'", strInput);
                    da = new SqlDataAdapter(strSql, con);
                    da.Fill(ds, "vip");
                    con.Close();

                    bs.DataSource = ds.Tables[0];
                    dataGridView1.DataSource = bs;
                    bindingNavigator1.BindingSource = bs;

                    if (ds.Tables["vip"].Rows.Count == 0)
                        b = false;
                }
            }
            else if (cboQueryWay.SelectedItem == cboQueryWay.Items[1])
            {
                if (strInput == "")
                    MessageBox.Show("请输入查询内容！");
                else
                {
                    con.Open();
                    strSql = string.Format("SELECT * FROM vip WHERE Account='{0}'", strInput);
                    da = new SqlDataAdapter(strSql, con);
                    da.Fill(ds, "vip");
                    con.Close();

                    bs.DataSource = ds.Tables[0];
                    dataGridView1.DataSource = bs;
                    bindingNavigator1.BindingSource = bs;

                    if (ds.Tables["vip"].Rows.Count == 0)
                        b = false;
                }
            }

            if (b == false)
                MessageBox.Show("对不起，没有这样的记录！");

        }

        private void btnSX_Click(object sender, EventArgs e)
        {
            infor_Load(sender, e);
        }
        //--//
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmUserAdd frmUserAdd = new FrmUserAdd();
            frmUserAdd.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FrmUserUpdate frmUserUpdate = new FrmUserUpdate(this);
            if (frmUserUpdate.ShowDialog() == DialogResult.OK)
            {

                _uname = frmUserUpdate.Uname;
                //--//
                _uID = frmUserUpdate.UID;
                //--//
                _uPhone = frmUserUpdate.UPhone1;
                _uAddress = frmUserUpdate.UAddress1;
                _uAccount = frmUserUpdate.UAccount;

                string connStr = @"Data Source=Ting;initial catalog='DATA';Integrated Security=True";
                string updateCmd = "update T_User Set vname ='" + _uname + "',home  = '" + _uAddress + "', phone ='" + _uPhone + "',sex='"+_usex+"'WHERE Account='" + _uID + "'";


                SqlConnection conn;
                SqlCommand cmd;
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand(updateCmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowRecords();
            }
        }
        //--//
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _uname = Convert.ToString(dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            _uID = Convert.ToString(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            _uPhone = Convert.ToString(dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            _uAddress = Convert.ToString(dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            _uAccount = Convert.ToString(dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value).Trim();
            _usex = Convert.ToString(dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value).Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否真要删除？", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string connStr, delCmd, selectCmd, content;
                connStr = @"Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";  //数据库连接语句
                selectCmd = "select CarNo From CarIn Where Account = '" + _uID + "'";
                SqlConnection conn;
                SqlCommand cmd;
                conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd1 = new SqlCommand(selectCmd, conn);
                content = cmd1.ExecuteReader().ToString();
                conn.Close();

                delCmd = "Delete From Carin Where Account = '" + _uID + "'" +
                    "Delete From vip Where Account = '" + _uID + "'" +
                "Delete From Login Where Account = '" + _uID + "'"; 
                    //"Delete From T_CarPosition Where CarID = '" + content + "'" +
                //--//
                //SqlConnection conn;
                //SqlCommand cmd;
                conn = new SqlConnection(connStr);
                //--//
                conn.Open();
                cmd = new SqlCommand(delCmd, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("删除成功");
                conn.Close();

                ShowRecords();
            }
        }

        private void infor_Load_1(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            FrmUserAdd frmUserAdd = new FrmUserAdd();
            frmUserAdd.ShowDialog();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_2(object sender, EventArgs e)
        {
            FrmUserUpdate frmUserUpdate = new FrmUserUpdate(this);
            if (frmUserUpdate.ShowDialog() == DialogResult.OK)
            {

                _uname = frmUserUpdate.Uname;
                //--//
                _uID = frmUserUpdate.UID;
                //--//
                _uPhone = frmUserUpdate.UPhone1;
                _uAddress = frmUserUpdate.UAddress1;
                _uAccount = frmUserUpdate.UAccount;
                _usex = frmUserUpdate.Usex;

                string connStr = @"Data Source=Ting;initial catalog='DATA';Integrated Security=True";
                string updateCmd = "update vip set vname ='" + _uname + "',home  = '" + _uAddress + "', phone ='" + _uPhone + "',sex='" + _usex + "'WHERE Account='" + _uID + "'";


                SqlConnection conn;
                SqlCommand cmd;
                conn = new SqlConnection(connStr);
                conn.Open();
                cmd = new SqlCommand(updateCmd, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                ShowRecords();
            }
        }
    }
}