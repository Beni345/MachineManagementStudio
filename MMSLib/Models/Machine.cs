using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.Models
{
    public class Machine
    {
        public ObjectId Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        public string MachineNumber { get; set; }

    }
}
