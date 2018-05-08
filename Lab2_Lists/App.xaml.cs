using System;
using System.Windows;
using Unity;
using Lab2_Lists.Services;
using Lab2_Lists.ViewModel;

namespace Lab2_Lists
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            Container = new UnityContainer();
            ConfigureContainer(Container);
        }
        public static UnityContainer Container;
        private static void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IDynamicStructService, DynamicStructService>()
                     .RegisterType<IDynamicStructSerializerService, DynamicStructBaseSerializerService>();

            var dynamicStructService = container.Resolve<DynamicStructService>();
            var dynamicStructBaseSerializerService = container.Resolve<DynamicStructBaseSerializerService>();
            var viewModel = new DynamicStructViewModel(dynamicStructBaseSerializerService, dynamicStructService);
            container.RegisterInstance(viewModel);
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
        }
    }
}