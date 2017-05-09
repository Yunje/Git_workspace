using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectDataControl
{
    class PosData
    {
        public PosData(int startpos, int endpos, int width, int height)
        {
            startpos_ = startpos;
            endpos_ = endpos;
            width_ = width;
            height_ = height;
        }
        public int startpos_;
        public int endpos_;
        public int width_;
        public int height_;
    }
}
