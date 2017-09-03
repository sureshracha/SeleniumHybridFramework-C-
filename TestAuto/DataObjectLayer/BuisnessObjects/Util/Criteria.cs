using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Repository
{
    /// <summary>
    /// Class for building Criteria to pass to query on a object
    /// </summary>
   public class Criteria
    {
        public string field { get; set; }
        public Operators Operator { get; set; }
        public object Value { get; set; }

        public enum Operators
        {
            Equal =1,
            NotEqual=2,
            GreaterThan=3,
            GreaterThanEqual=4,
            LessThan=5,
            LessThanEqual=6,
            Like=7,
            NotLike=8


        }
    }

}
