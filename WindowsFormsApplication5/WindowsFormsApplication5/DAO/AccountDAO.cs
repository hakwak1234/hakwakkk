using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    // đăng nhập
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set { instance = value; }

        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "' AND PassWord = N'"+ passWord +"'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, pass, newPass });

            return result > 0;
        }

        public Account GetAccountByUserName(string userName) {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from account where userName ='" + userName +"'");

            foreach(DataRow item in data.Rows){
                return new Account(item);
            }

            return null;

        }
    }
}
