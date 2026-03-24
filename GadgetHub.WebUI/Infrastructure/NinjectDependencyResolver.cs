using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;
using GadgetHub.Domain.Concrete;
using System.Configuration;

namespace GadgetHub.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel myKernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            myKernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type myServiceType)
        {
            return myKernel.TryGet(myServiceType);
        }

        public IEnumerable<object> GetServices(Type myServiceType)
        {
            return myKernel.GetAll(myServiceType);
        }

        private void AddBindings()
        {
            myKernel.Bind<IGadgetsRepository>().To<EFGadgetRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            myKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }

    }
}