using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class DataAccess<T>
    {
        private ISession openSession()
        {
            return FluentSessionFactory.GetCurrentFactory().OpenSession();
        }

        public void Add(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }

        }

        public void AddMutiple(IEnumerable<T> objs)
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


        public void Update(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(obj);
                transaction.Commit();
            }
        }

        public void Remove(T obj)
        {
            using (ISession session = this.openSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(obj);
                transaction.Commit();
            }
        }

        public void RemoveMutiple(IEnumerable<T> objs)
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


        public T GetById(int equipId)
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

