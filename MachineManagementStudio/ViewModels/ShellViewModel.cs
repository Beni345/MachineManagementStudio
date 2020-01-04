using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagementStudio.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        public void LoadCuttingMachinesView()
        {
            ActivateItem(new CuttingMachinesViewModel());
        }
    }
}
