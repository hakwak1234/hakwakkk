
using System.Data;
namespace WindowsFormsApplication5.DTO
{
    // lấy dữ liệu từ SQL
    public class BillInfo
    {
        public BillInfo(int id, int billID, int idSan, int count) {
            this.ID = id;
            this.BillID = billID;
            this.IdSan = idSan;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.IdSan = (int)row["idSan"];
            this.Count = (int)row["count"];
        }


        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private int idSan;

        public int IdSan
        {
            get { return idSan; }
            set { idSan = value; }
        }

        private int billID;

        public int BillID {
            get { return billID; }
            set { billID = value; }
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
