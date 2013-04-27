using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public abstract class AbstractRepository : IDisposable
    {

        protected ISession session;

        public ISession Session
        {
            get { return session; }
            set { session = value; }
        }

        public void Dispose()
        {
            Console.WriteLine("---------- Session will close ----------");
            session.Flush();
            session.Close();
            session.Dispose();
        }

    }
}
