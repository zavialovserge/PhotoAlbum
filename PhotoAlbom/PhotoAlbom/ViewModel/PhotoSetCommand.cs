using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PhotoAlbom.ViewModel
{
    public partial class PhotoSetViewModel
    {
        /// <summary>
        /// Command for double click
        /// </summary>
        public ICommand DoubleClick => doubleClick;
        private RelayCommand<Image> doubleClick;

        /// <summary>
        /// Command for double click
        /// </summary>
        public ICommand DragNDrop => dragNDrop;
        private RelayCommand<DragEventArgs> dragNDrop;


        /// <summary>
        /// Command for change Photo to Up Photo
        /// </summary>
        public ICommand PhotoUp => photoDown;
        private RelayCommand<Image> photoDown;

        /// <summary>
        /// Command for change Photo to Down Photo
        /// </summary>
        public ICommand PhotoDown => photoUp;
        private RelayCommand<Image> photoUp;

        /// <summary>
        /// Command for change Photo to Down Photo
        /// </summary>
        public ICommand EscClick => escClick;
        private RelayCommand escClick;
        /// <summary>
        /// Photo up method
        /// </summary>
        /// <param name="image">CurrentImage</param>
        private void ChangePhotoToDown(Image image)
        {
            int index = ImageCollection.IndexOf(image);
            index++;
            CurrentImage = ImageCollection[index];
        }
        /// <summary>
        /// Check if we can do command photoDown
        /// </summary>
        /// <param name="image">CurrentImage</param>
        /// <returns></returns>
        private bool CanPhotoDown(Image image)
        {
            if (image == null)
            {
                return true;//??
            }
            int index = ImageCollection.IndexOf(image);
            index++;
            return index < ImageCollection.Count;
        }

        /// <summary>
        /// Check if we can do command photoUp
        /// </summary>
        /// <param name="image">CurrentImage</param>
        private void ChangePhotoToUp(Image image)
        {
            int index = ImageCollection.IndexOf(image);
            index--;
            CurrentImage = ImageCollection[index];
        }

        /// <summary>
        /// Photo down method
        /// </summary>
        /// <param name="image">CurrentImage</param>
        /// <returns></returns>
        private bool CanPhotoUp(Image image)
        {
            int index = ImageCollection.IndexOf(image);
            index--;
            return index > -1;
        }

        /// <summary>
        /// Occurs when drag n drop event start
        /// </summary>
        /// <param name="arg"></param>
        public void AddImage(DragEventArgs arg)
        {
            var g = arg.Data.GetDataPresent(DataFormats.FileDrop);
            string[] files = (string[])arg.Data.GetData(DataFormats.FileDrop);
            for (int i = 0; i < files.Length; i++)
            {
                ImageCollection.Add(new Image(files[i], this));
            }

        }

        //TODO DO IT CORRECT
        /// <summary>
        /// Validation if file is not good format?????????
        /// </summary>
        /// <param name="arg">drag n drop event</param>
        /// <returns></returns>
        private bool CanAddImage(DragEventArgs arg)
        {
            var g = arg.Data.GetDataPresent(DataFormats.FileDrop);
            string[] files = (string[])arg.Data.GetData(DataFormats.FileDrop);
            

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo info = new FileInfo(files[i]);
                if (!FormatList.Contains(info.Extension.Trim('.').ToUpper()))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Change control for album view
        /// </summary>
        public void BackChangeControl()
        {
            CurrentImage = null;
            IsVisible = true;
            ServiceLocator.Current.GetInstance<MainViewModel>().AllowDropItem = true;
        }
        /// <summary>
        /// Change control for chosen image
        /// </summary>
        /// <param name="image"></param>
        public void ChangeControl(Image image)
        {
            CurrentImage = image;
            IsVisible = false;
            ServiceLocator.Current.GetInstance<MainViewModel>().AllowDropItem = false;
        }
        
    }
}
