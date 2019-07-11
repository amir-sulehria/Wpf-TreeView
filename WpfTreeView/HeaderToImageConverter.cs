using System;
using System.IO;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WpfTreeView
{
    //converts a full path  to specific image type of a drive, folder or file
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string)value;
            if (path == null)
                return null;

            //by default
            var image = "Images/file.png";
            var name = MainWindow.GetFileFolderName(path);

            if (string.IsNullOrEmpty(name))
                image = "Images/drive.png";
            //check if file or folder
            else if(new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder-closed.png";

            }
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
