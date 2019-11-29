using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get { if (instance == null)instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id) {
            List<Menu> listMenu = new List<Menu>();
            string query = "select s.name,bi.count,s.price,s.price*bi.count as Total from dbo.BillInfo as bi, dbo.Bill as b, dbo.San as s where bi.idBill = b.id and bi.idSan = s.id and b.status=0 and b.idTable =" + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows) {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }


            return listMenu;
        }
    }
}
