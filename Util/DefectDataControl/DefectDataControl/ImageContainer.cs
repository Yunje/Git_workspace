using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectDataControl
{
    class ImageContainer
    {
        public List<BmpData> datalist;
        public List<PosData> poslist;
        public ImageContainer()
        {
            datalist = new List<BmpData>();
            poslist = new List<PosData>();
        }

        public void Init(string []files)
        {
            foreach (string file in files)
            {
                if (file.Contains(".bmp"))
                {
                    datalist.Add(new BmpData(file));
                }
            }
        }

        public void Run()
        {

        }

        public void Save2ExcelFile()
        {

        }
    }
}
