using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace EkdObjViewer.Resources
{
    public class BaseImageLoader
    {

        protected Bitmap _image;

        protected string _fileName;
        protected int _width;
        protected int _height;

        public int Width => _width;
        public int Height => _height;

        public BaseImageLoader(string fileName)
        {
            _fileName = fileName;
        }

        public void Load()
        {
            _image = LoadFromFile(_fileName);
        }

        public Bitmap GetImage()
        {
            return GetFrameImage(0);
        }

        public Bitmap GetFrameImage(int frame)
        {
            if (_image == null) return null;
                        
            return GetImageCrop(_image, frame);
        }


        protected Bitmap GetImageCrop(Image origin, int frameIndex)
        {
            var bitmap = new Bitmap(_width, _height);
            Rectangle rect = new Rectangle(0, frameIndex * _height, _width, _height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(origin as Bitmap, 0, 0, rect, GraphicsUnit.Pixel);
                return bitmap;
            }
        }

        protected static Bitmap LoadFromFile(string fileName)
        {
            var path = GetFileName(fileName);
            if (string.IsNullOrEmpty(path)) return null;

            var image = Image.FromFile(path) as Bitmap;
            if (image.PixelFormat == PixelFormat.Format8bppIndexed)
            {
                var bgColor = image.Palette.Entries[0];
                image.MakeTransparent(bgColor);
            }
            else
            {
                image.MakeTransparent();
            }

            return image;
        }

        protected static string GetFileName(string fileName)
        {
            var bmp = $"{fileName}.bmp";
            if (File.Exists(bmp))
                return bmp;

            var jpg = $"{fileName}.jpg";
            if (File.Exists(jpg))
                return jpg;

            var png = $"{fileName}.png";
            if (File.Exists(png))
                return png;

            return null;
        }
    }
}
