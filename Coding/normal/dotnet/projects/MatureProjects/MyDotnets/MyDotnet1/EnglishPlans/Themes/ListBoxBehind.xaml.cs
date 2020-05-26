using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EnglishPlans.CommonTool;

namespace EnglishPlans.Themes
{
    public partial class ListBoxBehind
    {
        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayAudio_OnClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is string word)
                {
                    AudioUtils.PlayWordAudio(word);
                }
            }
        }
    }
}
