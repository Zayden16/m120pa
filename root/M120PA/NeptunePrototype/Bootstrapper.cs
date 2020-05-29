using System.Windows;
using Caliburn.Micro;
using NeptunePrototype.ViewModels;

namespace NeptunePrototype
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}