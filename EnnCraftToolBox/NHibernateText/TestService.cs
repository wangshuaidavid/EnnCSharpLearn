﻿using NUnit.Framework;
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
        

        [Test]
        public void InitTest()
        {
           
        }
        

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

        [Test]
        public void InitTest_NEW_NEW()
        {
            HeatPumpRepository er = new HeatPumpRepository();
            IOConnectionRepository cr = new IOConnectionRepository();

            ISession session = FluentSessionFactory.GetCurrentFactory().OpenSession();
            er.Session = session;
            cr.Session = session;

            HeatPump e1 = er.CreateEquip() as HeatPump;
            HeatPump e2 = er.CreateEquip() as HeatPump;
            e2.EquipName = "modified Equip name";

            e2.HeatRatio = 100000;

            er.Update(e2);

            int conID = cr.AddConnection(e1.CwQIn.Id, e2.CoolingQOut.Id);

            HeatPump h = er.GetById(e2.Id) as HeatPump;
            Console.WriteLine(h);
            Console.WriteLine(h.HeatRatio);
            // cr.AddConnection(e1.CwQIn.Id, e2.CoolingQOut.Id);

            //cr.RemoveConnection(conID);
            //er.Remove(e1.Id);

        }
    }
}
