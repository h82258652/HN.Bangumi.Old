using HN.Bangumi.Uwp.Configuration;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using CalendarView = HN.Bangumi.Uwp.Views.CalendarView;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace HN.Bangumi.Uwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CalendarView));
        }
    }
}