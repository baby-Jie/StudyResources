using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopTool.Models
{
    public class ShortcutModel
    {

        #region FullProperty FilePath

        /// <summary>
        /// 文件路径
        /// </summary>
        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                if (File.Exists(_filePath))
                {
                    FileName = Path.GetFileName(_filePath);
                }
            }
        }

        #endregion	FullProperty FilePath

        /// <summary>
        /// Icon的路径
        /// </summary>
        public string IconPath { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; } = "default";
    }
}
