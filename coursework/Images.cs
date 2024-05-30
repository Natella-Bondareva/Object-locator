using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    /// Class representing images 
    public class Images
    {
        public Image<Bgr, byte> originalImg { get; private set; }
        public Image<Bgr, byte> imgForSearch;
        public Bitmap Bitmap => originalImg.AsBitmap();

        public Images(string path)
        {
            originalImg = new Image<Bgr, byte>(path);
            imgForSearch = new Image<Bgr, byte>(path);
        }
    }
}
