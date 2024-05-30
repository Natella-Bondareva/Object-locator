using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace coursework
{
    public partial class Form1 : Form
    {
        private Images _image; // Current image

        public Form1()
        {
            InitializeComponent();
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = openFileDialog1.ShowDialog();

                if (res == DialogResult.OK)
                {
                    // If the user selected a file, load it into the _image variable
                    _image = new Images(openFileDialog1.FileName);
                    pictureBox1.Image = _image.Bitmap;
                }
                else
                {
                    MessageBox.Show("No file selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FindObjButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Create an instance of CombinedEdgeDetector object for finding contours
                CombinedEdgeDetector combinedEdgeDetector =
                    new CombinedEdgeDetector(new SimpleEdgeDetector(), new CannyEdgeDetector());
                ImageProcessor imageProcessor = new ImageProcessor(combinedEdgeDetector);

                Bitmap edges = imageProcessor.ProcessImage(_image);
                // Find contours on the image

                if (checkBox.Checked)
                {
                    // If the option is selected, combine the edges image with the search image
                    var combinedImage = CombineBitmaps(edges, _image.imgForSearch.AsBitmap());
                    pictureBox2.Image = combinedImage;
                }
                else
                {
                    // Otherwise, combine the edges image with the original image
                    var combinedImage = CombineBitmaps(edges, _image.originalImg.AsBitmap());
                    pictureBox2.Image = combinedImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Draw both bitmaps onto the result bitmap
        private Bitmap CombineBitmaps(Bitmap bmp1, Bitmap bmp2)
        {
            int width = Math.Max(bmp1.Width, bmp2.Width);
            int height = Math.Max(bmp1.Height, bmp2.Height);

            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {

                g.DrawImage(bmp2, 0, 0);
                g.DrawImage(bmp1, 0, 0);
            }

            return result;
        }

        private void SaveImgButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp",
                Title = "Save an Image File"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveImageFromPictureBox(pictureBox2, saveFileDialog.FileName);
            }
        }
        private void SaveImageFromPictureBox(PictureBox pictureBox, string filePath)
        {
            if (pictureBox.Image != null)
            {
                try
                {
                    // Save the image from the pictureBox to the specified file path
                    pictureBox.Image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png); // Ви можете змінити формат за потреби
                    MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
