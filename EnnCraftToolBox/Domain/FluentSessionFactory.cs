using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class FluentSessionFactory
    {

        private const string DbFile = "EnnTool_SQLiteDatabase.db";

        public static ISessionFactory GetCurrentFactory()
        {
            if (sessionFactory == null)
            {
                sessionFactory = CreateSQLiteSessionFactory();
            }

            return sessionFactory;
        }

        private static ISessionFactory CreateSessionFactory()
        {

            return Fluently.Configure()
                              .Database(MySQLConfiguration.Standard
                                                          .ConnectionString(s => s.Server("localhost")
                                                                                  .Database("toolboxdatabase")
                                                                                  .Username("root")
                                                                                  .Password("root"))
                                                          .ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Domain.Entities.IOPortType>())
                                                          .BuildSessionFactory();

            /*
            return Fluently.Configure()
                              .Database(MySQLConfiguration.Standard
                                                          .ConnectionString(s => s.Server("localhost")
                                                                                  .Database("toolboxdatabase")
                                                                                  .Username("root")
                                                                                  .Password("root"))
                                                          .ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<Domain.Entities.IOPortType>().ExportTo(@"E:\0000enn"))
                                                          .ExposeConfiguration(BuildSchema).BuildSessionFactory();
            */
        }


        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
           new SchemaExport(config).Create(false, true);
        }


        private static ISessionFactory CreateSQLiteSessionFactory()
        {

            return Fluently.Configure()
                              .Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
                              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<FluentSessionFactory>().ExportTo("D:/0000"))
                              .ExposeConfiguration(BuildSchemaForSQLite)
                              .BuildSessionFactory();

        }


        private static void BuildSchemaForSQLite(Configuration config)
        {
            // delete the existing db on each run
            if (File.Exists(DbFile))
            {
                File.Delete(DbFile);
            }

            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config).Create(false, true);
        }

        private static ISessionFactory sessionFactory
        {
            get;
            set;
        }
    }
}
