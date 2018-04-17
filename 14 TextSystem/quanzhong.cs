using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _14_EXAMSYSTEM;
using System.Data.SqlClient;

namespace _14_EXAMSYSTEM
{
    public partial class quanzhong : Form
    {
        public quanzhong()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                { MessageBox.Show("请填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (Convert.ToSingle(textBox1.Text.Trim()) > 1 || Convert.ToSingle(textBox2.Text.Trim()) > 1 || Convert.ToSingle(textBox3.Text.Trim()) > 1 || Convert.ToSingle(textBox4.Text.Trim()) > 1 || Convert.ToSingle(textBox1.Text.Trim()) < 0 || Convert.ToSingle(textBox1.Text.Trim()) < 0 || Convert.ToSingle(textBox1.Text.Trim()) < 0 || Convert.ToSingle(textBox1.Text.Trim()) < 0)
                { MessageBox.Show("请输入0~1之间的数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (Convert.ToString(Convert.ToSingle(textBox1.Text.Trim()) + Convert.ToSingle(textBox2.Text.Trim()) + Convert.ToSingle(textBox3.Text.Trim()) + Convert.ToSingle(textBox4.Text.Trim())) != "1")
                { MessageBox.Show("系数之和不为1", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    canshu.a = Convert.ToSingle(textBox1.Text.Trim());
                    canshu.b = Convert.ToSingle(textBox2.Text.Trim());
                    canshu.c = Convert.ToSingle(textBox3.Text.Trim());
                    canshu.d = Convert.ToSingle(textBox4.Text.Trim());
                    SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
                    String str = "UPDATE canshu SET a ='" + canshu.a + "',b = '" + canshu.b + "', c = '" + canshu.c + "',d = '" + canshu.d + "' WHERE id = '0'";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(str, conn);
                    if (cmd.ExecuteNonQuery() == 1)
                    { MessageBox.Show("修改成功", "提示"); }
                    conn.Close();
                    this.Close();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
