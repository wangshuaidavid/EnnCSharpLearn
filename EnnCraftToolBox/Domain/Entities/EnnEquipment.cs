using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EnnEquipment
    {
        public virtual int Id { get; set; }
        public virtual string EquipName { get; set; }
        public virtual string EquipDescription { get; set; }

        public virtual double ConstantK { get; set; }

        public virtual IOPort InputPort1 { get; set; }
        public virtual IOPort InputPort2 { get; set; }

        public virtual IOPort OutputPort1 { get; set; }
        public virtual IOPort OutputPort2 { get; set; }

    }
}
