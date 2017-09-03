using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class AutomationRuns:Entity
    {
        public virtual int runid { get; set; }
        public virtual int regionid { get; set; }
        public virtual DateTime RunDateTime { get; set; }
        public virtual Boolean sso { get; set; }

    }
}
