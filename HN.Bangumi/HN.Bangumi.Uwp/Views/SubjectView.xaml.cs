using HN.Bangumi.Models;
using HN.Bangumi.Services;
using HN.Bangumi.Uwp.ViewModels;
using Newtonsoft.Json;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace HN.Bangumi.Uwp.Views
{
    public sealed partial class SubjectView
    {
        public SubjectViewModel ViewModel => (SubjectViewModel)DataContext;

        public SubjectView()
        {
            InitializeComponent();
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