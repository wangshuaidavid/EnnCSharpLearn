using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Repository
{

    public class IOConnectionRepository : AbstractRepository, IIOConnectionRepository
    {

        public int AddConnection(int sourcePortId, int SinkPortId)
        {
            int returnId = GlobleConst.InvalidId;
            using (ITransaction transaction = session.BeginTransaction())
            {
                IOPort sourcePort = session.Get<IOPort>(sourcePortId);
                IOPort sinkPort = session.Get<IOPort>(SinkPortId);
                IOConnection conn = new IOConnection { SourcePort = sourcePort, SinkPort = sinkPort };
                sourcePort.RelevantIOConnection = conn;
                sinkPort.RelevantIOConnection = conn;
                session.Save(conn);
                transaction.Commit();
                returnId = conn.Id;
            }
            return returnId;
        }


        public void RemoveConnection(int connectionId)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                IOConnection conn = session.Get<IOConnection>(connectionId);
                conn.SourcePort.RelevantIOConnection = null;
                conn.SinkPort.RelevantIOConnection = null;
                session.Delete(conn);
                transaction.Commit();
            }
        }
    }
}
