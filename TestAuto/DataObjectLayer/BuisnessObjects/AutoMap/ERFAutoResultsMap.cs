using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DataObjectLayer.BuisnessObjects.Entites;


namespace DataObjectLayer.BuisnessObjects.AutoMap
{
    public class ERFAutoResultsMap:ClassMap<EFRAutoResults>
    {
        public ERFAutoResultsMap()
        {
            Schema("dbo");
            Id(x => x.ResultsId).GeneratedBy.Identity();
            Map(x => x.MachineName);
            Map(x => x.EnvId);
            Map(x => x.ExecutionTime);
            Map(x => x.PassORFail);
            Map(x => x.FeatureId);
            Map(x => x.Results).CustomType("StringClob");
            Map(x => x.Release);
        }
    }
}
