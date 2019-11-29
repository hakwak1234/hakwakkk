using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication5.DAO;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string passWord = textBox2.Text;
            if (Login(userName,passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                Form2 f2 = new Form2(loginAccount);
                this.Hide();
                f2.Show();
            }
            else { 
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu");
            }
        }

        bool Login(string userName,string passWord) {
            return AccountDAO.Instance.Login(userName,passWord);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
