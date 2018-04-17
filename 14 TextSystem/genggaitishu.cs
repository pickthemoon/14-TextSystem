using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _14_EXAMSYSTEM
{
    public partial class genggaitishu : Form
    {
        public genggaitishu()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
        private int tishu = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void genggaitishu_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Question", conn);
            tishu = Convert.ToInt32(cmd.ExecuteScalar());
            groupBox1.Text = "请输入考试的总题数（题库中现有" + tishu.ToString() + "题）";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "")
                { MessageBox.Show("请填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else if (Convert.ToInt32(textBox1.Text.Trim()) > tishu)
                { MessageBox.Show("超出总题数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    conn.Open();
                    SqlCommand sumacmd = new SqlCommand("UPDATE canshu SET suma = '" + Convert.ToInt32(textBox1.Text.Trim()) + "' WHERE id = '0'", conn);
                    if (sumacmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("修改成功！", "提示");
                        conn.Close();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally
            { }
        }
    }
}
