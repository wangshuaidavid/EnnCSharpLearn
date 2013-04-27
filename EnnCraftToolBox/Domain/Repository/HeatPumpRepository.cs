using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Repository
{
    public class HeatPumpRepository : AbstractRepository, IEquipmentRepository
    {

        public Equipment CreateEquip()
        {
            HeatPump returnHeatPump = null;
            
            using (ITransaction transaction = session.BeginTransaction())
            {
                HeatPump equip = new HeatPump { EquipName = "HeatPump", EquipDescription = "description xxx" };

                IOPort EleQIn = new IOPort();
                EleQIn.PortName = "EleQIn";
                EleQIn.Type = IOPortType.InputTypePort;
                EleQIn.BelongsToEquipment = equip;

                IOPort CwQIn = new IOPort();
                CwQIn.PortName = "CwQIn";
                CwQIn.Type = IOPortType.InputTypePort;
                CwQIn.BelongsToEquipment = equip;


                IOPort CoolingQOut = new IOPort();
                CoolingQOut.PortName = "CoolingQOut";
                CoolingQOut.Type = IOPortType.OutputTypePort;
                CoolingQOut.BelongsToEquipment = equip;

                IOPort LostQOut = new IOPort();
                LostQOut.PortName = "LostQOut";
                LostQOut.Type = IOPortType.OutputTypePort;
                LostQOut.BelongsToEquipment = equip;

                equip.EleQIn = EleQIn;
                equip.CwQIn = CwQIn;

                equip.CoolingQOut = CoolingQOut;
                equip.LostQOut = LostQOut;

                session.Save(equip);
                transaction.Commit();
                returnHeatPump = equip;
            }
            
            return returnHeatPump;
        }

        public void Update(Equipment equip)
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
                HeatPump equip = session.Get<HeatPump>(equipId);

                this.removePortRelevantConnectWithGivenSession(equip.CwQIn, session);
                this.removePortRelevantConnectWithGivenSession(equip.EleQIn, session);
                this.removePortRelevantConnectWithGivenSession(equip.CoolingQOut, session);
                this.removePortRelevantConnectWithGivenSession(equip.LostQOut, session);
                session.Delete(equip);
                transaction.Commit();
            }
        }

        public Equipment GetById(int equipId)
        {
            HeatPump equipFromDb = null;
            equipFromDb = session.Get<HeatPump>(equipId);
            return equipFromDb;
        }
    }
}
