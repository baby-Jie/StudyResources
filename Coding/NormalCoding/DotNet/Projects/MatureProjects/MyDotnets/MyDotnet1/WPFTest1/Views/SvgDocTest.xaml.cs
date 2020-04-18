using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Svg;
using Brushes = System.Drawing.Brushes;
using Color = System.Drawing.Color;

namespace WPFTest1.Views
{
    /// <summary>
    /// SvgDocTest.xaml 的交互逻辑
    /// </summary>
    public partial class SvgDocTest : Window
    {
        public SvgDocTest()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Dispose();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadInitialization();
        }

        private void Dispose()
        {

        }

        private void LoadInitialization()
        {
            LoadSvg();
        }

        #endregion LoadAndDispose

        private GraphicsPath _svgPath;

        private double _dpi = 1.25;

        private void LoadSvg()
        {
            try
            {
                SvgDocument svgDoc = SvgDocument.Open("test.svg");

                svgDoc.Fill = new SvgColourServer(Color.Red);
                svgDoc.FillRule = SvgFillRule.NonZero;

                _svgPath = svgDoc.Path;
                _svgPath.FillMode = FillMode.Winding;

                var sizeF = svgDoc.GetDimensions();

                Bitmap bitmap = new Bitmap((int)sizeF.Width, (int)sizeF.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    //g.FillPath(Brushes.Red, _svgPath);
                    //g.DrawPath(new System.Drawing.Pen(Brushes.Green, 4), _svgPath);

                    svgDoc.Draw(g);
                }


                ImageSource imageSource = ImageSourceFromBitmap(bitmap);

                TestImage.Source = imageSource;

            }
            catch (Exception e)
            {
            }
        }

        //If you get 'dllimport unknown'-, then add 'using System.Runtime.InteropServices;'
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        public ImageSource ImageSourceFromBitmap(Bitmap bmp)
        {
            var handle = bmp.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally { DeleteObject(handle); }
        }
    }
}
