using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CarManager
{
    public partial class FCarin : Form
    {
        DataAccess DataAccess1 = new DataAccess();
        Functions functions1 = new Functions();
        Draw Draw1 = new Draw();
        string tempportno;

        public FCarin()
        {
            InitializeComponent();
            initial();
        }

        private void B_in_Click(object sender, EventArgs e)
        {            
            string PortNo1;
            string CarNo1 = CarNo.Text;
            string CarClass1 = CarClass.Text;
            string InTime1 = Hour.Text +":"+ Minute.Text+":00";

            if (tempportno == "")
            {
                PortNo1 = DataAccess1.recPortNo(CarClass1);
            }
            else
            {
                PortNo1 = tempportno;
            }

            string showstr = "���ƺ��룺" + CarNo1 + "\n�������ͣ�" + CarClass1 + "\n���ʱ�䣺" + Hour.Text + "ʱ" + Minute.Text + "��\nͣ�ų�λ��" + PortNo1;
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show(showstr, "ȷ�����", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                    DataAccess1.addcar(CarNo1, CarClass1, InTime1, PortNo1);
            }

            FormCollection fmCollection = System.Windows.Forms.Application.OpenForms;

            Panel PportA = (Panel)(fmCollection[0].Controls.Find("PportA", true)[0]);
            Panel PportB = (Panel)(fmCollection[0].Controls.Find("PportB", true)[0]);
            Panel PportC = (Panel)(fmCollection[0].Controls.Find("PportC", true)[0]);
            Panel Pdrawstate = (Panel)(fmCollection[0].Controls.Find("Pdrawstate", true)[0]);
            Panel panel1 = (Panel)(fmCollection[0].Controls.Find("panel1", true)[0]);
            PportA.Refresh();
            PportB.Refresh();
            PportC.Refresh();
            Pdrawstate.Refresh();
            panel1.Refresh();
            PportA.Controls.Clear();
            PportB.Controls.Clear();
            PportC.Controls.Clear();
            Draw1.drawport(PportA, "PortA");
            Draw1.drawport(PportB, "PortB");
            Draw1.drawport(PportC, "PortC");
            Draw1.drawstate(Pdrawstate);
            Draw1.drawpic(panel1);

            if (tempportno != "")
            {
                this.Close();
            }       
        }

        private void initial()
        {
            for (int i = 0; i < 10; i++)
            {
                Hour.Items.Add("0" + i);
            }
            for (int i = 10; i < 24; i++)
            {
                Hour.Items.Add(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Minute.Items.Add("0" + i);
            }
            for (int i = 10; i < 60; i++)
            {
                Minute.Items.Add(i);
            }

            CarClass.Items.Add("��");
            CarClass.Items.Add("�л�");
            CarClass.Items.Add("С��");
            tempportno = Draw1.myportno;
            if (tempportno != "")
            {
                this.Text = "������⣺��" + tempportno + "�ų�λ";

                if (tempportno.Substring(0, 1) == "A")
                {
                    CarClass.SelectedIndex = 0;
                    CarClass.Enabled = false;          
                }
                else if (tempportno.Substring(0, 1) == "B")
                {
                    CarClass.SelectedIndex = 1;
                    CarClass.Enabled = false;
                }
                else
                {
                    CarClass.SelectedIndex = 2;
                    CarClass.Enabled = false;
                }   
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarNo.Text = getCarNo();
        }

        private string getCarNo()
        {
            string text = functions1.Randhanzi() + functions1.RandEng(1) + "-" + functions1.RandNum(5);
            return text;       
        }

        private void FCarin_Activated(object sender, EventArgs e)
        {
            CarNo.Text = getCarNo();
            Hour.SelectedIndex = Convert.ToInt32(functions1.getOuttime().Substring(0, 2));
            Minute.SelectedIndex = Convert.ToInt32(functions1.getOuttime().Substring(3, 2));
        }

    }
}