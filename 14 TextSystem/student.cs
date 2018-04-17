using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _14_EXAMSYSTEM;

namespace _14_TextSystem
{
    public partial class student : Form
    {
        public student()
        {
            InitializeComponent();
        }

        private void 联系模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
           lianximoshi  mainfrom = new lianximoshi();
            mainfrom.ShowDialog();
            this.Show();
        }

        private void 正式考试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            kaoshixuanze mainfrom = new kaoshixuanze();
            mainfrom.ShowDialog();
            this.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sxiugaimima  mainfrom = new sxiugaimima ();
            mainfrom.ShowDialog();
            this.Show();
        }

        private void 退出登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 成绩查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chaxunchachengji  mainfrom = new chaxunchachengji ();
            mainfrom.Show();
            this.Show();
        }

        private void 退出登录ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
