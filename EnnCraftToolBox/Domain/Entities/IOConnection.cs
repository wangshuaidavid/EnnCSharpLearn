using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IOConnection
    {
        public virtual int Id { get; set; }

        public virtual IOPort SourcePort { get; set; }

        public virtual IOPort SinkPort { get; set; }

    }
}
