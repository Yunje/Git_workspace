using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.ComponentModel;

namespace DefectDataControl
{
    public class BmpData //: INotifyPropertyChanged
    {
        public BmpData(string filepath)
        {
            Bitmap bitmap = (Bitmap)Image.FromFile(@filepath);
            width_ = bitmap.Width;
            height_ = bitmap.Height;
            im_ = new byte[height_, width_];

            for(int i = 0; i < height_; i++)
            {
                for(int j = 0; j < width_; j++)
                {
                    im_[i,j] = 0;
                    Color pixel = bitmap.GetPixel(j, i);
                    im_[i, j] = (byte)(((int)pixel.R / 3) + ((int)pixel.G / 3) + ((int)pixel.B / 3));
                }
            }

            string []filename_segments = filepath.Split(new char[] {'\\'});
            filename_ = filename_segments.Last();
        }

        public BmpData(BmpData obj)
        {
            im_ = (byte[,])obj.im_.Clone();
            width_ = obj.width_;
            height_ = obj.height_;
            filename_ = (string)obj.filename_.Clone();
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        
        //private void RaisePropertyChanged(string propName)
        //{
        //    PropertyChanged(this, new PropertyChangedEventArgs(propName));
        //}

        public byte[,] im_;
        public int width_;
        public int height_;
        public string filename_;
    }

    public class MimData
    {
        
    }

    public class BmpInfo
    {
        public int width_;
        public int height_;
        public string filename_;
        public BmpInfo(int width, int height, string filename)
        {
            width_ = width;
            height_ = height;
            filename_ = filename;
        }
    }
}
