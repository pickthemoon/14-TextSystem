using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _14_TextSystem
{
    public partial class teacher : Form
    {
        public teacher()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void toolStripMenuItem3_Click(object sender, EventArgs e)
       {
           this.Visible = false;
           txiugaimima  Mainfrom = new txiugaimima ();
           Mainfrom.ShowDialog();
           this.Show();
       }

       private void 试题管理ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           this.Visible = false;
           shitiguanli mainfrom = new shitiguanli();
           mainfrom.ShowDialog();
           this.Show();
       }

       private void 学生添加ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           this.Visible = false;
           xueshengguanli mainfrom = new xueshengguanli();
           mainfrom.ShowDialog();
           this.Show();
       }

       private void 知识点管理ToolStripMenuItem_Click(object sender, EventArgs e)
       {
           this.Visible = false;
           zhishidianguanli mainfrom = new zhishidianguanli();
           mainfrom.ShowDialog();
           this.Show();
       }

       private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
       {
           txiugaimima txiugaimima1 = new txiugaimima();
           txiugaimima1.ShowDialog();
           this.Show();
       }
    }
}
