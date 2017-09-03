using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectLayer.BuisnessObjects.Entites;
namespace DataObjectLayer.BuisnessObjects
{
    public class AdjustRefundsMap:ClassMap<AdjustRefunds>
    {
        public AdjustRefundsMap()
        {
            Schema("dbo");
            Id(x => x.adjustRefundid).GeneratedBy.Identity();
            Map(x => x.adjustRefund);
            Map(x => x.healthPlan);
            Map(x => x.transactiondate);
            Map(x => x.tranServiceCode);
            Map(x => x.note);
            Map(x => x.refundtype);
            Map(x => x.refundPayee);
            Map(x => x.refundAddres);
            Map(x => x.refundCity);
            Map(x => x.refundState);
            Map(x => x.refundZip);
        }
    }
}
