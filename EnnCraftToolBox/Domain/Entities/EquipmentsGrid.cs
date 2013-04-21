using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class EquipmentsGrid
    {
        public virtual int Id { get; set; }
        public virtual IList<EnnEquipment> AllEquipments { get; set; }

        public EquipmentsGrid()
        {
            AllEquipments = new List<EnnEquipment>();
        }
    }
}
