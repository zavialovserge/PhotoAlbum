using GalaSoft.MvvmLight;

namespace PhotoAlbom.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// 
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initialize for allow drop to window
        /// Change when we double clicked on image
        /// </summary>
        private bool allowDropItem;

        public bool AllowDropItem
        {
            get { return allowDropItem; }
            set
            {
                allowDropItem = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.AllowDropItem = true;
            PhotoSetViewModel photoSet = new PhotoSetViewModel();
        }
    }
}