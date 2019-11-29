using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5.DAO
{
    public class ThongtinsanDAO
    {
        private static ThongtinsanDAO instance;

        public static ThongtinsanDAO Instance
        {
            get { if (instance == null)instance = new ThongtinsanDAO(); return ThongtinsanDAO.instance; }
            private set { ThongtinsanDAO.instance = value; }
        }

        private ThongtinsanDAO() { }

        public List<Thongtinsan> GetListCategory() {
            List<Thongtinsan> list = new List<Thongtinsan>();

            string query = "select * from Thongtinsan";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                Thongtinsan category = new Thongtinsan(item);
                list.Add(category);
            }
            return list;
        }

    }
}
