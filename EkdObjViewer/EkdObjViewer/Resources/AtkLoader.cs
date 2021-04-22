using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkdObjViewer.Resources
{
    public class AtkLoader : BaseImageLoader
    {
        public AtkLoader(string fileName) : base(fileName)
        {
            _width = 64;
            _height = 64;
        }
    }
}
