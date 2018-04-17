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
    public partial class denglu : Form
    {
        public denglu()
        {
            InitializeComponent();
        }
        
        
        SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String tconstr = "SELECT * FROM Teacher WHERE TID = '" + textBox1.Text.Trim() + "' AND TPassword = '" + textBox2.Text.Trim() + "'";
                String sconstr = "SELECT * FROM Student WHERE SID = '" + textBox1.Text.Trim() + "' AND SPassword = '" + textBox2.Text.Trim() + "'";
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                { MessageBox.Show("请填写完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
                else
                {
                    if (radioButton1.Checked == true)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(tconstr, conn);
                        if (cmd.ExecuteScalar() != null)
                        {
                            username.usrname = textBox1.Text.Trim();
                            username.usrpassword = textBox2.Text.Trim();
                            this.Visible = false;
                            teacher teacher1 = new teacher();
                            teacher1.ShowDialog();
                            this.Show();
                        }
                        else
                        { MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else if (radioButton2.Checked == true)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sconstr, conn);
                        if (cmd.ExecuteScalar() != null)
                        {
                            username.usrname = textBox1.Text.Trim();
                            username.usrpassword = textBox2.Text.Trim();
                            this.Visible = false;
                            student student1 = new student();
                            student1.ShowDialog();
                            this.Show();
                        }
                        else
                        { MessageBox.Show("用户名或密码错误！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                    else
                    { MessageBox.Show("没有选择角色", "提示"); }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "警告"); }
            finally
            { conn.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void denglu_Load(object sender, EventArgs e)
        {
            conn.Open();
            String selectstr = "SELECT id, a, b, c, d, suma FROM canshu WHERE id = '0'";
            SqlCommand cmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "table");
            conn.Close();
            canshu.a = Convert.ToSingle(ds.Tables["table"].Rows[0][1]);
            canshu.b = Convert.ToSingle(ds.Tables["table"].Rows[0][2]);
            canshu.c = Convert.ToSingle(ds.Tables["table"].Rows[0][3]);
            canshu.d = Convert.ToSingle(ds.Tables["table"].Rows[0][4]);
            canshu.suma = Convert.ToInt32(ds.Tables["table"].Rows[0][5]);
        }
    }
}
