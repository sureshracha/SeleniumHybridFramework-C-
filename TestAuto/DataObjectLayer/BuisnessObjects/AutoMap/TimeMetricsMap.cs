using DataObjectLayer.BuisnessObjects.Entitites;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
    public class TimeMetricsMap:ClassMap<TimeMetrics>
    {
        public TimeMetricsMap()
        {
            Schema("dbo");
            Id(x => x.timemetricsid).GeneratedBy.Identity();
            Map(x => x.DateTime);
            //Map(x => x.StartTime);
            //Map(x => x.EndTime);
            Map(x => x.TimeTaken);
            Map(x => x.FeatureModule);
            Map(x => x.Environment);
        }
    }
}
