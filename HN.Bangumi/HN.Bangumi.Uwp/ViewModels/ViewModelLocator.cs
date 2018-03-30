using System;
using Autofac;
using Autofac.Extras.CommonServiceLocator;

namespace HN.Bangumi.Uwp.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            AutofacServiceLocator serviceLocator = new AutofacServiceLocator(new ContainerBuilder().Build());

            throw new NotImplementedException();
        }
    }
}