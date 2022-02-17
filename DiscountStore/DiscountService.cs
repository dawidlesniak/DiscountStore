using System.Collections.Generic;
using System.Linq;

namespace DiscountStore
{
    public class DiscountService : IDiscountService
    {
        private readonly List<Discount> _discounts = new();

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

        public decimal Apply(List<Item> items)
        {
            decimal result = 0;
            foreach (var discount in _discounts)
            {
                var itemCount = items.Count(x => x.SKU == discount.ItemName);
                var discountsToApply = itemCount / discount.NumberOfItems;
                result -= discountsToApply * discount.DiscountAmount;
            }
            return result;
        }
    }
}