﻿using System;
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

        int ver = 0;
        string version = string.Empty;

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
            SqlCommand cmd = new SqlCommand("select Password, Level from Users where Name='" + Name + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommand cmdService = new SqlCommand("select Activated from AppSettings where Name='ServiceMode'", conn);
            SqlCommand cmdVersion = new SqlCommand("select Value from AppSettings where Name='Version'", conn);

            try
            {
                conn.Open();


                bool ServiceMode = Convert.ToBoolean(cmdService.ExecuteScalar());
                string VersionSQL = cmdVersion.ExecuteScalar().ToString();
                int verSQL = Convert.ToInt32(VersionSQL.Replace(".", ""));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] PassByte = (byte[])reader[0];

                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (byte b in PassByte)
                        {
                            stringBuilder.AppendFormat("{0:X2}", b);
                        }
                        string hashString = stringBuilder.ToString();

                        if (hashString == Pass)
                        {
                            // Correct name and password, continue code...

                            Properties.Settings.Default.Name = Name;

                            Properties.Settings.Default.Save();

                            this.Hide();

                            if (ServiceMode == true)
                            {
                                var res = MessageBox.Show("Aplikace je v servisním módu a bude nějakou dobu nedostupná. V případě dotazu kontaktujte administrátora aplikace.", "Údržba aplikace", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                if (res == DialogResult.OK)
                                {
                                    if (Convert.ToInt16(reader[1]) == 100) // User level == 100
                                    {
                                        Main MainForm = new Main();

                                        MainForm.MyName = Name;
                                        MainForm.DisableExit = false;

                                        MainForm.Show();
                                    }
                                    else
                                    {
                                        conn.Close();
                                        Environment.Exit(0);
                                    }
                                }
                            }
                            else
                            {
                                if (ver >= verSQL)
                                {
                                    Main MainForm = new Main();

                                    MainForm.MyName = Name;
                                    MainForm.DisableExit = false;

                                    MainForm.Show();
                                }
                                else
                                {
                                    var res = MessageBox.Show("Byla vydána nová verze aplikace a je potřeba ji aktualizovat.\n\nVaše verze je " + version + "\nNová verze je " + VersionSQL, "Verze aplikace", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    if (res == DialogResult.OK)
                                    {
                                        if (Convert.ToInt16(reader[1]) == 100) // User level == 100
                                        {
                                            Main MainForm = new Main();

                                            MainForm.MyName = Name;
                                            MainForm.DisableExit = false;

                                            MainForm.Show();
                                        }
                                        else
                                        {
                                            conn.Close();
                                            Environment.Exit(0);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Zadali jste špatné heslo.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Uživatel nenalezen.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            conn.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtName.Text = Properties.Settings.Default.Name;

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            version = fvi.FileVersion;
            ver = Convert.ToInt32(version.Replace(".", ""));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
