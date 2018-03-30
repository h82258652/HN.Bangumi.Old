using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            var serviceLocator = new AutofacServiceLocator(ConfigureAutofacContainer());
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        private static IContainer ConfigureAutofacContainer()
        {
            var containerBuilder = new ContainerBuilder();

            return containerBuilder.Build();
        }
    }
}