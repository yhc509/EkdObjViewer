using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkdObjViewer.Resources
{
    public class MovLoader : BaseImageLoader
    {
        public MovLoader(string fileName) : base(fileName)
        {
            _width = 48;
            _height = 48;
        }
    }
}
