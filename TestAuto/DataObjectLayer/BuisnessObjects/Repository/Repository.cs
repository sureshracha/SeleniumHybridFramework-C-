using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using DataObjectLayer.BuisnessObjects.Config;
using NHibernate.Criterion;

namespace DataObjectLayer.BuisnessObjects.Repository
{
    public class RepositoryBase : IRepository, IDisposable
    {
        protected ISession _session = null;
        protected ITransaction _transaction = null;

        public RepositoryBase()
        {
            _session = FluentConfig.OpenSession();
        }

        public RepositoryBase(ISession session)
        {
            _session = session;
        }

        #region Transaction and Session Management Methods

        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }

        public void CommitTransaction()
        {
            // _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
            _transaction.Commit();

            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            // _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
            _transaction.Rollback();

            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }

        #endregion

        #region IRepository Members

        public virtual void Save(object obj)
        {
            _session.SaveOrUpdate(obj);
        }

        public virtual void Delete(object obj)
        {
            _session.Delete(obj);
        }

        public virtual object GetById(Type objType, object objId)
        {
            return _session.Load(objType, objId);
        }




        public virtual IQueryable<TEntity> ToList<TEntity>()
        {
            return (from entity in _session.Query<TEntity>() select entity);//.Linq<TEntity>() select entity);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                CommitTransaction();
            }

            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }

        #endregion
    }

}
