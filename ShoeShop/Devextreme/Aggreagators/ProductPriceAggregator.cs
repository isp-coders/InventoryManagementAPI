using DevExtreme.AspNet.Data.Aggregation;
using DevExtreme.AspNet.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Devextreme.Aggreagators
{
    public class ProductPriceAggregator<T> : Aggregator<T>
    {
        decimal _total = 0;

        public ProductPriceAggregator(IAccessor<T> accessor)
            : base(accessor)
        {
        }

        public override void Step(T container, string selector)
        {
            var Price = Convert.ToDecimal(Accessor.Read(container, "Price"));
            var Count = Convert.ToDecimal(Accessor.Read(container, "Count"));
            _total += Price * Count;
        }

        public override object Finish()
        {
            return _total;
        }
    }
}
