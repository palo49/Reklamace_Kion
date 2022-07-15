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
using System.Security.Cryptography;

namespace Reklamace_Kion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string Pass = txtPass.Text;

            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                var hash = sha2.ComputeHash(Encoding.UTF8.GetBytes(Pass));
                {
                    string hexString = string.Empty;

                    for (int i = 0; i < hash.Length; i++)
                    {
                        hexString += hash[i].ToString("X2");
                    }
                    Pass = hexString;
                }
            }

            SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"); // making connection
            SqlCommand cmd = new SqlCommand("select Password from Users where Name='" + Name + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);


            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    byte[] PassByte = (byte[])reader[0];

                    StringBuilder stringBuilder = new StringBuilder();

                    foreach (byte b in PassByte)
                        stringBuilder.AppendFormat("{0:X2}", b);

                    string hashString = stringBuilder.ToString();

                    if (hashString == Pass)
                    {
                        // Correct name and password, continue code...

                        this.Hide();
                        Main MainForm = new Main();
                        MainForm.Show();

                    }else
                    {
                        MessageBox.Show("Špatné heslo.");
                    }
                } else
                {
                    MessageBox.Show("Uživatel nenalezen.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            conn.Close();
        }
    }
}
