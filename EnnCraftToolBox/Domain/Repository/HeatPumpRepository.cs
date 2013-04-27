using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    class HeatPumpRepository : AbstractEquipmentRepository
    {


        public override EnnEquipment CreateEquip()
        {
            throw new NotImplementedException();
        }

        public override void Update(Entities.EnnEquipment equip)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int equipId)
        {
            throw new NotImplementedException();
        }

        public override EnnEquipment GetById(int equipId)
        {
            throw new NotImplementedException();
        }
    }
}
