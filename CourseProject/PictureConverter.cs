using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace CourseProject
{
    public class PictureConverter
    {
        private int Boundary { get; set; } = 128;
        public int Width { get; set; }
        public int Height { get; set; }
        public int GroupSize { get; set; } = 10;
        public List<int> Convert(string path)
        {
            var result = new List<int>();
            var image = new Bitmap(path);
            var resizeimage = new Bitmap(10,10);
            Height = resizeimage.Height; // размер выходного листа
            Width = resizeimage.Width;

            for (int y = 0; y < resizeimage.Height; y += GroupSize)
            {
                for (int x = 0; x < resizeimage.Width; x += GroupSize)
                {
                    var pixel = resizeimage.GetPixel(x, y);
                    var value = GrayGradation(pixel);
                    result.Add(value);
                }
            }
            
            return result;
        }
        private int GrayGradation(Color pixel) // приведение к градации серого
        {
            var result = 0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B;
            return result < Boundary ? 0 : 1;
        }
        public void Save(string path,List<int> pixels)
        {
            var image = new Bitmap(Width,Height);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    var color = pixels[y * Width + x] == 1? Color.White:Color.Black;
                    image.SetPixel(x, y, color);

                }
            }
            image.Save(path);
        }
    }
}
