﻿using GalaSoft.MvvmLight.CommandWpf;
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
        /// Command for DragNDrop
        /// </summary>
        public ICommand DragNDrop => dragNDrop;
        private RelayCommand<DragEventArgs> dragNDrop;

        
        /// <summary>
        /// Command that change CurrectImage to DownPhoto in Collection
        /// </summary>
        public ICommand PhotoDown => photoDown;
        private RelayCommand<Image> photoDown;

        /// <summary>
        /// Command for change Photo to Up Photo
        /// </summary>
        public ICommand PhotoUp => photoUp;
        private RelayCommand<Image> photoUp;

        /// <summary>
        /// Command for escape button
        /// </summary>
        public ICommand EscClick => escClick;
        private RelayCommand escClick;

        /// <summary>
        /// Command PhotoUp method
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
                return false;
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
        /// Command PhotoDown method
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
        
        /// <summary>
        /// Validation if file is valid format
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
        /// <param name="image">CurrentImage</param>
        public void ChangeControl(Image image)
        {
            CurrentImage = image;
            IsVisible = false;
            ServiceLocator.Current.GetInstance<MainViewModel>().AllowDropItem = false;
        }
        
    }
}
