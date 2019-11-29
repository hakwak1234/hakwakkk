using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        //lấy id của bill
        public List<BillInfo> GetListBillInfo(int id) 
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Billinfo where idBill = " + id );
            
            foreach (DataRow item in data.Rows) {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            
            return listBillInfo;
        }

        public void InsertbillInfo(int idBill,int idSan,int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idSan , @count", new object[] { idBill, idSan,count });
        }
    }
}
