using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EnnEquipmentRepository : AbstractEquipmentRepository
    {


        public EnnEquipment CreateEquip()
        {

            EnnEquipment returnEquipt = null;
            using (ITransaction transaction = session.BeginTransaction())
            {
                EnnEquipment equip = new EnnEquipment { EquipName = "DemoEquip", EquipDescription = "description xxx" };
                IOPort inputPort1 = new IOPort();
                inputPort1.PortName = "input port 1";
                inputPort1.Type = IOPortType.InputTypePort;
                inputPort1.BelongsToEquipment = equip;

                IOPort inputPort2 = new IOPort();
                inputPort2.PortName = "input port 2";
                inputPort2.Type = IOPortType.InputTypePort;
                inputPort2.BelongsToEquipment = equip;


                IOPort outputPort1 = new IOPort();
                outputPort1.PortName = "output port 1";
                outputPort1.Type = IOPortType.OutputTypePort;
                outputPort1.BelongsToEquipment = equip;

                IOPort outputPort2 = new IOPort();
                outputPort2.PortName = "output port 2";
                outputPort2.Type = IOPortType.OutputTypePort;
                outputPort2.BelongsToEquipment = equip;

                equip.InputPort1 = inputPort1;
                equip.InputPort2 = inputPort2;

                equip.OutputPort1 = outputPort1;
                equip.OutputPort2 = outputPort2;

                session.Save(equip);
                transaction.Commit();
                returnEquipt = equip;
            }
            return returnEquipt;
        }

        public void Update(EnnEquipment equip)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(equip);
                transaction.Commit();
            }
        }


        private void removePortRelevantConnectWithGivenSession(IOPort thePort, ISession session)
        {
            IOConnection conn = thePort.RelevantIOConnection;
            if (conn == null)
            {
                return;
            }
            conn.SourcePort.RelevantIOConnection = null;
            conn.SinkPort.RelevantIOConnection = null;
            session.Delete(conn);
        }

        public void Remove(int equipId)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                EnnEquipment equip = session.Get<EnnEquipment>(equipId);

                this.removePortRelevantConnectWithGivenSession(equip.InputPort1, session);
                this.removePortRelevantConnectWithGivenSession(equip.InputPort2, session);
                this.removePortRelevantConnectWithGivenSession(equip.OutputPort1, session);
                this.removePortRelevantConnectWithGivenSession(equip.OutputPort2, session);
                session.Delete(equip);
                transaction.Commit();
            }
        }


        public EnnEquipment GetById(int equipId)
        {
            EnnEquipment equipFromDb = null;
            equipFromDb = session.Get<EnnEquipment>(equipId);
            return equipFromDb;
        }

    }
}
