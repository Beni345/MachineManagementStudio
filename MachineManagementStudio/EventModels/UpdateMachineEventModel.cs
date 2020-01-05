using MMSLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagementStudio.EventModels
{
    public class UpdateMachineEventModel
    {
        public Machine Machine { get; set; }

        public UpdateMachineEventModel(Machine machine)
        {
            Machine = machine;
        }

    }
}
