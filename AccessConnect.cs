using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Data.OleDb;

namespace 数据库实验3
{
    public class AccessConnect
    {
        OleDbConnection _con;
        public  AccessConnect(string dbPath)
        {
            _con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + dbPath);
            _con.Open();
        }
        public List<string> GetTableNames()
        {
            List<string> Res = new List<string>();
            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            DataTable userTables = null;


            //获取表名
            userTables = _con.GetSchema("Tables", restrictions);

            for (int i = 0; i < userTables.Rows.Count; i++)
            {

                Res.Add(userTables.Rows[i][2].ToString());
            }
            return Res;
        }
        public DataTable GetTable(string name)
        {

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM " + name, _con);
            da.Fill(dt);
            return dt;
        }
        public List<string> GetColumnNames(string tableName)
        {
            List<string> Res = new List<string>();
            using (var cmd = new OleDbCommand("select * from " + tableName, _con))
            using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                var table = reader.GetSchemaTable();
                var nameCol = table.Columns["ColumnName"];
                foreach (DataRow row in table.Rows)
                {
                    Res.Add(row[nameCol].ToString());
                }
            }
            return Res;
        }
    }
}
