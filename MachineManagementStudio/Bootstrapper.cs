using Caliburn.Micro;
using MachineManagementStudio.ViewModels;
using MMSLib.Global;
using MMSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MachineManagementStudio
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

            GlobalConfig.InitializeConnection("MachineManagementDb");
        }
    }
}
