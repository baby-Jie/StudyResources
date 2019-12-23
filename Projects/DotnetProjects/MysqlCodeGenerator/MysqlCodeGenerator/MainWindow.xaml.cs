using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MysqlCodeGenerator.Models;
using MysqlCodeGenerator.Utils;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace MysqlCodeGenerator
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> tableList = new List<string>();

        private MySqlConnection mySqlConnection = null;

        private string databaseNameStr = "test";

        private string databaseUserName = "root";

        private string databasePassword = "mysql";


        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void GetResultset(MySqlCommand mySqlCommand)
        {
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine(reader.GetString(0));
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }
        }

        // region 打开数据库
        private void OpenBtn_OnClick(object sender, RoutedEventArgs e)
        {
            OpenDbSource();
        }

        private void OpenDbSource()
        {
            // Data Source=127.0.0.1;User Id=root;Password=mysql;pooling=false;CharSet=utf8;port=3306"
            string mysqlServerIp = RemoteMysqlIpTxtBox.Text.Trim();
            databaseNameStr = DbSourceTxtBox.Text.Trim();
            databaseUserName = DbUserTxtBox.Text.Trim();
            databasePassword = DbPasswordTxtBox.Text.Trim();
            if (!CheckBeforeOpen(mysqlServerIp, databaseNameStr)) return;
            string portStr = PortTxtBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(portStr))
            {
                portStr = "3306";
            }
            else
            {
                if (Int32.TryParse(portStr, out int port))
                {
                    if (port >= 65536 || port < 0)
                    {
                        MessageBox.Show("端口号不符合规范，请重新输入端口号");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("端口号的格式不正确，请重新输入端口号");
                    return;
                }
            }

            string dbSourceStr =
                $"Database=test;Data Source={mysqlServerIp};User Id={databaseUserName};Password={databasePassword};pooling=false;CharSet=utf8;port={portStr}";

            List<string> tableNames = new List<string>();
            mySqlConnection = MysqlUtil.GetMySqlConnection(dbSourceStr);
            var sqlCmd = MysqlUtil.GetSqlCommand("show tables;", mySqlConnection);
            mySqlConnection.Open();

            try
            {

                using (MySqlDataReader mySqlDataReader = sqlCmd.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            string tableName = mySqlDataReader.GetString(0);
                            tableNames.Add(tableName);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("打开数据库失败," + e.Message);
                return;
            }

            tableList = tableNames;
            TableListBox.ItemsSource = tableList;
        }

        /// <summary>
        /// 打开数据库之前例行检查
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeOpen(string mysqlServerIp, string databaseName)
        {
            if (string.IsNullOrEmpty(mysqlServerIp)) return false; // 也可以检查是否符合ip的书写规则(排除localhost)，提高程序的健壮性
            if (string.IsNullOrEmpty(databaseName)) return false;

            if (string.IsNullOrWhiteSpace(databaseUserName) || string.IsNullOrWhiteSpace(databasePassword))
            {
                return false;
            }
            return true;
        }
        //endregion 

        // region 关闭数据库
        private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CloseMysqlConnection();
        }
        // endregion

        private void TableListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TableListBox.SelectedItem == null)
            {
                return;
            }

            string selectedTableName = TableListBox.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(selectedTableName))
            {
                return;
            }

            string selectColumnNameSql =
                $"SELECT column_name FROM information_schema.columns WHERE table_schema='{databaseNameStr}' AND table_name='{selectedTableName}';";
            var sqlCmd = MysqlUtil.GetSqlCommand(selectColumnNameSql, mySqlConnection);

            List<ColumnModel> columnModels = new List<ColumnModel>();

            try
            {
                using (var dataReader = sqlCmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader.HasRows)
                        {
                            string originalName = dataReader.GetString(0);
                            string newColumnName = MysqlUtil.GetModelColumnName(originalName);
                            ColumnModel columnModel = new ColumnModel(originalName, newColumnName);
                            columnModels.Add(columnModel);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取表信息失败，错误原因:" + exception.Message);
            }

            if (columnModels.Count > 0)
            {
                string text = GetSelectReturnString(columnModels);

                MessageTxtBox.Text = text;
            }
        }

        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            Dispose();
        }

        /// <summary>
        /// 销毁资源
        /// </summary>
        private void Dispose()
        {
            CloseMysqlConnection();
        }

        private void CloseMysqlConnection()
        {
            TableListBox.ItemsSource = null;
            if (mySqlConnection != null)
            {
                try
                {
                    mySqlConnection.Close();

                    mySqlConnection = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// 获取select 内容 例如 select stu_name as stuName,
        /// </summary>
        /// <param name="columnModels"></param>
        /// <returns></returns>
        private string GetSelectReturnString(List<ColumnModel> columnModels)
        {
            StringBuilder sb = new StringBuilder();
            int count = columnModels.Count;

            for (int i = 0; i < count - 1; i++)
            {
                var columnModel = columnModels[i];
                string text = $"{columnModel.OriginalColumnName} as {columnModel.NewColumnName},";
                sb.AppendLine(text);
            }

            var lastColumnModel = columnModels[count - 1];
            string lastText = $"{lastColumnModel.OriginalColumnName} as {lastColumnModel.NewColumnName}";
            sb.AppendLine(lastText);

            return sb.ToString();
        }
    }
}
