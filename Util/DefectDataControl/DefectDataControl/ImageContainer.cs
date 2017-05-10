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
            poslist.Add(new PosData(10, 20, 100, 100));
            poslist.Add(new PosData(40, 50, 100, 100));
            foreach(PosData posdata in poslist)
            {
                datalist[0].CropNSave(posdata.left_, posdata.top_, posdata.width_, posdata.height_);
            }
        }

        public void Save2ExcelFile()
        {
            ExcelControl ex_con = new ExcelControl();
            ex_con.Add2Cell("abs1", 1, 2);
            ex_con.Add2Cell("abs2", 1, 3);
            ex_con.Add2Cell(1, 1, 4);
            ex_con.AddImage2Cell("C:\\Users\\yunje\\Documents\\ImageData\\0Gray.bmp", 5, 5, 50, 40);        
            ex_con.SaveExcelFile("C:\\Users\\yunje\\Documents\\ImageData\\info.xls");
        }
    }
}
