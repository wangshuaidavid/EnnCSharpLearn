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

        public Equipment CreateEquip()
        {
            HeatPump returnHeatPump = null;



            return returnHeatPump;
        }

        public void Update(Equipment equip)
        {
            throw new NotImplementedException();
        }

        public void Remove(int equipId)
        {
            throw new NotImplementedException();
        }

        public Equipment GetById(int equipId)
        {
            throw new NotImplementedException();
        }
    }
}
