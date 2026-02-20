using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using GadgetHub.Domain.Abstract;
using GadgetHub.Domain.Entities;

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
            Mock<IGadgetsRepository> myMock = new Mock<IGadgetsRepository>();

            myMock.Setup(m => m.Gadgets).Returns(new List<Gadget>
            {
                new Gadget
                {
                    Id = 1,
                    Brand = "NovaTech",
                    Price = 199.99m,
                    Category = "Wearable",
                    Description = "PulseBand X – A smart fitness tracker with holographic display and AI-powered health insights."
                },
                new Gadget
                {
                    Id = 2,
                    Brand = "AetherWorks",
                    Price = 349.50m,
                    Category = "Home Automation",
                    Description = "SkyLight Hub – Central smart home controller with voice, gesture, and neural command support."
                },
                new Gadget
                {
                    Id = 3,
                    Brand = "QuantumEdge",
                    Price = 899.00m,
                    Category = "Computing",
                    Description = "NanoCore Mini PC – Compact quantum-assisted desktop for ultra-fast parallel processing tasks."
                },
                new Gadget
                {
                    Id = 4,
                    Brand = "Lumina Labs",
                    Price = 149.75m,
                    Category = "Audio",
                    Description = "EchoSphere Pods – Noise-cancelling wireless earbuds with adaptive 3D sound mapping."
                },
                new Gadget
                {
                    Id = 5,
                    Brand = "TerraDrive",
                    Price = 1299.99m,
                    Category = "Transportation",
                    Description = "GlideBoard Pro – Self-balancing hoverboard with terrain-adaptive suspension and GPS tracking."
                },
                new Gadget
                {
                    Id = 6,
                    Brand = "CryoTek",
                    Price = 499.00m,
                    Category = "Kitchen Tech",
                    Description = "FrostChef 360 – Smart countertop freezer with instant flash-freeze and recipe integration."
                },
                new Gadget
                {
                    Id = 7,
                    Brand = "Voltaris",
                    Price = 259.95m,
                    Category = "Energy",
                    Description = "SolarPack Flex – Portable solar battery with flexible panels and rapid device charging."
                },
                new Gadget
                {
                    Id = 8,
                    Brand = "NeuroSync",
                    Price = 599.00m,
                    Category = "Health Tech",
                    Description = "MindWave Headset – Focus-enhancing neural feedback device with real-time cognitive tracking."
                }
            });
            myKernel.Bind<IGadgetsRepository>().ToConstant(myMock.Object);
        }

    }
}