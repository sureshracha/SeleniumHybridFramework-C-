using DataObjectLayer.BuisnessObjects.Entites;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
   public class AutomationRunsMap:ClassMap<AutomationRuns>
    {
        public AutomationRunsMap()
        {
            Schema("dbo");
            Id(x => x.runid).GeneratedBy.Identity();
            Map(x => x.regionid);
            Map(x => x.RunDateTime);
            Map(x => x.sso);
        }
    }
}
