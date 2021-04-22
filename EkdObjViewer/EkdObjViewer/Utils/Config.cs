using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkdObjViewer.Utils
{
    [Serializable]
    public class Config
    {
        public string DirectoryPath;

        public int DefaultSpeedIndex;
        public int DefaultBgIndex;

        public string AtkFileName;
        public string MovFileName;
        public string SpcFileName;

        public string PmapFrontFileName;
        public string PmapBackFileName;

        public string FaceFileName;
        public string FaceLargeFileName;

        public string[] BgFileNames;

        public Config()
        {
            DefaultSpeedIndex = 1;
            DefaultBgIndex = 0;

            AtkFileName = "atk";
            MovFileName = "mov";
            SpcFileName = "spc";

            PmapFrontFileName = "x";
            PmapBackFileName = "y";

            FaceFileName = "face";
            FaceLargeFileName = "face2";

            BgFileNames = new string[] { "BG_1", "BG_2", "없음" };
        }
    }
}
