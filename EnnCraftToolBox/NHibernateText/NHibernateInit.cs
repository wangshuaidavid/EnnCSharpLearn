using NHibernate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
    [TestFixture]
    public class NHibernateInit
    {
        [Test]
        public void InitTest()
        {
            ISession session = FluentSessionFactory.GetCurrentFactory().OpenSession();

            
        }
    }
     
}
