using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursework
{
    //Class for drawing bounding boxes
    public class BoundingBoxDrawer
    {
        public void DrawBoundingBox(Bitmap image, List<Point> edges)
        {
            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;

            foreach (Point point in edges)
            {
                int x = point.X;
                int y = point.Y;

                if (x < minX) minX = x;
                if (x > maxX) maxX = x;
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }

            using (Graphics g = Graphics.FromImage(image))
            {
                Pen pen = new Pen(Color.Red, 2);
                g.DrawRectangle(pen, minX, minY, maxX - minX, maxY - minY);
            }
        }
    }
}
