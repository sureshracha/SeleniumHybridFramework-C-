using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using FluentNHibernate.Data;

namespace DataObjectLayer.BuisnessObjects.Entites
{
   public class AdjustRefunds : Entity
    {
        public virtual int adjustRefundid { get; set; }
        public virtual string adjustRefund { get; set; }
        public virtual string healthPlan { get; set; }
        public virtual DateTime transactiondate { get; set; }
        public virtual int transactionAmount { get; set; }
        public virtual string tranServiceCode { get; set; }
        public virtual string note { get; set; }

        public virtual string refundtype { get; set; }
        public virtual string refundPayee { get; set; }
        public virtual string refundAddres { get; set; }
        public virtual string refundCity { get; set; }
        public virtual string refundState { get; set; }
        public virtual string refundZip { get; set; }
        public virtual IList<AdjustRefunds> adjustments { get; set; }
    }
}
