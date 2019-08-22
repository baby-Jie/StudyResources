/*
IO 工具类
 */

 using System;
using System.IO;

namespace CommonUtil.Utils.IOUtils
{
    public static class IOUtil
    {
        #region Files

        #region 检查文件路径是否存在

        public static bool CheckFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion 检查文件路径是否存在	

        #region 递归清空指定的文件夹中的所有文件，但不删除文件夹

        /// <summary>
        /// 1. 判断文件夹是否存在
        /// 2. 删除文件（只读文件改为普通文件）
        /// 3. 递归删除子文件夹中的文件
        /// </summary>
        /// <param name="dirPath"></param>
        public static void DeleteFolder(string dirPath)
        {
            if (CheckDirectory(dirPath))
            {
                return;
            }

            foreach (string d in Directory.GetFileSystemEntries(dirPath))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);

                    if (fi.Attributes.ToString().IndexOf("ReadOnly", StringComparison.Ordinal) != -1)
                    {
                        fi.Attributes = FileAttributes.Normal;
                    }

                    File.Delete(d);//直接删除其中的文件  
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }

        #endregion 递归清空指定的文件夹中的所有文件，但不删除文件夹	

        #endregion Files	

        #region Directories

        #region 检查目录路径是否存在

        public static bool CheckDirectory(string dirPath)
        {
            if (string.IsNullOrWhiteSpace(dirPath) || !Directory.Exists(dirPath))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion 检查目录路径是否存在	

        #region 删除文件夹（包括文件夹中的文件一并删除）

        /// <summary>
        /// 1. 清空文件夹和子文件中的文件
        /// 2. 删除空文件夹
        /// </summary>
        /// <param name="dir"></param>
        public static void DeleteFolderAndItself(string dir)
        {
            if (Directory.Exists(dir))
            {
                DeleteFolder(dir);

                Directory.Delete(dir); // 只能删除空目录
            }
        }

        #endregion 删除文件夹（包括文件夹中的文件一并删除）	

        #region 删除指定文件所在的文件夹

        public static void DeleteFolderByFilePath(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string directory = Path.GetDirectoryName(filePath);
                    DeleteFolderAndItself(directory);
                }
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
            }
        }

        #endregion 删除指定文件所在的文件夹	

        #endregion Directories	
    }
}
