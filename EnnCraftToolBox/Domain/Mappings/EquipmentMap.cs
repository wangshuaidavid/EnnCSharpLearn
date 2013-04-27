using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    class EquipmentMap : ClassMap<Equipment>
    {

        public EquipmentMap()
        {
            Id(x => x.Id);
            Map(x => x.EquipName);
            Map(x => x.EquipDescription);
        }
    }
}
