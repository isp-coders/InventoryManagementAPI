using DevExtreme.AspNet.Data.Aggregation;
using DevExtreme.AspNet.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Devextreme.Aggreagators
{
    public class ProductSellingPriceAggreagtor<T> : Aggregator<T>
    {
        decimal _total = 0;

        public ProductSellingPriceAggreagtor(IAccessor<T> accessor)
            : base(accessor)
        {
        }

        public override void Step(T container, string selector)
        {
            var SellingPrice = Convert.ToDecimal(Accessor.Read(container, "SellingPrice"));
            var Count = Convert.ToDecimal(Accessor.Read(container, "Count"));
            _total += SellingPrice * Count;
        }

        public override object Finish()
        {
            return _total;
        }
    }
}
