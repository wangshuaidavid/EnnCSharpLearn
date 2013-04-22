using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{

    interface IIOConnectionRepository
    {

        int AddConnection(int sourcePortId, int SinkPortId);
        void RemoveConnection(int connectionId);
    }
}
