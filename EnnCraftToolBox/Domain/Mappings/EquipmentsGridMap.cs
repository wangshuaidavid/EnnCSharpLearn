using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    class EquipmentsGridMap : ClassMap<EquipmentsGrid>
    {
        public EquipmentsGridMap()
        {
            Id(x => x.Id);
            HasMany(x => x.AllEquipments).Cascade.All();
        }
    }
}
