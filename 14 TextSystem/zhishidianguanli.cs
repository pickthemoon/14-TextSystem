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
    public partial class zhishidianguanli : Form
    {
        public zhishidianguanli()
        {
            InitializeComponent();
        }

        //设置连接参数
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        String selectstr = "SELECT KName 名称, KChapter 章, KSection 节 FROM Knowledge";

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zhishidianguanli_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            { MessageBox.Show("填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                try
                {
                    String insert = "INSERT INTO Knowledge VALUES ('" + textBox1.Text.Trim() + "', '" + comboBox1.Text.Trim() + "', '" + comboBox2.Text.Trim() + "')";
                    conn.Open();
                    SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Knowledge WHERE KName = '" + textBox1.Text.Trim() + "'", conn);
                    checkcmd.ExecuteNonQuery();
                    if (checkcmd.ExecuteScalar().Equals(1))
                    { MessageBox.Show("知识点已存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                    else
                    {
                        SqlCommand insertcmd = new SqlCommand(insert, conn);
                        if (insertcmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("添加成功", "提示"); }
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "")
            { MessageBox.Show("填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            try
            {
                conn.Open();
                SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Knowledge WHERE KName = '" + textBox1.Text.Trim() + "'", conn);
                checkcmd.ExecuteNonQuery();
                if (checkcmd.ExecuteScalar().Equals(0))
                { MessageBox.Show("知识点不存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                else
                {
                    SqlCommand updatecmd = new SqlCommand("UPDATE Knowledge SET KChapter = '" + comboBox1.Text.Trim() + "', KSection = '" + comboBox2.Text.Trim() + "' WHERE KName = '" + textBox1.Text.Trim() + "'" , conn);
                    if (updatecmd.ExecuteNonQuery() == 1)
                    { MessageBox.Show("修改成功", "提示"); }
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Knowledge WHERE KName = '" + textBox1.Text.Trim() + "'", conn);
                checkcmd.ExecuteNonQuery();
                if (checkcmd.ExecuteScalar().Equals(0))
                { MessageBox.Show("知识点不存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
                else
                {
                    if (MessageBox.Show("确认删除名称为" + textBox1.Text.Trim() + "的知识点信息？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlCommand deletecmd = new SqlCommand("DELETE FROM Knowledge WHERE KName ='" + textBox1.Text.Trim() + "'", conn);
                        if (deletecmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("删除成功", "提示"); }
                    }
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
