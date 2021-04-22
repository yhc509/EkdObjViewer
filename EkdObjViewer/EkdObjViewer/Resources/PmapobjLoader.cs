using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkdObjViewer.Resources
{
    public class PmapobjLoader : BaseImageLoader
    {
        public PmapobjLoader(string fileName) : base(fileName)
        {
            _width = 48;
            _height = 64;
        }
    }
}
