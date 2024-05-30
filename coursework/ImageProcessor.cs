using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    /// The ImageProcessor class is responsible for processing images using an edge detector.
    public class ImageProcessor
    {
        private EdgeDetector _edgeDetector;

        public ImageProcessor(EdgeDetector edgeDetector)
        {
            _edgeDetector = edgeDetector;
        }
        /// Method to process an image using the configured edge detector.
        /// <param name="image">The image to be processed.</param>
        /// <returns>The processed image with detected edges as a Bitmap object.</returns>
        public Bitmap ProcessImage(Images image)
        {
            return _edgeDetector.DetectEdges(image);
        }
    }
}
