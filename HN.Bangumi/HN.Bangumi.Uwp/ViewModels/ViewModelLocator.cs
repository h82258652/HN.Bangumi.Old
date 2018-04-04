using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;
using HN.Bangumi.OAuth;
using HN.Bangumi.Services;
using HN.Bangumi.Uwp.Configuration;
using HN.Bangumi.Uwp.OAuth;
using HN.Bangumi.Uwp.Views;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        public const string SubjectViewKey = "Subject";

        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        public CalendarViewModel Calendar => ServiceLocator.Current.GetInstance<CalendarViewModel>();

        public SubjectViewModel Subject => ServiceLocator.Current.GetInstance<SubjectViewModel>();

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<AppSettings>();

            containerBuilder.RegisterType<UwpOAuthProvider>().As<IOAuthProvider>();

            containerBuilder.RegisterInstance(CreateNavigationService());
            containerBuilder.RegisterType<UserService>();
            containerBuilder.RegisterType<CalendarService>();
            containerBuilder.RegisterType<SubjectService>();
            containerBuilder.RegisterType<ProgressService>();

            containerBuilder.RegisterType<CalendarViewModel>().SingleInstance();
            containerBuilder.RegisterType<SubjectViewModel>();

            return containerBuilder.Build();
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure(SubjectViewKey, typeof(SubjectView));
            return navigationService;
        }
    }
}