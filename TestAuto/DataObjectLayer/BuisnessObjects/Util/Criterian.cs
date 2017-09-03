using DataObjectLayer.BuisnessObjects.Repository;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Util
{
    public class Criterian
    {
        public void PropertyToCriteria(List<Criteria> scc, NHibernate.ICriteria sql)
        {
            foreach (var item in scc)
            {
                switch (item.Operator)
                {
                    case Criteria.Operators.Equal:
                        sql.Add(Restrictions.Eq(item.field, item.Value));
                      break;
                    case Criteria.Operators.NotEqual:
                        sql.Add(!Restrictions.Eq(item.field, item.Value));
                        break;
                    case Criteria.Operators.GreaterThan:
                        sql.Add(Restrictions.Gt(item.field, item.Value));
                        break;
                    case Criteria.Operators.GreaterThanEqual:
                        sql.Add(Restrictions.Ge(item.field, item.Value));
                        break;
                    case Criteria.Operators.LessThan:
                        sql.Add(Restrictions.Lt(item.field, item.Value));
                        break;
                    case Criteria.Operators.LessThanEqual:
                        sql.Add(Restrictions.Le(item.field, item.Value));
                        break;
                    case Criteria.Operators.Like:
                        sql.Add(Restrictions.InsensitiveLike(item.field, item.Value.ToString(),MatchMode.Anywhere));
                        break;
                    case Criteria.Operators.NotLike:
                        sql.Add(Restrictions.InsensitiveLike(item.field, item.Value.ToString(), MatchMode.Anywhere));
                        break;
                }

            }
        }
        
    }
}
