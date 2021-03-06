using System;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Configuration;

namespace CarManager
{
    class DataAccess
    {
        SqlConnection Conn = new SqlConnection(ConfigurationSettings.AppSettings[0].ToString());
        string str;


        public int getPortnum(string PortName)
        {
            int PortNum;
            str = "select PortNum from PortState where PortName ='" + PortName + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            PortNum = Convert.ToInt32(reader[0].ToString());
            Conn.Close();
            return PortNum;
        }

        public void addcar(string CarNo, string CarCla, string InTime, string PortNo)
        {

            string RegCarNo = "[\u4e00-\u9fa5][A-Z]-[0-9]{5}";
            string RegInTime = "([0-1][0-9]|2[0-3]):([0-5][0-9]):([0-5][0-9])";
            string RegCarCla = "(大卡|中货|小轿)";

            Conn.Open();
            str = "select CarNo from CarIn where CarNo='" + CarNo + "'";
            SqlCommand command = new SqlCommand(str, Conn);
            SqlDataReader reader = command.ExecuteReader();
            if (!Regex.IsMatch(CarNo, RegCarNo) || CarNo.Length != 8)
            {
                MessageBox.Show("无效的车牌号码（正确的格式：京A-12345）！");
            }
            else if (!Regex.IsMatch(InTime, RegInTime) || InTime.Length != 8)
            {
                MessageBox.Show("无效的入库时间（正确的格式：12:34:00）！");
            }
            else if (!Regex.IsMatch(CarCla, RegCarCla))
            {
                MessageBox.Show("无效车辆类型（正确的格式：大卡|中货|小轿）！");
            }
            else if (PortNo == "")
            {
                MessageBox.Show("本车库已满，下次请早！");
            }
            else if (!reader.Read())
            {
                reader.Close();
                str = "insert into CarIn(CarNo,CarCla,InTime,PortNo) values ('" + CarNo + "','" + CarCla + "','" + InTime + "','" + PortNo.Trim() + "')";
                SqlCommand Command = new SqlCommand(str, Conn);
                Command.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("重复的车牌号码！");
            }
            Conn.Close();
        }

