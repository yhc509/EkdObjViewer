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
    public class BgLoader : BaseImageLoader
    {
        public BgLoader(string fileName) : base(fileName)
        {
            _width = 210;
            _height = 280;
        }

        public new void Load()
        {
            _image = LoadFromFile(_fileName);
        }

        public new Bitmap GetImage()
        {
            var bitmap = new Bitmap(_width, _height);
            using (var g = Graphics.FromImage(bitmap))
            {
                if(_image == null)
                    g.FillRectangle(new SolidBrush(Color.White), new RectangleF(0, 0, _width, _height));
                else
                    g.DrawImage(_image as Bitmap, 0, 0, _width, _height);
                return bitmap;
            }
        }

        protected new static Bitmap LoadFromFile(string fileName)
        {
            var path = GetFileName(fileName);
            if (string.IsNullOrEmpty(path)) return null;

            var image = Image.FromFile(path) as Bitmap;
            return image;
        }

    }
}
