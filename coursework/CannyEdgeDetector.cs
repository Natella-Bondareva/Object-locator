using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    public class CannyEdgeDetector : EdgeDetector
    {
        public override Bitmap DetectEdges(Images image)
        {
            // Convert to grayscale
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image.originalImg, grayImage, ColorConversion.Bgr2Gray);

            // Apply Gaussian blur to reduce noise
            Mat blurredImage = new Mat();
            CvInvoke.GaussianBlur(grayImage, blurredImage, new Size(5, 5), 0.5);

            // Apply Canny edge detection algorithm
            Mat cannyEdges = new Mat();
            CvInvoke.Canny(blurredImage, cannyEdges, 100, 200);

            // Convert result to bitmap
            Bitmap resultBitmap = cannyEdges.ToBitmap();

            return resultBitmap;
        }
    }
}
