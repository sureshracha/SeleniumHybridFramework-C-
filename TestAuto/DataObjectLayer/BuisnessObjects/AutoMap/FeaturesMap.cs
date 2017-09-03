using DataObjectLayer.BuisnessObjects.Entitites;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
   public class FeaturesMap: ClassMap<Features>
    {
        public FeaturesMap()
        {
            Schema("dbo");
            Id(x => x.Featureid).GeneratedBy.Identity();
            Map(x => x.Feature);
            Map(x => x.Description);
        }

    }
}
