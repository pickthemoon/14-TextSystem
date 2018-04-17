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
    public partial class shitiguanli : Form
    {
        public shitiguanli()
        {
            InitializeComponent();
        }

        //设置连接参数
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        String selectstr = "SELECT QID 题目编号, QDetail 题干, QOptionA 选项A, QOptionB 选项B, QOptionC 选项C, QOptionD 选项D, QAnswer 答案, QKnowledgePoint 知识点 FROM Question";

        private void shititianjia_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“eXAMINFDataSet.Knowledge”中。您可以根据需要移动或删除它。
            this.knowledgeTableAdapter.Fill(this.eXAMINFDataSet.Knowledge);
            conn.Open();
            SqlCommand cmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "")
                { MessageBox.Show("请填必要信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    String insert = "INSERT INTO Question VALUES ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + textBox5.Text.Trim() + "', '" + comboBox1.Text.Trim() + "', '" + comboBox2.Text.Trim() + "')";
                    conn.Open();
                    SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Knowledge WHERE KName = '" + comboBox2.Text.Trim() + "'", conn);
                    checkcmd.ExecuteNonQuery();
                    if (checkcmd.ExecuteScalar().Equals(1) && (comboBox1.Text.ToString().Contains("A").Equals(true) || comboBox1.Text.ToString().Contains("B").Equals(true) || comboBox1.Text.ToString().Contains("C").Equals(true) || comboBox1.Text.ToString().Contains("D").Equals(true)))
                    {
                        SqlCommand insertcmd = new SqlCommand(insert, conn);
                        if (insertcmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("添加成功", "提示"); }
                    }
                    else
                    { MessageBox.Show("请选择下拉框中的选项！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            {
                SqlCommand cmd = new SqlCommand(selectstr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "")
                { MessageBox.Show("请填必要信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    conn.Open();
                    SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Knowledge WHERE KName = '" + comboBox2.Text.Trim() + "'", conn);
                    checkcmd.ExecuteNonQuery();
                    if (checkcmd.ExecuteScalar().Equals(1) && (comboBox1.Text.ToString().Contains("A").Equals(true) || comboBox1.Text.ToString().Contains("B").Equals(true) || comboBox1.Text.ToString().Contains("C").Equals(true) || comboBox1.Text.ToString().Contains("D").Equals(true)))
                    {
                        SqlCommand updatecmd = new SqlCommand("UPDATE Question SET QDetail = '" + textBox1.Text.Trim() + "', QOptionA = '" + textBox2.Text.Trim() + "', QOptionB = '" + textBox3.Text.Trim() + "', QOptionC = '" + textBox4.Text.Trim() + "', QOptionD = '" + textBox5.Text.Trim() + "', QAnswer = '" + comboBox1.Text.Trim() + "', QKnowledgePoint = '" + comboBox2.Text.Trim() + "' WHERE QID = '" + label8.Text + "'", conn);
                        if (updatecmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("修改成功", "提示"); }
                    }
                    else
                    { MessageBox.Show("请选择下拉框中的选项！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            {
                SqlCommand cmd = new SqlCommand(selectstr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (MessageBox.Show("确认删除本题？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlCommand deletecmd = new SqlCommand("DELETE FROM Question WHERE QDetail ='" + textBox1.Text.Trim() + "'", conn);
                    if (deletecmd.ExecuteNonQuery() == 1)
                    { MessageBox.Show("删除成功", "提示"); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            {
                SqlCommand cmd = new SqlCommand(selectstr, conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                this.dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            genggaitishu genggaitishu1 = new genggaitishu();
            genggaitishu1.ShowDialog();
            this.Show();
        }
    }
}
