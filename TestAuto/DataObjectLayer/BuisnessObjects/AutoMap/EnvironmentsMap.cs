using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Entites;
namespace DataObjectLayer.BuisnessObjects
{
   public class EnvironmentsMap:ClassMap<Environments>
    {
        public EnvironmentsMap()
        {
            Schema("dbo");
            Id(x => x.envid).GeneratedBy.Identity();
            Map(x => x.regionId);
            Map(x => x.region);
            Map(x => x.url);
            Map(x => x.sso);
            Map(x => x.connectionString);
            Map(x => x.client);
        }
    }
}
