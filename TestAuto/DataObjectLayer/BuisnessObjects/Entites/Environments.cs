using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class Environments : Entity
    {
        public virtual int envid { get; set; }
        public virtual int regionId { get; set; }
        public virtual string region { get; set; }
        public virtual string url { get; set; }
        public virtual bool sso { get; set; }
        public virtual string connectionString { get; set; }
        public virtual string client { get; set; }

        public virtual IList<Environments> environmentList { get; set; }
    }
}
