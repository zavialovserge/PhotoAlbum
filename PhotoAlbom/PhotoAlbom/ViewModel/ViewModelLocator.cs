using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace PhotoAlbom.ViewModel
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

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PhotoSetViewModel>();
            
        }

        public MainViewModel Main =>  ServiceLocator.Current.GetInstance<MainViewModel>();

        public PhotoSetViewModel PhotoSet => ServiceLocator.Current.GetInstance<PhotoSetViewModel>();
        
        public static void Cleanup()
        {
            
            
        }
    }
}