using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System;

namespace DataObjectLayer.BuisnessObjects.Config
{
    public static class FluentConfig
    {
        


        public static ISessionFactory CreateSessionFactory()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            return Fluently.Configure(cfg).Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(c => c.FromAppSetting("AutoConnString")).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataObjectLayer.BuisnessObjects.AutoMap.UsersMap>())
                .BuildSessionFactory();
        }

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    try
                    {
                        var configuration = new Configuration();
                        Fluently.Configure(configuration).Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(c => c.FromAppSetting("AutoConnString")).DoNot.ShowSql())//.ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataObjectLayer.BuisnessObjects.AutoMap.UsersMap>())
                        .BuildSessionFactory();

                        //configuration.Configure();
                        //configuration.AddAssembly("NHibernateTest.Types");

                        _sessionFactory = configuration.BuildSessionFactory();
                    }
                    catch (Exception ex)
                    {

                    }
                }
                return _sessionFactory;

                //return _sessionFactory;
                //var cfg = new NHibernate.Cfg.Configuration();
                //return Fluently.Configure(cfg).Database(MsSqlConfiguration.MsSql2012
                //    .ConnectionString(c => c.FromAppSetting("AutoConnString")).DoNot.ShowSql())//.ShowSql())
                //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DataObjectLayer.BuisnessObjects.AutoMap.UsersMap>())
                //    .BuildSessionFactory();
            }
        }

        public static ISession OpenSession()
        {
            if(_sessionFactory == null)
            {
                CreateSessionFactory();
            }
            return SessionFactory.OpenSession();
        }


    }
}
