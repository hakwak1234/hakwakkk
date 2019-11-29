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
    public partial class Form3 : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        public Form3(Account acc)
        {
            InitializeComponent();

            LoginAccount = acc;
        }

        void ChangeAccount(Account acc) {
            textBox1.Text = LoginAccount.UserName;
            textBox2.Text = LoginAccount.DisplayName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // cập nhật thông tin tài khoản
        void UpdateAccountInfo() {
            string displayName = textBox2.Text;
            string password =textBox3.Text;
            string newpass =textBox4.Text;
            string renewpass = textBox5.Text;
            string userName = textBox1.Text;

            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu mới!");
            }
            else {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Đã cập nhật");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
    public class AccountEvent : EventArgs {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc) {
            this.Acc = acc;
        }
    }
}
