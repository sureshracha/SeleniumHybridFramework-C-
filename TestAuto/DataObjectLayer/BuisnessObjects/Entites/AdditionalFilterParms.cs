using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Data;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class AdditionalFilterParms : Entity
    {

        public virtual int AdditionalFilterParmsId {get;set;}
        public virtual int FieldId { get; set; }
        public virtual string Field { get; set; }
        public virtual string FieldComparison { get; set; }
        public virtual string Fieldtype { get; set; }
        public virtual string FieldValue { get; set; }

    }
}
