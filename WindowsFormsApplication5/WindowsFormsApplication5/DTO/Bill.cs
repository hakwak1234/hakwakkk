using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckOut, int status) {
            this.ID = id;
            this.DateCheckIn = dateCheckin;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
        }

        public Bill(DataRow row) {
            this.ID = (int)row["id"];
            this.DateCheckIn = (DateTime?)row["dateCheckin"];
            var dateCheckOutTemp = row["dateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = status;
        }
        
        private int status;

        public int Status {
            get { return status; }
            set { status = value; }
        }

        private DateTime? dateCheckOut;

        private DateTime? DateCheckOut {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
            // kiểu dữ liệu ? có thể cho phép null dc

        private DateTime? dateCheckIn;

        public DateTime? DateCheckIn {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        private int iD;

        public int ID {
            get { return iD; }
            set { iD = value; }
        }


    }
}
