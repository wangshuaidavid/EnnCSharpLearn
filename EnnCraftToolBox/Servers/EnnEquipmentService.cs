using Domain.Entities;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public class EnnEquipmentService
    {
        private GeneralDataAccess _dataAccess;

        public EnnEquipmentService() {
            _dataAccess = new GeneralDataAccess();
        }

        public int CreateEquipment(string name, string desc)
        {
            EnnEquipment equip = new EnnEquipment { EquipName = name, EquipDescription = desc };
            IOPort inputPort1 = new IOPort ();
            inputPort1.PortName = "input_port_1";
            inputPort1.Type = IOPortType.InputTypePort;
            inputPort1.BelongsToEquipment = equip;

            IOPort inputPort2 = new IOPort();
            inputPort2.PortName = "input_port_2";
            inputPort2.Type = IOPortType.InputTypePort;
            inputPort2.BelongsToEquipment = equip;


            IOPort outputPort1 = new IOPort();
            outputPort1.PortName = "output_port_1";
            outputPort1.Type = IOPortType.OutputTypePort;
            outputPort1.BelongsToEquipment = equip;

            IOPort outputPort2 = new IOPort();
            outputPort2.PortName = "output_port_2";
            outputPort2.Type = IOPortType.OutputTypePort;
            outputPort2.BelongsToEquipment = equip;

            equip.InputPort1 = inputPort1;
            equip.InputPort2 = inputPort2;

            equip.OutputPort1 = outputPort1;
            equip.OutputPort2 = outputPort2;

            this._dataAccess.Add<EnnEquipment>(equip);
            return equip.Id;
        }


        public void RemoveEquipment(int idToDelete)
        {
            EnnEquipment equip = this._dataAccess.GetById<EnnEquipment>(idToDelete);
            if (equip != null)
            {
                this._dataAccess.Remove<EnnEquipment>(equip);
            }
        }

        public void AddConnectionToEquipments(int sourcePortId, int sinkPortId) {

            IOPort sourcePort = this._dataAccess.GetById<IOPort>(sourcePortId);
            IOPort sinkPort = this._dataAccess.GetById<IOPort>(sinkPortId);

            IOConnection conn = new IOConnection { SourcePort = sourcePort, SinkPort = sinkPort };
            sourcePort.RelevantIOConnection = conn;
            sinkPort.RelevantIOConnection = conn;

            this._dataAccess.Update<IOPort>(sourcePort);
            this._dataAccess.Update<IOPort>(sinkPort);
        }

        public void removeConnectionFromEquipments(int sourcePortId) {
            IOPort sourcePort = this._dataAccess.GetById<IOPort>(sourcePortId);
            IOConnection conn = sourcePort.RelevantIOConnection;
            this._dataAccess.Remove<IOConnection>(conn);
        }
    }
}
