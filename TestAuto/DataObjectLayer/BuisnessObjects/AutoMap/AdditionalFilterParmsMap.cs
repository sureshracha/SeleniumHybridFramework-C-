using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Entites;
using DataObjectLayer.BuisnessObjects.Entites;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
   public class AdditionalFilterParmsMap:ClassMap<AdditionalFilterParms>
    {
        public AdditionalFilterParmsMap()
        {
            Schema("dbo");
            Id(x => x.AdditionalFilterParmsId).GeneratedBy.Identity();
            Map(x => x.FieldId);
            Map(x => x.Field);
            Map(x => x.FieldComparison);
            Map(x => x.Fieldtype);
            Map(x => x.FieldValue);
        }
    }
}
