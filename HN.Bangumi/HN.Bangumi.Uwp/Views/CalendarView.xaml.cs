using HN.Bangumi.Uwp.ViewModels;

namespace HN.Bangumi.Uwp.Views
{
    public sealed partial class CalendarView
    {
        public CalendarView()
        {
            InitializeComponent();
        }

        public CalendarViewModel ViewModel => (CalendarViewModel)DataContext;
    }
}