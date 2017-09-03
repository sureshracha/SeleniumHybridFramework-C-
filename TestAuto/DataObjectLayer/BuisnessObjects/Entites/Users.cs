using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer.BuisnessObjects.Entites
{
    public class Users:Entity
    {
        public virtual int Userid { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string ClientId { get; set; }
        public virtual string Firstname { get; set; }
        public virtual string Lastname { get; set; }

        public virtual int Adjustmentlimit { get; set; }
        public virtual string Escalationcontact { get; set; }
        public virtual string Taskescalation { get; set; }
        public virtual int Regionid{ get; set; }
        public virtual bool Sso { get; set; }


        public virtual int FeatureId { get; set; }
        public virtual IList<Users> UserList { get; set; }
        public virtual string FormattedName
        {
            get
            {
                return Lastname + ", " + Firstname;
            }
        }
        public virtual string FullName
        {
            get
            {
                return Firstname + " " + Lastname;
            }
        }
    }
}
