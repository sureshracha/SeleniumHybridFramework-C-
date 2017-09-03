using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Entites;

namespace DataObjectLayer.BuisnessObjects
{
    public class TaskingMap:ClassMap<Tasking>
    {
        public TaskingMap()
        {
            Schema("dbo");
            Id(x => x.taskingId).GeneratedBy.Identity();
            Map(x => x.taskgroupName);
            Map(x => x.taskName);
            Map(x => x.taskDescription);
            Map(x => x.taskItem);
            Map(x => x.taskOrgLevel);
            Map(x => x.taskStatus);
            Map(x => x.duration);
            Map(x => x.notification);
            Map(x => x.escalation);
            Map(x => x.user_or_group);
            Map(x => x.user_or_groupid);
            Map(x => x.onreturn);
            Map(x => x.note);
        }
    }
}
