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
    public partial class txiugaimima : Form
    {
        public txiugaimima()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
                { MessageBox.Show("请填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (textBox2.Text != textBox3.Text)
                { MessageBox.Show("两次输入新密码不一致！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (textBox1.Text != username.usrpassword)
                { MessageBox.Show("原密码错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else if (textBox1.Text.Equals(textBox2.Text))
                { MessageBox.Show("新密码与原密码相同！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    SqlCommand pwmodify = new SqlCommand("UPDATE Teacher SET TPassword = '" + textBox2.Text.Trim() + "' WHERE TID = '" + username.usrname + "'", conn);
                    conn.Open();
                    if (pwmodify.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("修改成功", "提示");
                        username.usrpassword = textBox2.Text.Trim();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            { conn.Close(); }
        }
    }
}
