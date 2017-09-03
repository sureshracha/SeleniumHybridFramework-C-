using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entitites
{
    public class TimeMetrics:Entity
    {
        public virtual int timemetricsid { get; set; }
        public virtual DateTime DateTime { get; set; }
        //public virtual string StartTime { get; set; }
        //public virtual string EndTime { get; set; }
        public virtual double TimeTaken { get; set; }
        public virtual string FeatureModule { get; set; }

        public virtual string Environment { get; set; }
    }
}
