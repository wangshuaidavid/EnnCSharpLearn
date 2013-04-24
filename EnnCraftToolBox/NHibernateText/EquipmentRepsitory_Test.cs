using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repository;

namespace Domain
{
    /*
    [TestFixture]
    public class EquipmentRepsitory_Test
    {
        private ISessionFactory _sessionFactory;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _sessionFactory = FluentSessionFactory.GetCurrentFactory();
        }

        [Test]
        public void Can_add_new_product()
        {
            EnnEquipment e = new EnnEquipment {EquipName = "热泵", EquipDescription = "good" };
            IEquipmentRepository repository = new EnnEquipmentRepository();
            repository.Add(e);

            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<EnnEquipment>(e.Id);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(e, fromDb);
                Assert.AreEqual(e.EquipName, fromDb.EquipName);
            }
        }

        [Test]
        public void Can_remove_product()
        {
            IEquipmentRepository repository = new EnnEquipmentRepository();
            repository.Remove(repository.GetById(1));
        }
    }*/
}
