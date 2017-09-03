using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using NHibernate;

namespace DataObjectLayer.BuisnessObjects.Entites
{
   public class WorkListFilterFields:Entity
    {
        public virtual int FieldId { get; set; }

        public virtual string WorklistName { get; set; }
        public virtual string Field { get; set; }
        public virtual string FieldComparison { get; set; }
        public virtual string Fieldtype { get; set; }
        public virtual string FieldValue { get; set; }
        public virtual bool FieldRequired { get; set; }
        public virtual bool FieldIsLocked { get; set; }
        public virtual string FieldPrimSort { get; set; }
        public virtual bool FieldPrimSortAsc { get; set; }
        public virtual string FieldSecSort { get; set; }
        public virtual bool FieldSecSortAsc { get; set; }
        public virtual bool FieldIsPrimary { get; set; }

    }
}
