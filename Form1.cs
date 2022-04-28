using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.OleDb;

namespace 数据库实验3
{
    public partial class Form1 : Form
    {
        AccessConnect AccessDb;
        private delegate void UpdateStatusDelegate();
        private UpdateStatusDelegate updateStatusDelegate = null;
        SQLiteDataAdapter myda = new SQLiteDataAdapter();
        DataSet myds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path="";
            //string path = OpenFolder();//获取路径
            string name = OpenFile(ref path);//获取名字
            access路径.Text = path;
            GetTables();
        }
        public string OpenFile(ref string path)
        {
            string strFileName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Access文件(*.accdb)|*.accdb|SQLite文件(*.db)|*.db|所有文件|*.*";
            ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true; //验证路径的有效性
            ofd.CheckPathExists = true;//验证路径的有效性
            if (ofd.ShowDialog() == DialogResult.OK) //用户点击确认按钮，发送确认消息
            {
                strFileName = ofd.FileName;//获取在文件对话框中选定的路径或者字符串
                path = System.IO.Path.GetFullPath(ofd.FileName);
            }
            return strFileName;
        }
   

        private void button2_Click(object sender, EventArgs e)
        {
            string path = "";
            //string path = OpenFolder();//获取路径
            string name = OpenFile(ref path);//获取名字
            sqlite路径.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //创建数据库链接
            string mystr;
            OleDbConnection myconn = new OleDbConnection();
            mystr = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + access路径.Text;//连接字符串包含了版本和路径
            myconn.ConnectionString = mystr;
            if (access路径.Text == string.Empty)
            {
                MessageBox.Show("请选择路径");
                return;
            }
            this.updateStatusDelegate = new UpdateStatusDelegate(this.Gengxinzhuangtai);
            List<string> tableName = new List<string>();
            tableName =GetSelectedTables();
            for (int i = 0; i <tableName .Count; i++)
            {
                createSqliteTableByAccessTable(tableName[i]);
            }
            
        }
        private void GetTables()
        {
            AccessDb = new AccessConnect(access路径.Text);
            List<string> tables = AccessDb.GetTableNames();
            foreach (string s in tables)
            {
                选择要转换的表.Items.Add(s);
            }
        }
        //得到选取的表
        private List<string> GetSelectedTables()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < 选择要转换的表.Items.Count; i++)
            {
                if (选择要转换的表.GetItemChecked(i))
                    result.Add(选择要转换的表.Items[i].ToString());
            }
            this.selectedCount = result.Count;
            return result;
        }
        int counter = 0;
        int selectedCount = 0;
        //更新状态
        private void Gengxinzhuangtai()
        {
            counter++;
            if (counter >= selectedCount)
            {
                MessageBox.Show("操作完成");
            }
        }
        
        private void 选择要转换的表_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool createSqliteTableByAccessTable(string tableName)
        {
            // 读取access数据表结构
            DataTable table = AccessDb.GetTable(tableName);
           
          
            // 拼接sqlite创建表sql
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append($"CREATE TABLE {tableName} (");
            for (int i = 0; i < table.Columns.Count; i++)
            {
                    sqlBuilder.Append($"{table.Columns[i].ColumnName}");
                    sqlBuilder.Append($" ");
                    switch (table.Columns[i].DataType.ToString())
                    {
                        case "integer":
                            sqlBuilder.Append($"Integer");
                            break;
                        case "real":
                            sqlBuilder.Append($"Double");
                            break;
                        case "text":
                            sqlBuilder.Append($"Text");
                            break;
                        case "DATETIME":
                            sqlBuilder.Append($"DateTime");
                            break;
                        default:
                            sqlBuilder.Append($"Text");
                            break;
                    }
                    sqlBuilder.Append($",");   
            }
            sqlBuilder.Remove(sqlBuilder.Length - 1, 1);
            sqlBuilder.Append(")");
            string createSql = sqlBuilder.ToString();

            try
            {
                string connStr =@"Data Source = " + sqlite路径.Text+"; Version = 3;";
                SQLiteConnection sqlconn = new SQLiteConnection(connStr);
                sqlconn.Open();
                SQLiteCommand cmd = new SQLiteCommand(createSql,sqlconn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                AccdbTable2SqliteData(table, tableName);
                sqlconn.Close();
                sqlconn.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
                return false;
            }
            return true;
        }
        private bool AccdbTable2SqliteData(DataTable in_table, string sqliteTableName)
        {
            string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + access路径.Text;//连接字符串
            SQLiteConnection sqlconn = new SQLiteConnection(@"Data Source = " + sqlite路径.Text + "; Version = 3;");
            sqlconn.Open();
            using (OleDbConnection oldDbConn = new OleDbConnection(connStr))//先打开access数据库的连接
            {
                oldDbConn.Open();
                for (int n = 0; n < in_table.Rows.Count; n++)//按行开始循环
                {
                    StringBuilder sqlBuilder = new StringBuilder();//创建字符串
                    sqlBuilder.Append($"INSERT INTO {sqliteTableName}(");//$代表的是{0},要表达的文字  这种格式把0替换掉
                    StringBuilder colBuilder = new StringBuilder();
                    StringBuilder valBuilder = new StringBuilder();
                    for (int m = 0; m < in_table.Columns.Count; m++)//按列开始插入
                    {
                        if (!string.IsNullOrEmpty(in_table.Rows[n][m].ToString()))
                        {
                            colBuilder.Append(in_table.Columns[m].ColumnName).Append(",");

                            string val = "";
                            switch (in_table.Columns[m].DataType.ToString())//判断数据类型
                            {
                                case "System.Int64":
                                case "System.Int32":
                                case "System.Double":
                                    val = in_table.Rows[n][m].ToString();
                                    break;
                                case "System.DateTime":
                                case "System.String":
                                    val ="'"+ in_table.Rows[n][m].ToString()+"'";//把access里面字符串加上'适应sqlite语法
                                    break;
                                default:
                                    val ="'"+ in_table.Rows[n][m].ToString()+"'";
                                    break;
                            }

                            valBuilder.Append(val).Append(",");
                        }
                    }
                    colBuilder.Remove(colBuilder.Length - 1, 1);
                    valBuilder.Remove(valBuilder.Length - 1, 1);
                    sqlBuilder.Append(colBuilder.ToString()).Append(") VALUES ( ");
                    sqlBuilder.Append(valBuilder.ToString()).Append(")");

                    SQLiteCommand inst = new SQLiteCommand(sqlBuilder.ToString(), sqlconn);
                    inst.ExecuteNonQuery();
                }
                oldDbConn.Close();
            }
            return true;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            string mystr, mysql;//连接字符串和查询字符串
            SQLiteConnection myconn = new SQLiteConnection();//建立连接
            mystr = @"Data Source = " + sqlite路径.Text + "; Version = 3;";
            myconn.ConnectionString = mystr;
            myconn.Open();
            mysql = sqltalk.Text;//获取查询字符串
            myda = new SQLiteDataAdapter(mysql, myconn);//获取数据库里相应表数据
            DataTable dt1 = new DataTable();//用datatable当中介存数据
            myda.Fill(dt1);//把数据库中数据填充至datatable
            tableshow.DataSource = dt1;//显示在控件中
            myconn.Close();
        }

        private void sqltalk_TextChanged(object sender, EventArgs e)
        {

        }

        private void change_Click(object sender, EventArgs e)
        {
            
            //SQLiteCommandBuilder mycmdbuilder = new SQLiteCommandBuilder(myda);
            //if (myds.HasChanges())
            //{
            //    try
            //    {
            //        myda.Update(myds,)
            //    }
            //    catch(Exception ex)
            //    {
            //        MessageBox.Show("数据修改不正确");
            //    }
            //}
        }
    }

}
