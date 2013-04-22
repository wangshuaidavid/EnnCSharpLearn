using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappings
{
    class IOConnectionMap : ClassMap<IOConnection>
    {
        public IOConnectionMap()
        {
            Id(x => x.Id);
            References<IOPort>(x => x.SourcePort).Unique();
            References<IOPort>(x => x.SinkPort).Unique();
        }
    }
}
