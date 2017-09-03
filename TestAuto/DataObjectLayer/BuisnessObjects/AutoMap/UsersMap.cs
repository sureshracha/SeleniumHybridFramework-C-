
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Entites;

namespace DataObjectLayer.BuisnessObjects.AutoMap
{
   public class UsersMap:ClassMap<Users>
    {
        public  UsersMap()
        {
            Schema("dbo");
            Id(x => x.Userid).GeneratedBy.Identity();
            Map(x => x.Username);
            Map(x => x.Password);
            Map(x => x.ClientId);
            Map(x => x.Firstname);
            Map(x => x.Lastname);
            Map(x => x.Adjustmentlimit);
            Map(x => x.Escalationcontact);
            Map(x => x.Taskescalation);
            Map(x => x.Regionid);
            Map(x => x.Sso);
            Map(x => x.FeatureId);
            

        }
    }
}
