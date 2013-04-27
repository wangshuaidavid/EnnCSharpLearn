using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// deprecated
namespace Domain.Repository
{
    public interface IEquipmentRepository : IDisposable
    {
        Equipment CreateEquip();
        void Update(Equipment equip);
        void Remove(int equipId);
        Equipment GetById(int equipId);
    }
}
