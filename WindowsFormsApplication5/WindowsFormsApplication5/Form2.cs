using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication5.DAO;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }
        public Form2(Account acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;

            loadTable();
            LoadCategory();
            //LoadComboboxTable(comboBox3);
        }
        // bảng thông tin


        void ChangeAccount(int type) {
            danhSáchToolStripMenuItem.Enabled = type == 1;
            thôngTinToolStripMenuItem.Text += " (" + LoginAccount.DisplayName + ")";
        }

        #region Method
        void loadTable() 
        {
            flowLayoutPanel1.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click +=btn_Click;
                btn.Tag = item;
                //màu từng bàn
                switch (item.Status) { 
                    case "TRỐNG" :
                        btn.BackColor = Color.GreenYellow;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }

                flowLayoutPanel1.Controls.Add(btn);
            }

        }
        // thêm vào danh sách
        void LoadCategory() 
        {
            List<Thongtinsan> listThongtinsan = ThongtinsanDAO.Instance.GetListCategory();
            comboBox1.DataSource = listThongtinsan;
            comboBox1.DisplayMember = "Name";
        }


        void LoadSanListByCategoryID(int id) 
        {
            List<san> listSan = sanDAO.Instance.GetSanByCategoryID(id);
            comboBox2.DataSource = listSan;
            comboBox2.DisplayMember = "Name";
        }


        // cột trong bảng menu
        void Showbill(int id) 
        {
            listView1.Items.Clear();
            List<WindowsFormsApplication5.DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            // cho vào 1 biến tổng tiền
            float total = 0;
            foreach (WindowsFormsApplication5.DTO.Menu item in listBillInfo) 
            {
                ListViewItem lsvItem = new ListViewItem(item.Thongtin.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.Tongtien.ToString());
                total += item.Tongtien ;
                listView1.Items.Add(lsvItem);
               
            }
            //tổng thành tiền sang VNĐ
            CultureInfo culture = new CultureInfo("vi-VN");

            Thread.CurrentThread.CurrentCulture = culture;

            textBox1.Text = total.ToString("c");

           
        }

        void LoadComboboxTable(ComboBox cb) {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            listView1.Tag = (sender as Button).Tag;
            Showbill(tableID);
        }
        #endregion

        #region
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(LoginAccount);
            f3.UpdateAccount += f3_UpdateAccount;
            f3.ShowDialog();
        }

        void f3_UpdateAccount(object sender,AccountEvent e) { 
            thôngTinToolStripMenuItem.Text = " Thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void danhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;

            Thongtinsan selected = cb.SelectedItem as Thongtinsan;

            id = selected.ID;

            LoadSanListByCategoryID(id);
        }

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            int sanID = (comboBox2.SelectedItem as san).ID;
            int count = (int)numericUpDown1.Value;

            if (idBill == -1)
            {
                BillDAO.Instance.Insertbill(table.ID);
                BillInfoDAO.Instance.InsertbillInfo(BillDAO.Instance.GetMaxIDBill(), sanID, count);
            }
            else {
                BillInfoDAO.Instance.InsertbillInfo(idBill, sanID, count);
            }
            Showbill(table.ID);
            loadTable();
        }
        
        // thanh toán
        private void button2_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);

            double total = Convert.ToDouble(textBox1.Text.Split(',')[0]);
            double finalttp = total + 350000;


            if (idBill != -1){
                if (MessageBox.Show(String.Format("Đã nhận thanh toán {0} và cộng thêm 350k tiền sân ?", table.Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill,(float)finalttp);
                    Showbill(table.ID);
                    loadTable();
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        //chuyển sân
        //private void button4_Click(object sender, EventArgs e)
        //{
         //   int id1 = (listView1.Tag as Table).ID;
        //
         //   int id2 = (comboBox3.SelectedItem as Table).ID;
         //   if (MessageBox.Show(string.Format("Xác nhân chuyển {0} qua {1}", (listView1.Tag as Table).Name, (comboBox3.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK) ;
         //   TableDAO.Instance.SwitchTable(id1, id2);
        //
         //   loadTable();
        //}
    }
}
