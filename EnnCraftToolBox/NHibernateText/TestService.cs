using NUnit.Framework;
using Servers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository;
using Domain.Entities;
using NHibernate;

namespace Domain
{
    [TestFixture]
    class TestService
    {
        /*

        [Test]
        public void InitTest()
        {
            EnnEquipmentService equipService = new EnnEquipmentService();
            int equipId1 = equipService.CreateEquipment("新加入的设备3", "description1");
            int equipId2 = equipService.CreateEquipment("新加入的设备4", "description2");

            GeneralDataAccess gda = new GeneralDataAccess();
            EnnEquipment e1 = gda.GetById<EnnEquipment>(equipId1);
            EnnEquipment e2 = gda.GetById<EnnEquipment>(equipId2);

            //Assert.AreEqual("de", e1.EquipName);

            equipService.AddConnectionToEquipments(e2.OutputPort1.Id, e1.InputPort2.Id);

            //Assert.AreSame(e2.OutputPort1.RelevantIOConnection, e1.InputPort2.RelevantIOConnection);
            //Assert.IsNull(e2.OutputPort2.RelevantIOConnection);

            //equipService.removeConnectionFromEquipments(e2.OutputPort1.Id);
            equipService.RemoveEquipment(equipId1);
        }
        */

        [SetUp]
        public void setUp() 
        {
            
        }

        [Test]
        public void InitTest_NEW()
        {
            EnnEquipmentRepository er = new EnnEquipmentRepository();
            IOConnectionRepository cr = new IOConnectionRepository();

            ISession session = FluentSessionFactory.GetCurrentFactory().OpenSession();
            er.Session = session;
            cr.Session = session;
            
            EnnEquipment e1 = er.CreateEquip() as EnnEquipment;
            EnnEquipment e2 = er.CreateEquip() as EnnEquipment;
            e2.EquipName = "modified Equip name";
            er.Update(e2);

           int conID = cr.AddConnection(e1.OutputPort1.Id, e2.InputPort2.Id);

            cr.AddConnection(e1.OutputPort2.Id, e2.InputPort1.Id);

            cr.RemoveConnection(conID);
            //er.Remove(e1.Id);

        }
    }
}
