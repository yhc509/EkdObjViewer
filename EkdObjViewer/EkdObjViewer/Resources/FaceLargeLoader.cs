﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace EkdObjViewer.Resources
{
    public class FaceLargeLoader : BaseImageLoader
    {
        public FaceLargeLoader(string fileName) : base(fileName)
        {
            _width = 196;
            _height = 280;
        }

        public new void Load()
        {
            _image = LoadFromFile(_fileName);
        }

        protected new static Bitmap LoadFromFile(string fileName)
        {
            var path = GetFileName(fileName);
            if (string.IsNullOrEmpty(path)) return null;

            var image = Image.FromFile(path) as Bitmap;
            image.MakeTransparent(Color.FromArgb(247, 0, 255));
            return image;
        }

    }
}
