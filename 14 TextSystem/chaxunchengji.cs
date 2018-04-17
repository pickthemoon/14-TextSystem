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
    public partial class chaxunchachengji : Form
    {
        public chaxunchachengji()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chaxunchachengji_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(local)\SQLEXPRESS; Initial Catalog=EXAMINF; Integrated Security=SSPI");
            String selectstr = "SELECT SGrade1, SGrade2, SGrade3, SGrade4 FROM Student WHERE SID = '" + username.usrname + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(selectstr, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            conn.Close();
            label6.Text = ds.Tables[0].Rows[0][0].ToString();
            label7.Text = ds.Tables[0].Rows[0][1].ToString();
            label8.Text = ds.Tables[0].Rows[0][2].ToString();
            label9.Text = ds.Tables[0].Rows[0][3].ToString();
            if (label6.Text == "")
            { label6.Text = "0"; }
            if (label7.Text == "")
            { label7.Text = "0"; }
            if (label8.Text == "")
            { label8.Text = "0"; }
            if (label9.Text == "")
            { label9.Text = "0"; }
            float sumgrade = canshu.a * Convert.ToSingle(label6.Text.Trim()) + canshu.b * Convert.ToSingle(label7.Text.Trim()) + canshu.c * Convert.ToSingle(label8.Text.Trim()) + canshu.d * Convert.ToSingle(label9.Text.Trim());
            label10.Text = Convert.ToString(sumgrade);
        }
    }
}
