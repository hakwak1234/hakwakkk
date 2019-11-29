using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5.DTO
{
    public class Menu
    {
        public Menu(string thongtin,int count,float price, float tongtien) {
            this.Thongtin = thongtin;
            this.Count = count;
            this.Price = price;
            this.Tongtien = tongtien;
        }

        public Menu(DataRow row)
        {
            this.Thongtin = row["name"].ToString();
            this.Count = (int)row["count"];
            this.Price = (float)Convert.ToDouble(row["price"]);
            this.Tongtien = (float)Convert.ToDouble(row["total"]);
        }

        private float tongtien;

        public float Tongtien
        {
            get { return tongtien; }
            set { tongtien = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string thongtin;

        public string Thongtin
        {
            get { return thongtin; }
            set { thongtin = value; }
        }
    }
}
