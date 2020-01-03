using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMSLib.Models
{
    public class MachineType
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }
}
