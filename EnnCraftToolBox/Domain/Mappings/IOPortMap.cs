using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    class IOPortMap : ClassMap<IOPort>
    {
        public IOPortMap()
        {
            Id(x => x.Id);
            Map(x => x.Type).CustomType<IOPortType>();
            Map(x => x.PortName);
            Map(x => x.PortValue);

            References<IOConnection>(x => x.RelevantIOConnection).Cascade.All();
            References<EnnEquipment>(x => x.BelongsToEquipment);
        }
    }
}
