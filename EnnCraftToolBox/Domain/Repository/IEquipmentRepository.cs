using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IEquipmentRepository : IDisposable
    {
        EnnEquipment CreateEquip();
        void Update(EnnEquipment equip);
        void Remove(int equipId);
        EnnEquipment GetById(int equipId);
    }
}
