﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication5.DTO;

namespace WindowsFormsApplication5.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }
        private TableDAO() { 
            
        }
        // kích thước ô sân trong bảng
        public static int TableWidth = 82;
        public static int TableHeight = 82;
        //danh sách bàn

        public void SwitchTable(int id1, int id2) {
            DataProvider.Instance.ExecuteQuery("USP_Switch @idTable1, @idTable2", new object[]{id1,id2});
        }


        public List<Table> LoadTableList() {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}