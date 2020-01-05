using MMSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagementStudio.EventModels
{
    public class ExistingMachineEventModel
    {
        public Machine Machine { get; set; }

        public ExistingMachineEventModel(Machine machine)
        {
            Machine = machine;
        }
    }
}
