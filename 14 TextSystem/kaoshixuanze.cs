using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _14_TextSystem;
using System.Data.SqlClient;
using _14_EXAMSYSTEM;

namespace _14_EXAMSYSTEM
{
    public partial class kaoshixuanze : Form
    {
        public kaoshixuanze()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("请选择考试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (comboBox1.Text == "月考一")
                    username.kaoshi = "SGrade1";
                if (comboBox1.Text == "期中考试")
                    username.kaoshi = "SGrade2";
                if (comboBox1.Text == "月考二")
                    username.kaoshi = "SGrade3";
                if (comboBox1.Text == "期末考试")
                    username.kaoshi = "SGrade4";

                //设置连接参数
                SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
                String selectstr = "SELECT COUNT(*) FROM Student WHERE " + username.kaoshi + " = '' AND SID = '" + username.usrname + "'";
                SqlCommand checkcmd = new SqlCommand(selectstr, conn);
                conn.Open();
                if (checkcmd.ExecuteScalar().Equals(1))
                {
                    this.Visible = false;
                    this.Close();
                    zhengshikaoshi Mainfrom = new zhengshikaoshi();
                    Mainfrom.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("你已参加过这次考试！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
