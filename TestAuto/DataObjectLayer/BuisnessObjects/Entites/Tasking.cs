using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class Tasking : Entity
    {
        public virtual int taskingId { get; set; }
        public virtual string taskgroupName { get; set; }
        public virtual string taskName { get; set; }
        public virtual string taskDescription { get; set; }
        public virtual string taskItem { get; set; }
        public virtual string taskOrgLevel { get; set; }
        public virtual bool taskStatus { get; set; }
        public virtual int duration { get; set; }
        public virtual bool notification { get; set; }
        public virtual bool escalation { get; set; }
        public virtual string user_or_group { get; set; }
        public virtual int user_or_groupid { get; set; }
        public virtual string onreturn { get; set; }
        public virtual string note { get; set; }

        public virtual IList<Tasking> taskList { get; set; }
    }
}
