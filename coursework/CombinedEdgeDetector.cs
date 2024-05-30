using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    /// Combined edge detector class that utilizes both SimpleEdgeDetector and CannyEdgeDetector.
    public class CombinedEdgeDetector : EdgeDetector
    {
        private SimpleEdgeDetector _simpleDetector;
        private CannyEdgeDetector _cannyDetector;

        public CombinedEdgeDetector(SimpleEdgeDetector simpleDetector, CannyEdgeDetector cannyDetector)
        {
            _simpleDetector = simpleDetector;
            _cannyDetector = cannyDetector;
        }

        /// Detects edges using both SimpleEdgeDetector and CannyEdgeDetector.
        public override Bitmap DetectEdges(Images image)
        {
            Bitmap cannyEdges = _cannyDetector.DetectEdges(image);
            image.imgForSearch = cannyEdges.ToImage<Bgr, byte>();
            Bitmap simpleEdges = _simpleDetector.DetectEdges(image);

            return simpleEdges;
        }
    }
}
