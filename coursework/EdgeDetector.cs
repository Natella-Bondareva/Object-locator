using Emgu.CV;
using Emgu.CV.Structure;

namespace coursework
{
    /// Abstract class representing an edge detector.
    public abstract class EdgeDetector
    {
        public abstract Bitmap DetectEdges(Images image);
    }
}