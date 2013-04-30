using Domain.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Mappings
{
    class IOPortValueItemMap : ClassMap<IOPortValueItem>
    {

        public IOPortValueItemMap()
        {
            Id(x => x.Id);
            Map(x => x.ValueItemName);
            Map(x => x.ValueItemUnitName);
            Map(x => x.valueItemValue);
            Map(x => x.Type).CustomType<IOPortValueItemType>();
        }
    }
}
