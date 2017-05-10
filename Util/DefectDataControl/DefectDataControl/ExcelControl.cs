using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace DefectDataControl
{
    class ExcelControl
    {
        Excel.Application excel_app_;
        Excel.Workbook wb_;
        Excel.Worksheet ws_;

        public ExcelControl()
        {
            excel_app_ = null;
            wb_ = null;
            ws_ = null;
            Init();
        }

        public void Add2Cell(int val, int pos_i, int pos_j)
        {
            if (pos_i < 1 || pos_j < 1) return;
            ws_.Cells[pos_i, pos_j] = val;
        }

        public void Add2Cell(string val, int pos_i, int pos_j)
        {
            if (pos_i < 1 || pos_j < 1) return;
            ws_.Cells[pos_i, pos_j] = val;
        }

        //public void AddImage2Cell(string imagepath, int left, int top, int width, int height){
        //    ws_.Shapes.AddPicture(imagepath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, left, top, width, height);
        //}

        public void AddImage2Cell(string imagepath, int pos_i, int pos_j, float width, float height)
        {
            if (pos_i < 1 || pos_j < 1) return;

            //const float kColumnRowRatio = (float)(13.57 / 75);
            const float kColumnWidth2PixelRatio = (float)(13.57 / 87.5);
            float left = 0, top = 0;
            for (int i = 1; i < pos_i; i++)
            {
                top += ws_.Rows[i].RowHeight;
            }
            for (int j = 1; j < pos_j; j++)
            {
                left += ws_.Columns[j].ColumnWidth / kColumnWidth2PixelRatio;
            }
            ws_.Columns[pos_j].ColumnWidth = width * kColumnWidth2PixelRatio;
            ws_.Rows[pos_i].RowHeight = height;
            ws_.Shapes.AddPicture(imagepath, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, left, top, width, height);
        }

        public void SaveExcelFile(string str)
        {
            wb_.SaveAs(@str, Excel.XlFileFormat.xlWorkbookNormal);
        }

        private void Init()
        {
            excel_app_ = new Excel.Application();
            wb_ = excel_app_.Workbooks.Add();
            ws_ = wb_.Worksheets.get_Item(1) as Excel.Worksheet;
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        ~ExcelControl()
        {
            wb_.Close(true);
            excel_app_.Quit();

            ReleaseExcelObject(ws_);
            ReleaseExcelObject(wb_);
            ReleaseExcelObject(excel_app_);
        }
    }
}
