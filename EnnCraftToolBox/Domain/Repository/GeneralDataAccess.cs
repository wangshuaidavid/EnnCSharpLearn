using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GeneralDataAccess
    {

        private ISession openSession()
        {
            return FluentSessionFactory.GetCurrentFactory().OpenSession();
        }

        public void Add<T>(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }

        }

        public void AddMutiple<T>(IEnumerable<T> objs)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (T obj in objs)
                {
                    session.Save(obj);
                }
            }
        }


        public void Update<T>(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(obj);
                transaction.Commit();
            }
        }

        public void Remove<T>(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {

                session.Delete(obj);
                transaction.Commit();
            }
        }

        public void RemoveMutiple<T>(IEnumerable<T> objs)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (T obj in objs)
                {
                    session.Delete(obj);
                    transaction.Commit();
                }
            }
        }


        public T GetById<T>(int equipId)
        {
            T objFromDb = default(T);
            using (ISession session = this.openSession())
            {
                objFromDb = session.Get<T>(equipId);
            }
            return objFromDb;
        }
    }
}
