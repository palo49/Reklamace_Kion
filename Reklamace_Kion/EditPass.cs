using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion
{
    public partial class EditPass : Form
    {

        public string MyName { get; set; }
        public EditPass()
        {
            InitializeComponent();
        }

        private void EditPass_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string newPassAgain = txtNewPassAgain.Text;

            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                var hash = sha2.ComputeHash(Encoding.UTF8.GetBytes(oldPass));
                {
                    string hexString = string.Empty;

                    for (int i = 0; i < hash.Length; i++)
                    {
                        hexString += hash[i].ToString("X2");
                    }
                    oldPass = hexString;
                }
            }

            SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"); // making connection
            SqlCommand cmd = new SqlCommand("select Password from Users where Name='" + MyName + "'", conn);
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
                    {
                        stringBuilder.AppendFormat("{0:X2}", b);
                    }
                    string hashString = stringBuilder.ToString();

                    if (hashString == oldPass)
                    {
                        // Correct name and password, continue code...

                        if ((newPass != string.Empty) && (newPass == newPassAgain))
                        {
                            MessageBox.Show("Změnit heslo...");
                        }
                        else
                        {
                            MessageBox.Show("Vyplňte všechna pole.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Špatné heslo.");
                    }
                }
                else
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
