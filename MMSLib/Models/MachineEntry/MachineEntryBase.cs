using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.Models.MachineEntry
{
    public class MachineEntryBase
    {
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }

        public string SoftwareNumber { get; set; }
        public string ManualNumber { get; set; }
        public string CircuitDiagramNumber { get; set; }
        public string MechanicalNumber { get; set; }
        public string Comment { get; set; }

    }
}
