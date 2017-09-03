using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DataObjectLayer.BuisnessObjects.Entites;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
   public class WorkListFilterFieldMap: ClassMap<WorkListFilterFields>
    {
        public WorkListFilterFieldMap()
        {
            Schema("dbo");
            Id(x => x.FieldId).GeneratedBy.Identity();
            Map(x => x.WorklistName);
            Map(x => x.Field);
            Map(x => x.FieldComparison);
            Map(x => x.FieldRequired);
            Map(x => x.Fieldtype);
            Map(x => x.FieldValue);
            Map(x => x.FieldPrimSort);
            Map(x => x.FieldPrimSortAsc);
            Map(x => x.FieldSecSort);
            Map(x => x.FieldSecSortAsc);
            Map(x => x.FieldIsLocked);
            Map(x => x.FieldIsPrimary);
        }
    }
}
