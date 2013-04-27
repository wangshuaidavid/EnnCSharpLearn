using Domain.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public abstract class AbstractEquipmentRepository : IEquipmentRepository
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

        public abstract EnnEquipment CreateEquip();

        public abstract void Update(Entities.EnnEquipment equip);

        public abstract void Remove(int equipId);

        public abstract EnnEquipment GetById(int equipId);

    }
}
