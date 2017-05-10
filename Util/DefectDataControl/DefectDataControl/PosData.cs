using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectDataControl
{
    class PosData
    {
        public PosData(int left, int top, int width, int height)
        {
            left_ = left;
            top_ = top;
            width_ = width;
            height_ = height;
        }
        public int left_;
        public int top_;
        public int width_;
        public int height_;
    }
}
