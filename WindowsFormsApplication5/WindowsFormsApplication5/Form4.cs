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
using WindowsFormsApplication5.DAO;

namespace WindowsFormsApplication5
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut) {
            dataGridView1.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);

        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void LoadListSan() {
            dataGridView2.DataSource = sanDAO.Instance.GetListSan();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadListSan();
        }
    }
}
