using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    class EnnEquipmentMap : SubclassMap<EnnEquipment>
    {
        public EnnEquipmentMap()
        {

            Map(x => x.ConstantK);

            References<IOPort>(x => x.InputPort1).Unique().Cascade.All();
            References<IOPort>(x => x.InputPort2).Unique().Cascade.All();

            References<IOPort>(x => x.OutputPort1).Unique().Cascade.All();
            References<IOPort>(x => x.OutputPort2).Unique().Cascade.All();
        }
    }
}
