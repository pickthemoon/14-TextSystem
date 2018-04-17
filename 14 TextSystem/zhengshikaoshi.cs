using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _14_EXAMSYSTEM;

namespace _14_TextSystem
{
    public partial class zhengshikaoshi : Form
    {
        public zhengshikaoshi()
        {
            InitializeComponent();
        }

        //设置连接参数
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        String selectstr = "SELECT TOP " + canshu.suma + " QDetail, QOptionA, QOptionB, QOptionC, QOptionD, QAnswer, NewID() AS id FROM Question ORDER BY id";
        DataSet myds = new DataSet("table");
        int a = 0;
        String[] myanswers = new String[canshu.suma];

        private void button3_Click(object sender, EventArgs e)
        {
            String myanswer = null;
            if (radioButton1.Checked == true)
                myanswer = "A";
            if (radioButton2.Checked == true)
                myanswer = "B";
            if (radioButton3.Checked == true)
                myanswer = "C";
            if (radioButton4.Checked == true)
                myanswer = "D";
            myanswers[a] = myanswer;
            if (Array.IndexOf(myanswers, null) == -1)
            {
                if (MessageBox.Show("是否提交试卷？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Visible = false;
                    int i, myscore;
                    myscore = 0;
                    for (i = 0; i < canshu.suma; i++)
                        if (myanswers[i] == myds.Tables["table"].Rows[i][5].ToString())
                        { myscore++; }
                    double result = Math.Round((double)myscore / canshu.suma, 2);
                    conn.Open();
                    SqlCommand updatecmd = new SqlCommand("UPDATE Student SET " + username.kaoshi + " = " + Convert.ToString(result*100) + " WHERE SID = '" + username.usrname + "'", conn);
                    if (updatecmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("你的成绩为" + result * 100 + "", "提示");
                    }
                    conn.Close();
                    this.Close();
                    chaxunchachengji Mainfrom = new chaxunchachengji();
                    Mainfrom.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("第" + Convert.ToString(Array.IndexOf(myanswers, null) + 1) + "题还未完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zhengshikaoshi_Load(object sender, EventArgs e)
        {
            myds.Clear();
            conn.Open();
            SqlCommand dscmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(dscmd);
            adp.Fill(myds, "table");
            conn.Close();
            label1.Text = myds.Tables["table"].Rows[a][0].ToString();
            label2.Text = myds.Tables["table"].Rows[a][1].ToString();
            label3.Text = myds.Tables["table"].Rows[a][2].ToString();
            label4.Text = myds.Tables["table"].Rows[a][3].ToString();
            label5.Text = myds.Tables["table"].Rows[a][4].ToString();
            label6.Text = "第" + Convert.ToString(a + 1) + "题，共" + Convert.ToString(canshu.suma) + "题";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a <= 0)
            { MessageBox.Show("这是第一题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                String myanswer = null;
                if (radioButton1.Checked == true)
                    myanswer = "A";
                if (radioButton2.Checked == true)
                    myanswer = "B";
                if (radioButton3.Checked == true)
                    myanswer = "C";
                if (radioButton4.Checked == true)
                    myanswer = "D";
                myanswers[a] = myanswer;
                a--;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                label1.Text = myds.Tables["table"].Rows[a][0].ToString();
                label2.Text = myds.Tables["table"].Rows[a][1].ToString();
                label3.Text = myds.Tables["table"].Rows[a][2].ToString();
                label4.Text = myds.Tables["table"].Rows[a][3].ToString();
                label5.Text = myds.Tables["table"].Rows[a][4].ToString();
                label6.Text = "第" + Convert.ToString(a + 1) + "题，共" + Convert.ToString(canshu.suma) + "题";
                if (myanswers[a] == "A")
                    radioButton1.Checked = true;
                if (myanswers[a] == "B")
                    radioButton2.Checked = true;
                if (myanswers[a] == "C")
                    radioButton3.Checked = true;
                if (myanswers[a] == "D")
                    radioButton4.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (a >= canshu.suma - 1)
            { MessageBox.Show("这是最后一题！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                String myanswer = null;
                if (radioButton1.Checked == true)
                    myanswer = "A";
                if (radioButton2.Checked == true)
                    myanswer = "B";
                if (radioButton3.Checked == true)
                    myanswer = "C";
                if (radioButton4.Checked == true)
                    myanswer = "D";
                myanswers[a] = myanswer;
                a++;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                label1.Text = myds.Tables["table"].Rows[a][0].ToString();
                label2.Text = myds.Tables["table"].Rows[a][1].ToString();
                label3.Text = myds.Tables["table"].Rows[a][2].ToString();
                label4.Text = myds.Tables["table"].Rows[a][3].ToString();
                label5.Text = myds.Tables["table"].Rows[a][4].ToString();
                label6.Text = "第" + Convert.ToString(a + 1) + "题，共" + Convert.ToString(canshu.suma) + "题";
                if (myanswers[a] == "A")
                    radioButton1.Checked = true;
                if (myanswers[a] == "B")
                    radioButton2.Checked = true;
                if (myanswers[a] == "C")
                    radioButton3.Checked = true;
                if (myanswers[a] == "D")
                    radioButton4.Checked = true;
            }
        }
    }
}
