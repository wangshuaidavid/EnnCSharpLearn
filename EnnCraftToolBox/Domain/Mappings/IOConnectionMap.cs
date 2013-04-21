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
            References<IOPort>(x => x.InputPort).Unique();
            References<IOPort>(x => x.OutputPort).Unique();
        }
    }
}
