using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Data;
using DataObjectLayer.BuisnessObjects.Entites;
using DataObjectLayer.BuisnessObjects.Entitites;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class EFRAutoResults : Entity
    {
        public virtual int ResultsId { get; set; }
        public virtual string MachineName { get; set; }
        public virtual int EnvId { get; set; }

        public virtual DateTime ExecutionTime { get; set; }
        public virtual string PassORFail {get;set;}
        public virtual int FeatureId { get; set; }
        public virtual string Results { get; set; }

        public virtual string Release { get; set; }

    }
}
