using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfLib.WCommonTools
{
    public class AttachManager:DependencyObject
    {
        #region Transparent 设置某个窗口是否是透明的 windowStyle allowTranparent background

        public static bool GetTransparent(DependencyObject obj)
        {
            return (bool)obj.GetValue(TransparentProperty);
        }

        public static void SetTransparent(DependencyObject obj, bool value)
        {
            obj.SetValue(TransparentProperty, value);
        }

        public static readonly DependencyProperty TransparentProperty =
            DependencyProperty.RegisterAttached("Transparent", typeof(bool), typeof(AttachManager), new PropertyMetadata(false, OnTransparentChanged));

        public static void OnTransparentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is Window win)
            {
                if (e.NewValue is bool isTransparent)
                {
                    if (isTransparent)
                    {
                        win.WindowStyle = WindowStyle.None;
                        win.Background = null;
                        win.AllowsTransparency = true;
                    }
                    else
                    {
                        win.WindowStyle = WindowStyle.SingleBorderWindow;
                        win.Background = new SolidColorBrush(Colors.White);
                        win.AllowsTransparency = false;
                    }
                }
            }
        }

        #endregion Transparent	

        #region CanDragMove 设置某个窗口是否可以被拖动。

        public static bool GetCanDragMove(DependencyObject obj)
        {
            return (bool)obj.GetValue(CanDragMoveProperty);
        }

        public static void SetCanDragMove(DependencyObject obj, bool value)
        {
            obj.SetValue(CanDragMoveProperty, value);
        }

        public static readonly DependencyProperty CanDragMoveProperty =
            DependencyProperty.RegisterAttached("CanDragMove", typeof(bool), typeof(AttachManager), new PropertyMetadata(false, OnCanDragMoveChanged));

        public static void OnCanDragMoveChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (obj is FrameworkElement frameworkElement)
            {
                if (e.NewValue is bool canDragMove)
                {
                    if (canDragMove)
                    {
                        frameworkElement.PreviewMouseLeftButtonDown += OnFrameworkElementPreviewMouseLeftButtonDown;
                        frameworkElement.PreviewMouseMove += OnFrameworkElementPreviewMouseMove;
                        frameworkElement.PreviewMouseLeftButtonUp += OnFrameworkElementPreviewMouseLeftButtonUp;
                    }
                    else
                    {
                        frameworkElement.PreviewMouseLeftButtonDown -= OnFrameworkElementPreviewMouseLeftButtonDown;
                        frameworkElement.PreviewMouseMove -= OnFrameworkElementPreviewMouseMove;
                        frameworkElement.PreviewMouseLeftButtonUp -= OnFrameworkElementPreviewMouseLeftButtonUp;
                    }
                }
            }
        }

        private static Point _downPoint;

        private static void OnFrameworkElementPreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender is Window window)
            {
                _downPoint = e.GetPosition(window);
            }
        }

        private static void OnFrameworkElementPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (sender is Window window)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    var mouseMovePoint = e.GetPosition(window);

                    if (CommonUtil.IsAbleToDrag(mouseMovePoint, _downPoint))
                    {
                        window.DragMove();
                    }
                }
            }
        }

        private static void OnFrameworkElementPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Window window)
            {
                var mouseMovePoint = e.GetPosition(window);

                if (CommonUtil.IsAbleToDrag(mouseMovePoint, _downPoint))
                {
                    e.Handled = true;

                    var element = Mouse.Captured;
                    element?.ReleaseMouseCapture();
                }
            }
        }

        #endregion CanDragMove

    }
}
