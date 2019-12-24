using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Resources;
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
        private List<string> _databaseList = new List<string>(); // 数据库 列表

        private List<string> _tableList = new List<string>(); // 数据表 列表

        private MySqlConnection _mySqlConnection = null;

        private string _databaseNameStr = "";

        private string _databaseUserName = "root";

        private string _databasePassword = "mysql";


        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void GetResultSet(MySqlCommand mySqlCommand)
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

        private void OpenDbSource(string connectionStr, bool addToList = true)
        {
            ConnectionModel connectionModel = ConnectionUtils.GetConnectionModel(connectionStr);

            if (null == connectionModel)
            {
                MessageBox.Show("打开数据库失败,连接为:" + connectionStr);
                return;
            }

            DatabaseListBox.ItemsSource = null;
            TableListBox.ItemsSource = null;
            MessageTxtBox.Text = null;

            try
            {
                string connectIp = connectionModel.RemoteIp;
                int connectPort = connectionModel.Port;
                string userName = connectionModel.UserName;
                string userPass = connectionModel.UserPass;

                string dbSourceStr =
                    $"Data Source={connectIp};User Id={userName};Password={userPass};pooling=false;CharSet=utf8;port={connectPort}";

                List<string> databaseNames = new List<string>();

                // 打开之前先关闭已经打开的连接
                CloseMysqlConnection();


                _mySqlConnection = MysqlUtil.GetMySqlConnection(dbSourceStr);
                var sqlCmd = MysqlUtil.GetSqlCommand("show databases;", _mySqlConnection);
                _mySqlConnection.Open();

                try
                {
                    using (MySqlDataReader mySqlDataReader = sqlCmd.ExecuteReader())
                    {
                        while (mySqlDataReader.Read())
                        {
                            if (mySqlDataReader.HasRows)
                            {
                                string tableName = mySqlDataReader.GetString(0);
                                databaseNames.Add(tableName);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("打开数据库失败," + e.Message);
                    return;
                }


                _tableList = databaseNames;
                DatabaseListBox.ItemsSource = _tableList; // 显示数据库列表
            }
            catch (Exception e)
            {
                MessageBox.Show("连接数据库失败，错误信息:" + e.Message);
                return;
            }

            // 添加进列表（使用打开功能的话就加，listbox的selectionChanged就不加）
            if (addToList)
            {
                ConnectionUtils.AddConnection(connectionStr);

                LoadConnectionList();
            }
        }

        private void OpenDbSource()
        {
            string mysqlServerIp = RemoteMysqlIpTxtBox.Text.Trim();
            _databaseUserName = DbUserTxtBox.Text.Trim();
            _databasePassword = DbPasswordTxtBox.Text.Trim();
            if (!CheckBeforeOpen(mysqlServerIp)) return;
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

            string connectionStr = $"{mysqlServerIp}>{portStr}>{_databaseUserName}>{_databasePassword}";

            OpenDbSource(connectionStr, true);

        }

        /// <summary>
        /// 打开数据库之前例行检查
        /// </summary>
        /// <returns></returns>
        private bool CheckBeforeOpen(string mysqlServerIp)
        {
            if (string.IsNullOrEmpty(mysqlServerIp)) return false; // 也可以检查是否符合ip的书写规则(排除localhost)，提高程序的健壮性

            //if (string.IsNullOrEmpty(_databaseNameStr)) return false;

            if (string.IsNullOrWhiteSpace(_databaseUserName) || string.IsNullOrWhiteSpace(_databasePassword))
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
            SelectedTableChanged();
        }

        private void SelectedTableChanged()
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

            ChooseTable(selectedTableName);
        }

        private void ChooseTable(string selectedTableName)
        {
            string selectColumnNameSql =
                $"SELECT column_name, data_type, column_key FROM information_schema.columns WHERE table_schema='{_databaseNameStr}' AND table_name='{selectedTableName}';";
            var sqlCmd = MysqlUtil.GetSqlCommand(selectColumnNameSql, _mySqlConnection);

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
                            originalName = originalName.ToLower();
                            string dataTypeStr = dataReader.GetString(1);
                            string columnKey = dataReader.GetString(2);

                            string newColumnName = MysqlUtil.GetModelColumnName(originalName);
                            ColumnModel columnModel = new ColumnModel(originalName, newColumnName, dataTypeStr);

                            if (!string.IsNullOrWhiteSpace(columnKey) || "PRI".Equals(columnKey.ToUpper()))
                            {
                                columnModel.IsPrimaryKey = true;
                            }
                            columnModels.Add(columnModel);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取表信息失败，错误原因:" + exception.Message);
            }

            TableModel tableModel = new TableModel(selectedTableName, columnModels);

            SetMessageTxtBox(tableModel);
        }


        private void SetMessageTxtBox(TableModel tableModel)
        {
            List<ColumnModel> columnModels = tableModel.ColumnModels;
            if (columnModels == null || columnModels.Count == 0)
            {
                MessageTxtBox.Text = null;
                return;
            }

            string text = string.Empty;
            if (FieldRadioBtn.IsChecked == true)
            {
                text = GetSelectReturnString(tableModel);
            }
            else if (ClassRadioBtn.IsChecked == true)
            {
                text = GetClassReturnString(tableModel);
            }
            else if (BeanRadioBtn.IsChecked == true)
            {
                text = GetBeanClassReturnString(tableModel);
            }

            MessageTxtBox.Text = text;
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
            if (_mySqlConnection != null)
            {
                try
                {
                    _mySqlConnection.Close();

                    _mySqlConnection = null;
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
        private string GetSelectReturnString(TableModel tableModel)
        {
            List<ColumnModel> columnModels = tableModel.ColumnModels;
            StringBuilder sb = new StringBuilder();
            int count = columnModels.Count;

            sb.AppendLine("select");
            for (int i = 0; i < count - 1; i++)
            {
                var columnModel = columnModels[i];
                string text = "\t" + columnModel.OriginalColumnName + ",";

                if (!columnModel.OriginalColumnName.Equals(columnModel.NewColumnName))
                {
                    text = $"\t{columnModel.OriginalColumnName} as {columnModel.NewColumnName},";
                }

                sb.AppendLine(text);
            }

            var lastColumnModel = columnModels[count - 1];
            string lastText = $"\t{lastColumnModel.OriginalColumnName}";

            if (!lastColumnModel.OriginalColumnName.Equals(lastColumnModel.NewColumnName))
            {
                lastText = $"\t{lastColumnModel.OriginalColumnName} as {lastColumnModel.NewColumnName}";
            }

            sb.AppendLine(lastText);

            sb.AppendLine($"from {tableModel.TableName}");

            return sb.ToString();
        }

        private string GetClassReturnString(TableModel tableModel)
        {
            List<ColumnModel> columnModels = tableModel.ColumnModels;
            StringBuilder sb = new StringBuilder();

            string tableName = MysqlUtil.GetModelColumnName(tableModel.TableName);
            char firstChar = tableName[0];
            if (firstChar >= 'a' && firstChar <= 'z')
            {
                firstChar = (char) (firstChar - 32);
                tableName = firstChar + tableName.Substring(1);
            }

            sb.AppendLine("@Data");
            sb.AppendLine("@AllArgsConstructor");
            sb.AppendLine("@NoArgsConstructor");


            sb.Append($"public class {tableName}");
            sb.AppendLine("{");
            foreach (var columnModel in columnModels)
            {
                if (string.IsNullOrWhiteSpace(columnModel.DataType))
                {
                    continue;
                }

                string dataType = MysqlUtil.GetMappedType(columnModel.DataType);
                string fieldLine = $"\tprivate {dataType} {columnModel.NewColumnName};";
                sb.AppendLine(fieldLine);
                sb.AppendLine();
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        private string GetBeanClassReturnString(TableModel tableModel)
        {
            List<ColumnModel> columnModels = tableModel.ColumnModels;
            StringBuilder sb = new StringBuilder();

            string tableName = MysqlUtil.GetModelColumnName(tableModel.TableName);
            char firstChar = tableName[0];
            if (firstChar >= 'a' && firstChar <= 'z')
            {
                firstChar = (char)(firstChar - 32);
                tableName = firstChar + tableName.Substring(1);
            }

            sb.AppendLine("@Data");
            sb.AppendLine("@AllArgsConstructor");
            sb.AppendLine("@NoArgsConstructor");
            sb.AppendLine($"@Table(name = \"{tableModel.TableName}\")");


            sb.Append($"public class {tableName}");
            sb.AppendLine("{");
            foreach (var columnModel in columnModels)
            {
                if (string.IsNullOrWhiteSpace(columnModel.DataType))
                {
                    continue;
                }

                string dataType = MysqlUtil.GetMappedType(columnModel.DataType);
                string attributeLine = $"\t@Column(name = \"{columnModel.OriginalColumnName}\")";
                string fieldLine = $"\tprivate {dataType} {columnModel.NewColumnName};";
                if (columnModel.IsPrimaryKey)
                {
                    sb.AppendLine("\t@Id");
                }
                sb.AppendLine(attributeLine);
                sb.AppendLine(fieldLine);
                sb.AppendLine();
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

        /// <summary>
        /// 获取选中数据库的数据表列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _tableList = null;

            if (DatabaseListBox.SelectedItem == null)
            {
                return;
            }

            string selectedDatabase = DatabaseListBox.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(selectedDatabase))
            {
                return;
            }

            _databaseNameStr = selectedDatabase;


            try
            {
                var useDatabaseCmd = MysqlUtil.GetSqlCommand($"use {_databaseNameStr};", _mySqlConnection);

                useDatabaseCmd.ExecuteNonQuery();

                var sqlCmd = MysqlUtil.GetSqlCommand("show tables;", _mySqlConnection);

                _tableList = new List<string>();
                using (MySqlDataReader mySqlDataReader = sqlCmd.ExecuteReader())
                {
                    while (mySqlDataReader.Read())
                    {
                        if (mySqlDataReader.HasRows)
                        {
                            string tableName = mySqlDataReader.GetString(0);
                            _tableList.Add(tableName);
                        }
                    }
                }

                TableListBox.ItemsSource = _tableList;
            }
            catch (Exception exception)
            {
                MessageBox.Show("获取数据表信息失败," + exception.Message);
            }
        }

        private void LoadConnectionList()
        {
            ConnectListBox.ItemsSource = null;
            var connectionStrList = ConnectionUtils.ConnectionStrList;

            ConnectListBox.ItemsSource = connectionStrList;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadConnectionList();
        }

        private void ConnectListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ConnectListBox.SelectedItem == null)
            {
                return;
            }
            string connectionStr = ConnectListBox.SelectedItem.ToString();

            OpenDbSource(connectionStr, false);
        }

        private void EventSetter_OnHandler(object sender, RoutedEventArgs e)
        {
            MessageTxtBox.Text = null;
            SelectedTableChanged();
        }
    }
}
