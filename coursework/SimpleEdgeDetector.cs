using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    /// Class for detecting edges using a simple edge detection algorithm.
    public class SimpleEdgeDetector : EdgeDetector
    {
        public override Bitmap DetectEdges(Images image)
        {
            List<List<Point>> edges = new List<List<Point>>();
            Image<Bgr,byte> imageForSearch = image.imgForSearch;
            // Create a matrix to track visited pixels
            bool[,] visited = new bool[imageForSearch.Height, imageForSearch.Width];

            for (int y = 0; y < imageForSearch.Height; y++)
            {
                for (int x = 0; x < imageForSearch.Width; x++)
                {
                    // If the pixel is not visited and is an edge, start a new object
                    if (!visited[y, x] && IsEdgePoint(imageForSearch, x, y))
                    {
                        List<Point> currentObject = new List<Point>();
                        ExploreObject(imageForSearch, x, y, visited, currentObject);
                        edges.Add(currentObject);
                    }
                }
            }
            return DrawBoundingBoxes(imageForSearch.Width, imageForSearch.Height, edges);
        }

        private Bitmap DrawBoundingBoxes(int width, int height, List<List<Point>> edges)
        {
            Bitmap bitmap = new Bitmap(width, height);
            BoundingBoxDrawer drawer = new BoundingBoxDrawer();
            foreach (List<Point> edge in edges)
            {
                if (edge.Count > 100)
                {
                    drawer.DrawBoundingBox(bitmap, edge);
                }
            }
            return bitmap;
        }

        private void ExploreObject(Image<Bgr, byte> image, int startX, int startY, bool[,] visited, List<Point> currentObject)
        {
            // Create a queue for processing pixels
            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(new Point(startX, startY));

            // Add the starting pixel to the object
            currentObject.Add(new Point(startX, startY));
            visited[startY, startX] = true;

            // Array of directions to neighboring pixels
            int[] dx = { -1, 0, 1, 1, 1, 0, -1, -1 };
            int[] dy = { -1, -1, -1, 0, 1, 1, 1, 0 };

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();

                // Iterate through all neighboring pixels
                for (int i = 0; i < 8; i++)
                {
                    int newX = current.X + dx[i];
                    int newY = current.Y + dy[i];

                    // Check if the new pixel coordinates are within the image bounds and not visited yet
                    if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height
                        && !visited[newY, newX] && IsEdgePoint(image, newX, newY))
                    {
                        // Add the pixel to the object, mark it as visited, and enqueue it for further traversal
                        currentObject.Add(new Point(newX, newY));
                        visited[newY, newX] = true;
                        queue.Enqueue(new Point(newX, newY));
                    }
                }
            }
        }
        private bool IsEdgePoint(Image<Bgr, byte> image, int x, int y)
        {
            byte pixelValue = image.Data[y, x, 0]; // In grayscale images, channel 0 corresponds to brightness
            return pixelValue != 0;
        }
    }
}
