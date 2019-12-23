using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MysqlCodeGenerator.Models;

namespace MysqlCodeGenerator.Utils
{
    public class ConnectionUtils
    {
        public const string CONNECTION_FILE_NAME = "connect_record.txt";

        private static List<string> _connectionStrList;

        private static List<ConnectionModel> _connectionModelList;

        static ConnectionUtils()
        {
            _connectionStrList = GetConnectionStringList();

            _connectionModelList = GetConnectionModels(_connectionStrList);
        }

        /// <summary>
        /// 获取连接集合
        /// </summary>
        /// <returns></returns>
        public static List<string> GetConnectionStringList()
        {
            if (File.Exists(CONNECTION_FILE_NAME))
            {
                List<string> connectionStringList = new List<string>();
                using (FileStream fileStream = File.OpenRead(CONNECTION_FILE_NAME))
                {
                    using (StreamReader sr = new StreamReader(fileStream))
                    {
                        while (!sr.EndOfStream)
                        {
                            string connectionStr = sr.ReadLine();
                            connectionStringList.Add(connectionStr);
                        }
                    }
                }

                return connectionStringList;
            }
            return null;
        }

        /// <summary>
        /// 根据连接字符串列表 获取 ConnectionMode 列表
        /// </summary>
        /// <param name="connectionStrList"></param>
        /// <returns></returns>
        public static List<ConnectionModel> GetConnectionModels(List<string> connectionStrList)
        {
            List<ConnectionModel> connectionModels = new List<ConnectionModel>();

            foreach (var connectionStr in connectionStrList)
            {
                ConnectionModel connectionModel = GetConnectionModel(connectionStr);
                if (connectionModel != null)
                {
                    connectionModels.Add(connectionModel);
                }
            }

            return connectionModels;
        }

        /// <summary>
        /// 通过连接字符串获取单个ConnectionModel
        /// </summary>
        /// <param name="connectionStr"></param>
        /// <returns></returns>
        public static ConnectionModel GetConnectionModel(string connectionStr)
        {
            if (!string.IsNullOrWhiteSpace(connectionStr))
            {
                string[] argStrings = connectionStr.Split(">".ToCharArray());

                if (argStrings.Length == 4)
                {
                    string connectIp = argStrings[0];
                    string portStr = argStrings[1];
                    string userName = argStrings[2];
                    string userPass = argStrings[3];
                    if (int.TryParse(portStr, out int port))
                    {
                        return new ConnectionModel(connectIp, port, userName, userPass);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 添加连接
        /// </summary>
        /// <param name="connectionStr"></param>
        public static void AddConnection(string connectionStr)
        {
            if (_connectionStrList.Any(s => s.Equals(connectionStr)))
            {
                return;
            }
            else
            {
                _connectionStrList.Add(connectionStr);
                ConnectionModel model = GetConnectionModel(connectionStr);
                _connectionModelList.Add(model);
            }
        }

        /// <summary>
        /// 保存连接
        /// </summary>
        public static void SaveConnection()
        {
            using (FileStream fileStream = File.OpenWrite(CONNECTION_FILE_NAME))
            {
                using (StreamWriter sw = new StreamWriter(fileStream))
                {
                    foreach (var connectionStr in _connectionStrList)
                    {
                        sw.WriteLine(connectionStr);
                    }
                }
            }
        }
    }
}
