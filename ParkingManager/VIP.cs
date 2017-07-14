using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarManager
{
    public partial class VIP : Form
    {
        Draw Draw1 = new Draw();
        DataAccess DataAccess1 = new DataAccess();
        Functions functions1 = new Functions();

        public VIP()
        {
            InitializeComponent();
        }

       private  void VIP_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
            string sex;
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = "Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";
            sqlconn.Open();
            SqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandText = string.Format("select vname,sex from vip where Account = '{0}'", Login.acc);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string name = reader.GetString(0);
            string sex1 = reader.GetString(1);
           
            if (sex1.Trim().Equals ("男"))
            {
                sex= "先生";
            }
            else
            {
                sex = "女士";
            }
            sqlconn.Close();
            label1.Text = "尊敬的" + name.Trim() + sex+",欢迎登录停车场管理系统！";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = "Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";
            sqlconn.Open();
            SqlCommand cmd = sqlconn.CreateCommand();
            cmd.CommandText = string.Format("select CarNo from vip where Account = '{0}'", Login.acc);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string carpai = reader.GetString(0);
            sqlconn.Close();
            sqlconn.Open();
            string sq = string.Format("select count(*) from CarIn where CarNo='{0}'", carpai);
            SqlCommand command = new SqlCommand(sq, sqlconn );
            int i = Convert.ToInt32(command.ExecuteScalar());
            if (i > 0)
            {
                Draw1.drawdetail(panel1, carpai);
            }
            else
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            sqlconn.Close();
                     
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("请输入新密码");
                }
                else
                {
                    string newmi = textBox1.Text;
                    string conn = "Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";
                    SqlConnection connection = new SqlConnection(conn);//创建连接                      
                    connection.Open();//打开连接                       
                    string sql = string.Format("update Login set Password='{0}' where Account='{1}'", newmi, Login.acc);
                    SqlCommand command = new SqlCommand(sql, connection);
                    int i = Convert.ToInt32(command.ExecuteScalar());
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = string.Format("select Password from Login where Account = '{0}'", Login.acc);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string mi = reader.GetString(0);
                  
                    if (newmi .Equals (mi .Trim ()) )            
                    {
                        MessageBox.Show("修改成功！");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

       

       
       

        

     

      
    }
}
