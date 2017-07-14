using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Search;

namespace CarManager
{
    public partial class Fportstate : Form
    {
        Draw Draw1 = new Draw();
        DataAccess DataAccess1 = new DataAccess();
        Functions functions1 = new Functions();

        public Fportstate()
        {
            InitializeComponent();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fabout = new Fabout();
            Fabout.ShowDialog();
        }

        private void 车辆入库ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Draw1.myportno = "";
            Form FCarin = new FCarin();
            FCarin.Show();
        }

        private void 费率管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Ffare = new Ffare();
            Ffare.ShowDialog();
        }

        private void 容量管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fcapacity = new Fcapacity();
            Fcapacity.ShowDialog();
        }

        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form Fhelp = new Fhelp();
            Fhelp.ShowDialog();
        }

        private void Fportstate_Shown(object sender, EventArgs e)
        {
            PportA.Controls.Clear();
            PportB.Controls.Clear();
            PportC.Controls.Clear();

            PportA.Refresh();
            PportB.Refresh();
            PportC.Refresh();
            Pdrawdetail.Refresh();
            Pdrawstate.Refresh();
            panel1.Refresh();

            Draw1.drawport(PportA, "PortA");
            Draw1.drawport(PportB, "PortB");
            Draw1.drawport(PportC, "PortC");
            Draw1.drawdetail(Pdrawdetail, "axis");
            Draw1.drawstate(Pdrawstate);
            Draw1.drawpic(panel1);

            PportA.MouseDoubleClick += new MouseEventHandler(Draw1.addcar);
            PportB.MouseDoubleClick += new MouseEventHandler(Draw1.addcar);
            PportC.MouseDoubleClick += new MouseEventHandler(Draw1.addcar);

            PportA.Paint += new PaintEventHandler(Now_Paint);
            PportB.Paint += new PaintEventHandler(Now_Paint);
            PportC.Paint += new PaintEventHandler(Now_Paint);
            Pdrawdetail.Paint += new PaintEventHandler(Now_Paint);
            Pdrawstate.Paint += new PaintEventHandler(Now_Paint);
            panel1.Paint += new PaintEventHandler(Now_Paint);
        }

        void Now_Paint(object sender, PaintEventArgs e)
        {
            if (((Panel)sender).Name == "PportA")
            {
                Draw1.drawport((Panel)sender, "PortA");
            }
            else if (((Panel)sender).Name == "PportB")
            {
                Draw1.drawport((Panel)sender, "PortB");
            }
            else if (((Panel)sender).Name == "PportC")
            {
                Draw1.drawport((Panel)sender, "PortC");
            }
            else if (((Panel)sender).Name == "Pdrawdetail")
            {
                int arrayno = DataAccess1.getDataNum("CarIn");
                string[] Cararray = new string[arrayno];
                Cararray = DataAccess1.getCarNo();

                Panel[] panelarray = new Panel[arrayno];

                for (int i = 0; i < arrayno; i++)
                {
                    panelarray[i] = (Panel)(panel1.FindForm().Controls.Find(Cararray[i], true)[0]);

                    if (panelarray[i].BackColor == Color.Red)
                    {
                        Draw1.drawdetail(Pdrawdetail, panelarray[i].Name); 
                    }
                }                          
            }
            else if (((Panel)sender).Name == "Pdrawstate")
            {
                Draw1.drawstate(Pdrawstate);
            }
            else
            {
                Draw1.drawpic(panel1);        
            }
        }

        private void 车辆管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Fdata = new Fdata();
            Fdata.Show();
        }

        private void 出入日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Flog = new Flog();
            Flog.Show();
        }

        private void 重置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("是否重置应用程序？", "请确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                functions1.ProgramReset();
            }


        }

        private void 清零ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult MsgBoxResult;
            MsgBoxResult = MessageBox.Show("是否清零全部数据？", "请确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (MsgBoxResult == DialogResult.OK)
            {
                functions1.ProgramDataClear();
            }

        }

        private void 版权ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AboutBox1 = new AboutBox1();
            AboutBox1.ShowDialog();
        }

        private void 车辆出库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 会员信息ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form infor = new infor();
            infor.Show();
        }

        private void 会员管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Form infor = new infor();
            infor.Show();
        }

 



    }
}