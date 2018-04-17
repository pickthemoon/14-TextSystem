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
    public partial class xueshengguanli : Form
    {
        public xueshengguanli()
        {
            InitializeComponent();
        }

        //设置连接参数
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        String selectstr = "SELECT SID 学号, SName 姓名, SPassword 密码, SGrade1 月考一成绩, SGrade2 期中考成绩, SGrade3 月考二成绩, SGrade4 期末考成绩 FROM Student";

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE SID = '" + textBox1.Text.Trim() + "'", conn);
                checkcmd.ExecuteNonQuery();
                if (checkcmd.ExecuteScalar().Equals(0))
                { MessageBox.Show("学号不存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }
                else
                {
                    if (MessageBox.Show("确认删除学号为" + textBox1.Text.Trim() + "、姓名为" + textBox2.Text.Trim() + "的学生信息？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        SqlCommand deletecmd = new SqlCommand("DELETE FROM Student WHERE SID ='" + textBox1.Text.Trim() + "'", conn);
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

        private void xueshengguanli_Load(object sender, EventArgs e)
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
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString(); 
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            String a = textBox4.Text.Trim();
            String b = textBox5.Text.Trim();
            String c = textBox6.Text.Trim();
            String d = textBox7.Text.Trim();
            if(a == "")
            { a = "0"; }
            if(b == "")
            { b = "0"; }
            if(c == "")
            { c = "0"; }
            if(d == "")
            { d = "0"; }
            float sumgrade = canshu.a * Convert.ToSingle(a) + canshu.b * Convert.ToSingle(b) + canshu.c * Convert.ToSingle(c) + canshu.d * Convert.ToSingle(d);
            label9.Text = a + " * " + canshu.a + " + " + b + " * " + canshu.b + " + " + c + " * " + canshu.c + " + " + d + " * " + canshu.d + " = " + sumgrade.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                { MessageBox.Show("填写学号、姓名及密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    String insert = "INSERT INTO Student VALUES ('" + textBox1.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" + textBox7.Text.Trim() + "')";
                    conn.Open();
                    SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE SID = '" + textBox1.Text.Trim() + "'", conn);
                    checkcmd.ExecuteNonQuery();
                    if (checkcmd.ExecuteScalar().Equals(1))
                    { MessageBox.Show("学号已存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                    else
                    {
                        SqlCommand insertcmd = new SqlCommand(insert, conn);
                        if (insertcmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("添加成功", "提示"); }
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                { MessageBox.Show("请填写学号、姓名及密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    conn.Open();
                    SqlCommand checkcmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE SID = '" + textBox1.Text.Trim() + "'", conn);
                    checkcmd.ExecuteNonQuery();
                    if (checkcmd.ExecuteScalar().Equals(0))
                    { MessageBox.Show("学号不存在！", "错误", MessageBoxButtons.OKCancel, MessageBoxIcon.Error); }
                    else
                    {
                        SqlCommand updatecmd = new SqlCommand("UPDATE Student SET SName = '" + textBox2.Text.Trim() + "', SPassword = '" + textBox3.Text.Trim() + "', SGrade1 = '" + textBox4.Text.Trim() + "', SGrade2 = '" + textBox5.Text.Trim() + "', SGrade3 = '" + textBox6.Text.Trim() + "', SGrade4 = '" + textBox7.Text.Trim() + "' WHERE SID = '" + textBox1.Text.Trim() + "'", conn);
                        if (updatecmd.ExecuteNonQuery() == 1)
                        { MessageBox.Show("修改成功", "提示"); }
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            quanzhong quanzhong1 = new quanzhong();
            quanzhong1.ShowDialog();
            this.Show();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点
            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else
                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)
                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }//判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点

            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else

                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)

                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }

            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点
            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else
                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)
                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点
            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else
                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)
                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。

            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)

                e.Handled = true;

            //小数点的处理。

            if ((int)e.KeyChar == 46)                           //小数点
            {

                if (textBox1.Text.Length <= 0)

                    e.Handled = true;   //小数点不能在第一位

                else
                {

                    float f;

                    float oldf;

                    bool b1 = false, b2 = false;

                    b1 = float.TryParse(textBox1.Text, out oldf);

                    b2 = float.TryParse(textBox1.Text + e.KeyChar.ToString(), out f);

                    if (b2 == false)
                    {

                        if (b1 == true)

                            e.Handled = true;

                        else

                            e.Handled = false;

                    }

                }

            }
        }
    }
}
