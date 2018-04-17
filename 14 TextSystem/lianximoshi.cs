using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _14_TextSystem
{
    public partial class lianximoshi : Form
    {
        public lianximoshi()
        {
            InitializeComponent();
        }

        //设置连接参数

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        String selectstr = "SELECT TOP 1 QDetail, QOptionA, QOptionB, QOptionC, QOptionD, QAnswer, QKnowledgePoint FROM Question ORDER BY NewID()";
        DataSet myds = new DataSet("table");

        private void lianximoshi_Load(object sender, EventArgs e)
        {
            myds.Clear();
            conn.Open();
            SqlCommand dscmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(dscmd);
            adp.Fill(myds, "table");
            conn.Close();
            label1.Text = myds.Tables["table"].Rows[0][0].ToString();
            label2.Text = myds.Tables["table"].Rows[0][1].ToString();
            label3.Text = myds.Tables["table"].Rows[0][2].ToString();
            label4.Text = myds.Tables["table"].Rows[0][3].ToString();
            label5.Text = myds.Tables["table"].Rows[0][4].ToString();
            label6.Text = "本题知识点：" + myds.Tables["table"].Rows[0][6].ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String answer = null;
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false && radioButton4.Checked == false)
            { MessageBox.Show("请完成题目！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else
            {
                if (radioButton1.Checked == true)
                { answer = "A"; }
                if (radioButton2.Checked == true)
                { answer = "B"; }
                if (radioButton3.Checked == true)
                { answer = "C"; }
                if (radioButton4.Checked == true)
                { answer = "D"; }
                if (answer.Equals(myds.Tables["table"].Rows[0][5].ToString()) == true)
                { MessageBox.Show("答案正确", "提示"); }
                else
                { MessageBox.Show("答案错误，正确答案为 " + myds.Tables[0].Rows[0][5].ToString() + " !", "错误"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            lianximoshi_Load(null, null);
        }
    }
}
