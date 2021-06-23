using DevExtreme.AspNet.Data.Aggregation;
using DevExtreme.AspNet.Data.Helpers;
using InventoryManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Devextreme.Aggreagators
{
    public class TotalAmountAggregator<T> : Aggregator<T>
    {
        decimal _total = 0;

        public TotalAmountAggregator(IAccessor<T> accessor)
            : base(accessor)
        {
        }

        public override void Step(T container, string selector)
        {
            var Amount = Convert.ToDecimal(Accessor.Read(container, "Amount"));
            var TransactionType = Convert.ToInt16(Accessor.Read(container, "TransactionType"));
            switch (TransactionType)
            {
                case (int)TransactionTypes.Collection:
                    _total -= Amount;
                    break;
                case (int)TransactionTypes.Payment:
                    _total += Amount;
                    break;
                case (int)TransactionTypes.Debiting:
                    _total += Amount;
                    break;
                case (int)TransactionTypes.Crediting:
                    _total -= Amount;
                    break;
                case (int)TransactionTypes.Virman:
                    _total += Amount;
                    break;
                default:
                    _total += 0;
                    break;
            }
        }

        public override object Finish()
        {
            return _total;
        }
    }
}
