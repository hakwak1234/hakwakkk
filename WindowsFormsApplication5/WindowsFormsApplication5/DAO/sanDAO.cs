using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    public class sanDAO
    {
        private static sanDAO instance;

        public static sanDAO Instance
        {
            get { if (instance == null)instance = new sanDAO(); return sanDAO.instance; }
            private set { sanDAO.instance = value; }
        }

        private sanDAO() { }

        public List<san> GetSanByCategoryID(int id)
        {
            List<san> list = new List<san>();

            string query = "select * from San where idCategory =" + id ;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                san san = new san(item);
                list.Add(san);
            }

            return list;
        }

        public List<san> GetListSan() {
            List<san> list = new List<san>();

            string query = "select * from San ";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                san san = new san(item);
                list.Add(san);
            }

            return list;
        }
        // thêm vào menu
        


        //sửa menu
        


        //xóa menu
        
    }
}
