/*
1. ui事件中 代码超过两行的 放到专门的函数中
 */
using System.ComponentModel;
using System.Windows;

namespace MyTests
{
    /// <summary>
    /// TemplateWin.xaml 的交互逻辑
    /// </summary>
    public partial class TemplateWin : Window
    {
        #region Constructors

        public TemplateWin()
        {
            InitializeComponent();
            CustomIntialization();
        }

        #endregion Constructors

        #region  Fields
        #endregion Fields

        #region Properties
        #endregion Properties

        #region Methods
        #endregion Methods

        #region EventHandlers

        #region UI Eventhandlers

        protected override void OnClosing(CancelEventArgs e)
        {
            Disopose();
            base.OnClosing(e);
        }

        #endregion UI Eventhandlers

        #region Custom Register EventHandlers

        #endregion Custom Register EventHandlers	

        #endregion EventHandlers

        #region 分类

        #region 初始化和销毁

        #region 初始化

        public void CustomIntialization()
        {
        }


        #endregion 初始化	

        #region 销毁

        public void Disopose()
        {

        }

        #endregion 销毁	

        #endregion 初始化和销毁	

        #endregion 分类	
    }
}
