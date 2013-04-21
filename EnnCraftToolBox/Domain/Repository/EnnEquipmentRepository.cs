using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EnnEquipmentRepository : IEquipmentRepository
    {

        private ISession openSession()
        {
            return FluentSessionFactory.GetCurrentFactory().OpenSession();
        }

        public void Add(EnnEquipment equip)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(equip);
                transaction.Commit();
            }

        }


        public void Update(Entities.EnnEquipment equip)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(equip);
                transaction.Commit();
            }
        }

        public void Remove(Entities.EnnEquipment equip)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(equip);
                transaction.Commit();
            }
        }


        public Entities.EnnEquipment GetById(int equipId)
        {
            EnnEquipment fromDb = null;
            using (ISession session = this.openSession())
            {
                fromDb = session.Get<EnnEquipment>(equipId);
            }
            return fromDb;
        }
    }
}
