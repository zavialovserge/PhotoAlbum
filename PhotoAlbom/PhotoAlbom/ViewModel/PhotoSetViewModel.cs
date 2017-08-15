using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace PhotoAlbom.ViewModel
{
    /// <summary>
    /// Represent set of photos
    /// </summary>
    public partial class PhotoSetViewModel:ViewModelBase
    {
        /// <summary>
        /// Collection of Images
        /// </summary>
        public ObservableCollection<Image> ImageCollection { get; set; }

        /// <summary>
        /// Array of Windows Photo Viewer formats
        /// </summary>
        public List<string> FormatList { get; set; }

        /// <summary>
        /// Chosen Image
        /// </summary>
        private Image currentImage;

        public Image CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                RaisePropertyChanged();
            }
        }

        private readonly BackgroundWorker worker;
        
        private int currentProgress;

        public int CurrentProgress
        {
            get { return this.currentProgress; }
            private set
            {
                if (this.currentProgress != value)
                {
                    this.currentProgress = value;
                    RaisePropertyChanged();
                }
            }
        }
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.CurrentProgress = e.ProgressPercentage;
        }
        /// <summary>
        /// Initialize when we need to collapsed our view
        /// </summary>
        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                RaisePropertyChanged();
            }
        }
        public PhotoSetViewModel()
        {
            IsVisible = true;
            FormatList = getFormats();
            ImageCollection = new ObservableCollection<Image>();
            doubleClick = new RelayCommand<Image>(ChangeControl);
            dragNDrop = new RelayCommand<DragEventArgs>(AddImage,CanAddImage);
            photoDown = new RelayCommand<Image>(ChangePhotoToDown, CanPhotoDown);
            photoUp = new RelayCommand<Image>(ChangePhotoToUp, CanPhotoUp);
            escClick = new RelayCommand(BackChangeControl);
            this.worker = new BackgroundWorker();
            this.worker.ProgressChanged += this.ProgressChanged;

        }
        
        /// <summary>
        /// Getting list of Windows Photo Viewer
        /// </summary>
        /// <returns></returns>
        private List<string> getFormats()
        {
            List<string> formats = new List<string>()
            {
                "BMP",
                "JPG",
                "JPEG",
                "PNG",
                "ICO",
                "GIF",
                "TIFF"
            };
            return formats;
        }

       
    }
}
