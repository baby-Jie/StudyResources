/*
自定义的媒体播放器
 */

using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CustomUserControlToolKit.Controls
{
    public class AdvancedMediaElement : MediaElement, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AdvancedMediaElement()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += timer_Tick;

            this.Unloaded += (sender, args) => { timer.Stop(); };

            this.MediaOpened += (ss, ee) =>
            {
                //触发PropertyChanged DurationTime
                this.OnPropertyChanged(DurationTimeProperty);
                timer.Start();
            };

            //发生错误和视频播放完毕 停止计时器
            this.MediaEnded += (ss, ee) =>
            {
                this.Stop();
                this.Position = new TimeSpan(0,0,0,0,0);
                this.OnPropertyChanged(CurrentTimeProperty);
                //timer.Stop();
            };

            this.MediaFailed += (ss, ee) =>
            {
                this.Stop();
                this.Position = new TimeSpan(0, 0, 0, 0, 0);
                this.OnPropertyChanged(CurrentTimeProperty);
                timer.Stop();
            };
        }

        private const string CurrentTimeProperty = "CurrentTime";
        private const string DurationTimeProperty = "DurationTime";

        /// <summary>
        /// 记录最后修改进度的时间，
        /// </summary>
        private DateTime _lastChangedTime = DateTime.Now;

        private DispatcherTimer timer;

        /// <summary>
        /// 当前播放进度
        /// </summary>
        public double CurrentTime
        {
            get
            {
                return this.Position.TotalMilliseconds;
            }
            set
            {
                //进度条拖动太频繁太久，性能跟不上，所以设置一个时间阀，跳过某些时段
                if ((DateTime.Now - _lastChangedTime).TotalMilliseconds > 50)
                {
                    this.Position = TimeSpan.FromMilliseconds(value);
                    _lastChangedTime = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// 当前视频时长
        /// </summary>
        public double DurationTime
        {
            get
            {
                if (this.NaturalDuration.HasTimeSpan)
                    return this.NaturalDuration.TimeSpan.TotalMilliseconds;
                return double.NaN;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //定时触发PropertyChanged CurrentTime
            this.OnPropertyChanged(CurrentTimeProperty);
        }
    }
}
