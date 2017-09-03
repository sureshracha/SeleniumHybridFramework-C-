using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entitites
{
    public class Features:Entity
    {
        public virtual int Featureid { get; set; }
        public virtual string Feature { get; set; }
        public virtual string Description { get; set; }
    }
}
