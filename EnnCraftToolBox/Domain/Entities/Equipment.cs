using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Equipment
    {
        public virtual int Id { get; set; }
        public virtual string EquipName { get; set; }
        public virtual string EquipDescription { get; set; }
    }
}
