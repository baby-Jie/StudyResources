using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EnglishPlans.CommonTool
{
    public class AudioUtils
    {
        private static MediaPlayer _mediaPlayer = new MediaPlayer();

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="word"></param>
        public static void PlayWordAudio(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return;
            }

            string audioFilePath = Path.Combine(Directory.GetCurrentDirectory(), $"audios/{word}.mp3");
            string translateAddress = string.Format(AppConstants.TRANSLATE_ADDRESS, word);

            // 1. 查看本地audio文件夹下有没有此音频
            try
            {
                if (!File.Exists(audioFilePath))
                {
                    // 1.1 下载此音频到audio文件夹下
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(translateAddress, audioFilePath);
                    }
                }
            }
            catch (System.Exception e)
            {
                Logger.Info(e.Message);
                return;
            }


            // 2. 播放此音频。
            _mediaPlayer.Stop();
            _mediaPlayer.Open(new Uri(audioFilePath, UriKind.Absolute));
            _mediaPlayer.Play();
        }
    }
}