        public string recPortNo(string CarClass)
        {
            int NumA, NumB, NumC;
            string PortNo = "";
            NumA = getPortnum("PortA");
            NumB = getPortnum("PortB");
            NumC = getPortnum("PortC");
            Conn.Open();
            if (CarClass == "大卡")
            {
                for (int i = 1; i < NumA; i++)
                {
                    str = "select PortNo from CarIn where PortNo = 'A" + i + "'";
                    SqlCommand datacommand = new SqlCommand(str, Conn);
                    SqlDataReader reader = datacommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        PortNo = "A" + i;
                        break;
                    }
                    reader.Close();
                }
            }
            else if (CarClass == "中货")
            {
                for (int i = 1; i < NumB; i++)
                {
                    str = "select PortNo from CarIn where PortNo = 'B" + i + "'";
                    SqlCommand datacommand = new SqlCommand(str, Conn);
                    SqlDataReader reader = datacommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        PortNo = "B" + i;
                        break;
                    }
                    reader.Close();
                }
            }
            else
            {
                for (int i = 1; i < NumC; i++)
                {
                    str = "select PortNo from CarIn where PortNo = 'C" + i + "'";
                    SqlCommand datacommand = new SqlCommand(str, Conn);
                    SqlDataReader reader = datacommand.ExecuteReader();
                    if (!reader.Read())
                    {
                        PortNo = "C" + i;
                        break;
                    }
                    reader.Close();
                }
            }
            Conn.Close();
            return PortNo;
        }

        public void getRate(string CarClass, out int Time1, out int Time2, out int Time3, out double Rate1, out double Rate2, out double Rate3)
        {
            str = "select * from Rate where CarCla ='" + CarClass + "'";
            Conn.Open();
            SqlCommand command = new SqlCommand(str, Conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Time1 = Convert.ToInt32(reader[1]);
            Rate1 = Convert.ToDouble(reader[2].ToString());
            Time2 = Convert.ToInt32(reader[3]);
            Rate2 = Convert.ToDouble(reader[4].ToString());
            Time3 = Convert.ToInt32(reader[5]);
            Rate3 = Convert.ToDouble(reader[6].ToString());
            Conn.Close();
        }

        public void updaterage(string CarClass, int Time1, int Time2, int Time3, string Rate1, string Rate2, string Rate3)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("确定更新数据？", "请确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                str = "update Rate set Time1=" + Time1 + ",Time2=" + Time2 + ",Time3=" + Time3 + ",Rate1=" + Rate1 + ",Rate2=" + Rate2 + ",Rate3=" + Rate3 + "where CarCla='" + CarClass + "'";
                Conn.Open();
                SqlCommand Command = new SqlCommand(str, Conn);
                Command.ExecuteNonQuery();
                Conn.Close();
            }
        }

        public void getPortused(string PortName, out int PortNum, out int PortUsed)
        {
            str = "select PortNum,PortUsed from PortState where PortName ='" + PortName + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            PortNum = Convert.ToInt32(reader[0].ToString());
            PortUsed = Convert.ToInt32(reader[1].ToString());
            Conn.Close();
        }

        public int getDataNum(string table)
        {
            int DataNum;
            str = "select COUNT(*) from " + table + "";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            DataNum = Convert.ToInt32(reader[0].ToString());
            Conn.Close();
            return DataNum;
        }

        public string[] getCarNo()
        {

            int arrayno = getDataNum("CarIn");
            string[] Carray = new string[arrayno];

            str = "select CarNo from CarIn ";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                Carray[i] = reader[0].ToString();
                i++;
            }
            Conn.Close();
            //string Carrays = String.Empty;
            //foreach (string tempCarrays in Carray )
            //{
            //    Carrays  += tempCarrays;
            //}
            //Fportstate.gainCarNo = Carrays;
            return Carray;
        }


        public void getCardetail(string CarNo, out string carcla, out string intime, out string portno)
        {
            str = "select CarCla,InTime,PortNo from CarIn where CarNo='" + CarNo + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            carcla = reader[0].ToString();
            intime = reader[1].ToString();
            portno = reader[2].ToString();
            Conn.Close();
        }

        public void delCar(string CarNo, string money)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("车牌号码为：" + CarNo + ",需要缴纳停车费用" + money + "元！确定离开车库？", "请确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                str = "update CarIn set OutTime ='" + money + "'where CarNo ='" + CarNo + "'";
                Conn.Open();
                SqlCommand Command = new SqlCommand(str, Conn);
                Command.ExecuteNonQuery();

                str = "delete from CarIn where CarNo ='" + CarNo + "'";
                SqlCommand Command2 = new SqlCommand(str, Conn);
                Command2.ExecuteNonQuery();
                Conn.Close();
            }
        }

        public int[] getPortstate(string PortName, out int arrayno)
        {
            int temparrayno = getDataNum("CarIn");
            int[] temparray = new int[temparrayno];
            str = "select PortNo from CarIn";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                if (reader[0].ToString().Substring(0, 1) == PortName.Substring(4, 1))
                {
                    temparray[i] = Convert.ToInt32(reader[0].ToString().Substring(1, reader[0].ToString().Length - 1));
                    i++;
                }
            }
            Conn.Close();

            arrayno = i;
            int[] Pnoarray = new int[arrayno];
            {
                for (int j = 0; j < arrayno; j++)
                {
                    Pnoarray[j] = temparray[j];
                }
            }
            return Pnoarray;
        }

        public void getCardetail2(string PortNo, out string CarNo, out string InTime, out string CarCla)
        {
            str = "select CarNo,InTime,CarCla from CarIn where PortNo ='" + PortNo + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            CarNo = reader[0].ToString();
            InTime = reader[1].ToString();
            CarCla = reader[2].ToString();
            Conn.Close();
        }

        public int getCarportnum(string CarCla)
        {
            int Carnum;
            str = "select COUNT(*) from CarIn where CarCla = '" + CarCla + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            reader.Read();
            Carnum = Convert.ToInt32(reader[0].ToString());
            Conn.Close();
            return Carnum;
        }

        public string[] getCarportno(string CarCla)
        {
            int arrayno = getCarportnum(CarCla);
            string[] Carray = new string[arrayno];

            str = "select PortNo from CarIn where CarCla = '" + CarCla + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                Carray[i] = reader[0].ToString();
                i++;
            }
            Conn.Close();
            return Carray;
        }

        public void updatestate(string PortName, int PortNum)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("确定更新数据？", "请确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                string RegPortNum = "[0-9]{1,3}";

                if (!Regex.IsMatch(PortNum.ToString(), RegPortNum) || PortNum.ToString().Length > 3)
                {
                    MessageBox.Show("无效的车位数目！");
                }
                else
                {
                    str = "update PortState set PortNum=" + PortNum + "where PortName='" + PortName + "'";
                    Conn.Open();
                    SqlCommand Command = new SqlCommand(str, Conn);
                    Command.ExecuteNonQuery();
                    Conn.Close();
                }
            }
        }

        public DataSet getDataset(string sqlstr)
        {
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, Conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Conn.Close();
            return ds;
        }

        public void updatedata(DataSet ds, string sqlstr)
        {
            Conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, Conn);

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            da.Update(ds);

            Conn.Close();

        }

        public bool isEmpty(string portno)
        {
            bool empty = false;
            str = "select CarNo from CarIn where PortNo = '" + portno + "'";
            Conn.Open();
            SqlCommand datacommand = new SqlCommand(str, Conn);
            SqlDataReader reader = datacommand.ExecuteReader();

            if (!reader.Read())
            {
                empty = true;
            }
            Conn.Close();
            return empty;
        }

        public void Dropit(string table)
        {
            str = "drop table " + table + "";
            Conn.Open();
            SqlCommand Command = new SqlCommand(str, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();
        }

        public void Emptyit(string table)
        {
            str = "truncate table " + table + "";
            Conn.Open();
            SqlCommand Command = new SqlCommand(str, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();
        }

        public void CarlogInitial()
        {
            str = "insert into Carlog(CarNo,CarCla,InTime,OutTime,PortNo,Action,Actiontime) select CarNo,CarCla,InTime,OutTime,PortNo,'车库保持',CONVERT(varchar(100), GETDATE(), 8) from CarIn";
            Conn.Open();
            SqlCommand Command = new SqlCommand(str, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();
        }

        public void ResetCarIn()
        {
            //str = "insert into CarIn select * from BackUp_CarIn ";
            int arrayno = getDataNum("BackUp_CarIn");
            string[] carno = new string[arrayno];
            string[] carcla = new string[arrayno];
            string[] intime = new string[arrayno];
            string[] portno = new string[arrayno];

            str = "select * from BackUp_CarIn";
            Conn.Open();
            SqlCommand command = new SqlCommand(str, Conn);
            SqlDataReader reader = command.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                carno[i] = reader[0].ToString().Trim();
                carcla[i] = reader[1].ToString().Trim();
                intime[i] = reader[2].ToString().Trim();
                portno[i] = reader[4].ToString().Trim();
                i++;
            }
            Conn.Close();

            for (int j = 0; j < arrayno; j++)
            {
                addcar(carno[j], carcla[j], intime[j], portno[j]);
            }

        }

        public void ResetPortState()
        {
            //str = "insert into PortState(PortName,PortNum,PortUsed) select PortName,PortNum,PortUsed from BackUp_PortState";
            str = "select * into PortState from BackUp_PortState";
            Conn.Open();
            SqlCommand Command = new SqlCommand(str, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();
        }

        public void ResetRate()
        {
            //str = "insert into Rate(CarCla,Time1,Rate1,Time2,Rate2,Time3,Rate3) select CarCla,Time1,Rate1,Time2,Rate2,Time3,Rate3 from BackUp_Rate";
            str = "select * into Rate from BackUp_Rate";
            Conn.Open();
            SqlCommand Command = new SqlCommand(str, Conn);
            Command.ExecuteNonQuery();
            Conn.Close();
        }

    }
}