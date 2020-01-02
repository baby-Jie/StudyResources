using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;


namespace LibraryUse.ZipUtils
{
    public class ZipUtil
    {
        #region 压缩

        public static bool ZipFile(string sourceDirectory, string zipFileName)
        {
            return ZipFile(sourceDirectory, zipFileName, true, null, null);
        }

        public static bool ZipFile(string sourceDirectory, string zipFileName, bool recurse, string fileFilter,
                                   string directoryFilter)
        {
            bool isSuccess = false;

            try
            {
                FastZip fZip = new FastZip();
                fZip.CreateZip(zipFileName, sourceDirectory, recurse, fileFilter, directoryFilter);

                isSuccess = true;
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
            }

            return isSuccess;
        }

        //public

        /// <summary>
        /// 压缩文件成流
        /// </summary>
        /// <param name="outputStream"></param>
        /// <param name="sourceDirectory"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool ZipFileOutStream(Stream outputStream, string sourceDirectory, out string errorMessage)
        {
            bool isSuccess = false;
            errorMessage = string.Empty;

            try
            {
                FastZip fZip = new FastZip();
                fZip.CreateZip(outputStream, sourceDirectory, true, null, null);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                //Log.Write(ex);
                errorMessage = ex.Message;
            }

            return isSuccess;
        }

        #endregion 压缩	

        #region 解压

        public static bool UnZipFiles(string zipFileName, string unZipPath)
        {
            try
            {
                FastZip fZip = new FastZip();
                fZip.ExtractZip(zipFileName, unZipPath, FastZip.Overwrite.Always, null, null, null, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        #endregion 	
    }

    public class ZipHelper
    {
        private int _uptoZipFileCount;
        private int _totalZipFileCount;

        private int _uptoUnzipFileCount;
        private int _totalUnzipFileCount;

        //private int 

        private bool _stop;

        public event Action<int> ZipProcessChangedEvent;

        public event Action<int> UnzipProcessChangedEvent; 

        public ZipHelper()
        {
            
        }

        public static int ZipFileCount(String zipFileName)
        {
            using (ZipArchive archive = System.IO.Compression.ZipFile.Open(zipFileName, ZipArchiveMode.Read))
            {
                int count = 0;

                // We count only named (i.e. that are with files) entries
                foreach (var entry in archive.Entries)
                    if (!String.IsNullOrEmpty(entry.Name))
                        count += 1;

                return count;
            }
        }

        /// <summary>
        /// 异步压缩文件 产生进度事件
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="zipFileName"></param>
        public async void ZipFileAsync(string sourceDirectory, string zipFileName)
        {
            _totalZipFileCount = FolderContentsCount(sourceDirectory);

            FastZipEvents events = new FastZipEvents();
            events.ProcessFile = ZipProcessFileMethod;
            FastZip fastZip = new FastZip(events);
            //FindEntry

            fastZip.CreateEmptyDirectories = true;

            await Task.Run(() => { fastZip.CreateZip(zipFileName, sourceDirectory, true, ""); });
        }

        public async void UnzipFileAsync(string zipFileName, string unZipPath)
        {
            _totalUnzipFileCount = ZipFileCount(zipFileName);
            Console.WriteLine($"_totalUnzipFileCount:{_totalUnzipFileCount}");
            FastZipEvents events = new FastZipEvents();
            events.ProcessFile = UnzipProcessFileMethod;
            FastZip fastZip = new FastZip(events);
            fastZip.CreateEmptyDirectories = true;

            string fileFilter = @"+\.dat$;-^dummy\.dat$";
            string directoryFilter = null;
            bool restoreDateTime = true;

            await Task.Run(() =>
            {
                fastZip.ExtractZip(zipFileName, unZipPath, FastZip.Overwrite.Always, null, null, directoryFilter,
                    false);
                Console.WriteLine("yes");
                Console.WriteLine($"_uptoUnzipFileCount:{_uptoUnzipFileCount}");
            });
        }

        private void ZipProcessFileMethod(object sender, ScanEventArgs args)
        {
            _uptoZipFileCount++;
            int percentCompleted = _uptoZipFileCount * 100 / _totalZipFileCount;
            // do something here with a progress bar
            // file counts are easier as sizes take more work to calculate, and compression levels vary by file type

            ZipProcessChangedEvent?.Invoke(percentCompleted);

            string fileName = args.Name;
            // To terminate the process, set args.ContinueRunning = false
            if (fileName == "stop on this file")
                args.ContinueRunning = false;
        }

        //private bool OverwritePrompt(string fileName)
        //{
        //    // In this method you can choose whether to overwrite a file.
        //    DialogResult dr = MessageBox.Show("Overwrite " + fileName, "Overwrite?", MessageBoxButtons.YesNoCancel);
        //    if (dr == DialogResult.Cancel)
        //    {
        //        _stop = true;
        //        // Must return true if we want to abort processing, so that the ProcessFileMethod will be called.
        //        // When the ProcessFileMethod sets ContinueRunning false, processing will immediately stop.
        //        return true;
        //    }
        //    return dr == DialogResult.Yes;
        //}

        private void UnzipProcessFileMethod(object sender, ScanEventArgs args)
        {
            _uptoUnzipFileCount++;
            int percentCompleted = _uptoUnzipFileCount * 100 / _totalUnzipFileCount;
            // do something here with a progress bar
            // file counts are easier as sizes take more work to calculate, and compression levels vary by file type

            UnzipProcessChangedEvent?.Invoke(percentCompleted);

            string fileName = args.Name;
            // To stop all further processing, set args.ContinueRunning = false
            if (_stop)
            {
                args.ContinueRunning = false;
            }
        }

        private int FolderContentsCount(string path)
        {
            int result = Directory.GetFiles(path).Length;
            string[] subFolders = Directory.GetDirectories(path);
            foreach (string subFolder in subFolders)
            {
                result += FolderContentsCount(subFolder);
            }
            return result;
        }
    }
}
