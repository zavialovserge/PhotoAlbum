using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAlbom.ViewModel
{
    /// <summary>
    /// Reprezent single image
    /// </summary>
    public class Image
    {
        /// <summary>
        /// URI of image
        /// </summary>
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }


        /// <summary>
        /// Reference on photoSet
        /// </summary>
        public PhotoSetViewModel parent { get; set; }
        public Image(string Uri,PhotoSetViewModel photoSet)
        {
            this.Path = Uri;
            this.parent = photoSet;
        }
    }
}
