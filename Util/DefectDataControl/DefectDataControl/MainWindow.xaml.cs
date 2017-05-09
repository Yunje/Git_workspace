using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DefectDataControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<BmpData> imglist_;

        public MainWindow()
        {
            InitializeComponent();
        }

        //Data binding: http://www.licensespot.com/blog/wpf-listview-binding
        public void LoadImageFolder(object sender, RoutedEventArgs e)
        {
            CommonDialogWrappers.BrowseForFolderDialog dlg = new CommonDialogWrappers.BrowseForFolderDialog(); 
            dlg.Title = "Select a folder and click OK!";
            dlg.InitialExpandedFolder = @"C:\Users\yunje\Documents\ImageData";
            dlg.OKButtonText = "OK!";
            if (true == dlg.ShowDialog(this))
            {
                MessageBox.Show(dlg.SelectedFolder, "Selected Folder");
                //image_container_.Init(dlg.SelectedFolder);
                string[] files;
                files = System.IO.Directory.GetFiles(dlg.SelectedFolder);

                image_container_.Init(files);
                imglist_ = new ObservableCollection<BmpData>();
                List<BmpInfo> list1 = new List<BmpInfo>();
                foreach(BmpData imgdata in image_container_.datalist)
                {
                    list1.Add(new BmpInfo(1,1,"str"));
                    
                    //RaisePropertyChanged("imglist_");
                }
                //FileInfoListView.ItemsSource = null;
                FileInfoListView.ItemsSource = list1;
            }
            else
            {
                MessageBox.Show("Error: Cannot Find Folder");
            }
        }

        public void Run(object sender, RoutedEventArgs e)
        {
            image_container_.Run();
        }

        public void Save2ExcelFile(object sender, RoutedEventArgs e)
        {
            image_container_.Save2ExcelFile();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void RaisePropertyChanged(string propName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private ImageContainer image_container_ = new ImageContainer();
       
    }
}
