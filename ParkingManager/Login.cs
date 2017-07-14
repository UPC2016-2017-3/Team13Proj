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
    public partial class Login : Form
    {
        public static string acc { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LogBu_Click(object sender, EventArgs e)
        {
            Ffare.beilv = 1;
            Login.acc = Account.Text.ToString();
            try
            {
                if (Account.Text == "")
                {
                    MessageBox.Show("用户名不能为空");
                }
                else
                {
                    if (Password.Text == "")
                    {
                        MessageBox.Show("密码不能为空!");
                    }
                    else
                    {
                        string id = Account.Text;//获取账号     
                        string psw = Password.Text;//获取密码 
                        string idtype = comboBox1.Text;
                        string conn = "Data Source=Ting;Initial Catalog=DATA;Integrated Security=True";//连接字符串，需要改成你自己的         
                        SqlConnection connection = new SqlConnection(conn);//创建连接                      
                        connection.Open();//打开连接                       
                        string sql = string.Format("select count(*) from Login where Account='{0}' and Password='{1}' and Type='{2}'", id, psw, idtype);//查询是否有该条记录，根据账户密码        
                        SqlCommand command = new SqlCommand(sql, connection);//sqlcommand表示要向向数据库执行sql语句或存储过程                
                        int i = Convert.ToInt32(command.ExecuteScalar());//执行后返回记录行数           
                        if (i > 0)//如果大于1，说明记录存在，登录成功               
                        {
                            MessageBox.Show("登录成功！");
                            if (idtype == "管理员")
                            {
                                //Fportstate f3 = new Fportstate();
                                //this.Hide();      //测试时隐藏                     
                                //f3.Show();
                                this.DialogResult = DialogResult.OK;    //返回一个登录成功的对话框状态
                                this.Close();    //关闭登录窗口

                            }
                            else
                            {
                                // VIP vp = new VIP();
                                //this.Hide();//测试时隐藏
                                // vp.Show();
                                this.DialogResult = DialogResult.Yes;
                                this.Close();

                            }
                        }
                        else
                        {
                            MessageBox.Show("账户类型、用户名或者密码错误！");
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常错误" + ex);
            }
        }

        private void ReinBu_Click(object sender, EventArgs e)
        {
            Account.Clear();
            Password.Clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Account_TextChanged(object sender, EventArgs e)
        {
            //public string getAccount ()
            //{
            //  return Account .Text ;
            // }
        }




    }
}
