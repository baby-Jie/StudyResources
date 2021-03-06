/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:EnglishPlans"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using EnglishPlans.Model;
using EnglishPlans.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace EnglishPlans.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
                SimpleIoc.Default.Register<IDataService, DesignDataService>();
            }
            else
            {
                // Create run time view services and models
                SimpleIoc.Default.Register<IDataService, EnglishDataService>();
            }

            SimpleIoc.Default.Register<MyContext>();

            SimpleIoc.Default.Register<EnglishViewModel>();

            SimpleIoc.Default.Register<ReviewViewModel>();
        }

        public EnglishViewModel EnglishViewModel => ServiceLocator.Current.GetInstance<EnglishViewModel>();

        public ReviewViewModel ReviewViewModel => ServiceLocator.Current.GetInstance<ReviewViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}