using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    class HeatPumpRepository : AbstractRepository, IEquipmentRepository
    {

        public EnnEquipment CreateEquip()
        {
            throw new NotImplementedException();
        }

        public void Update(EnnEquipment equip)
        {
            throw new NotImplementedException();
        }

        public void Remove(int equipId)
        {
            throw new NotImplementedException();
        }

        public EnnEquipment GetById(int equipId)
        {
            throw new NotImplementedException();
        }
    }
}
