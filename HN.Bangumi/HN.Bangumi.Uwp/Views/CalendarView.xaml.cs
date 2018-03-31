using HN.Bangumi.Uwp.ViewModels;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Controls;

namespace HN.Bangumi.Uwp.Views
{
    public sealed partial class CalendarView : Page
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        public CalendarViewModel ViewModel => (CalendarViewModel)DataContext;

        private void ImageExBase_OnImageExFailed(object sender, ImageExFailedEventArgs e)
        {
            ViewModel.RaisePropertyChanged("");
        }
    }
}