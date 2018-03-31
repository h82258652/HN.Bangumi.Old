using Windows.UI.Xaml;
using HN.Bangumi.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using HN.Bangumi.Services;
using HN.Bangumi.Uwp.ViewModels;
using Newtonsoft.Json;

namespace HN.Bangumi.Uwp.Views
{
    public sealed partial class SubjectView : Page
    {
        public SubjectViewModel ViewModel => (SubjectViewModel)DataContext;

        public SubjectView()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var subject = (Subject)e.Parameter;
            ViewModel.Subject = subject;

            var subjectService = new SubjectService();
            var ss = await subjectService.Get(subject.Id, ResponseGroup.Large);
            ViewModel.Subject = ss;

            ForTest.Text = JsonConvert.SerializeObject(ss);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}