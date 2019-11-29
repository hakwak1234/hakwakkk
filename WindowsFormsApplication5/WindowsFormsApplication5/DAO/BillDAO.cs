using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { 
        
        }

        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where idTable = " + id + "AND status = 0");

            if (data.Rows.Count > 0)
            { 
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOut(int id,float totalPrice) 
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE(), status = 1 ,totalPrice = "+ totalPrice +" where id =" + id ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut) 
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkIn , @checkOut ", new object[] { checkIn, checkOut });
        }

        public void Insertbill(int id) 
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] {id});
        }

        public int GetMaxIDBill() {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("Select max(id) from dbo.bill");
            }
            catch {
                return 1;
            }
        }
    }
}
