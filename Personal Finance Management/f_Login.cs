using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personal_Finance_Management
{
    public partial class f_Login : Form
    {
        public f_Login()
        {
            InitializeComponent();
        }

        private void B_Login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-18U402B\LINGZ;Initial Catalog='Personal Finance Management';Integrated Security=True");
            try
            {
                
                string userName = tb_Username.Text;
                string passWord = tb_Password.Text;

                

                if ((tb_Username.Text=="") && (tb_Password.Text==""))
                {
                    MessageBox.Show("Vui lòng không để trống");
                }
                else
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM Accounts WHERE usr_Userame='" + userName + "' AND usr_Password='" + passWord + "' ";
                    SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                    SqlDataReader data = cmd.ExecuteReader();
                    if (data.Read() == true)
                    {
                        f_Main f = new f_Main();
                        f.ShowDialog();
                        tb_Username.Text = "";
                        tb_Password.Text = "";
                        //tb_Username.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi kết nối1 !");
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối !");
            }
        }
    }
}
