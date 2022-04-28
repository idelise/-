using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data.SQLite;

namespace 数据库实验3
{
    public class sqliteClass
    {
        SQLiteConnection m_dbConnection;
        public sqliteClass()
        {

            SQLiteConnection.CreateFile("MyDatabase.sqlite");

            m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.sqlite;Version=3;");
            m_dbConnection.Open();
        }
        public int CreateTable(string name)
        {
            string sql = "create table " + name + " (word varchar(200), image text)";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);
            return cmd.ExecuteNonQuery();

        }
        public int InsertRow(string word, string image, string table)
        {
            string sql = "insert into " + table + " (word,image) values(@word,@image)";
            SQLiteCommand cmd = new SQLiteCommand(sql, m_dbConnection);

            cmd.Parameters.AddWithValue("@word", word);
            cmd.Parameters.AddWithValue("@image", image);
            return cmd.ExecuteNonQuery();
        }
    }
}
