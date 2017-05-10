using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.ComponentModel;
using System.IO;

namespace DefectDataControl
{
    public class BmpData //: INotifyPropertyChanged
    {
        //public BmpData(string filepath)
        //{
        //    Bitmap bitmap = (Bitmap)Image.FromFile(@filepath);
        //    width_ = bitmap.Width;
        //    height_ = bitmap.Height;
        //    im_ = new byte[height_, width_];

        //    for(int i = 0; i < height_; i++)
        //    {
        //        for(int j = 0; j < width_; j++)
        //        {
        //            im_[i,j] = 0;
        //            Color pixel = bitmap.GetPixel(j, i);
        //            im_[i, j] = (byte)(((int)pixel.R / 3) + ((int)pixel.G / 3) + ((int)pixel.B / 3));
        //        }
        //    }

        //    string []filename_segments = filepath.Split(new char[] {'\\'});
        //    filename_ = filename_segments.Last();
        //    filepath_ = filepath;
        //}

        public BmpData(string filepath)
        {
            bitmap_ = (Bitmap)Image.FromFile(@filepath);
            width_ = bitmap_.Width;
            height_ = bitmap_.Height;

            filename_ = Path.GetFileName(filepath);
            folderpath_ = Path.GetDirectoryName(filepath);
        }

        public BmpData(BmpData obj)
        {
            bitmap_ = (Bitmap)obj.bitmap_.Clone();
            width_ = obj.width_;
            height_ = obj.height_;
            filename_ = (string)obj.filename_.Clone();
        }

        public void CropNSave(int left, int top, int width, int height)
        {
            Rectangle rect = new Rectangle(left, top, width, height);
            Bitmap croppedimage;
            croppedimage = bitmap_.Clone(rect, bitmap_.PixelFormat);
            croppedimage.Save(folderpath_ + "\\cropped\\L" + left + "_T" + top + "_W" + width + "_H" + height + filename_);
            croppedimage.Dispose();
        }

        Bitmap bitmap_;
        public int width_;
        public int height_;
        public string filename_;
        public string folderpath_;
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
