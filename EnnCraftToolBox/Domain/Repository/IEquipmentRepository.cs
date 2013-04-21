using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IEquipmentRepository
    {
        void Add(EnnEquipment equip);
        void Update(EnnEquipment equip);
        void Remove(EnnEquipment equip);
        EnnEquipment GetById(int equipId);
    }
}
