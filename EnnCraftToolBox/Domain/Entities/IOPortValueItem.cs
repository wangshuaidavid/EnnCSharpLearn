using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public enum IOPortValueItemType
    {
        Material,
        Information,
        Energy,
    }

    public class IOPortValueItem
    {
        public virtual int Id { get; set; }
        public virtual string ValueItemName { get; set; }
        public virtual string ValueItemUnitName { get; set; }
        public virtual double valueItemValue { get; set; }
        public virtual IOPortValueItemType Type { get; set; }
    }
}
