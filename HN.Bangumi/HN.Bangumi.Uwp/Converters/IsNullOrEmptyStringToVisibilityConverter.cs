using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace HN.Bangumi.Uwp.Converters
{
    public class IsNullOrEmptyStringToVisibilityConverter : IValueConverter
    {
        public bool IsInversed { get; set; }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var str = value as string;
            if (IsInversed)
            {
                return string.IsNullOrEmpty(str) ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return string.IsNullOrEmpty(str) ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}