using System.Collections.Generic;

namespace DiscountStore
{
    public interface IDiscountService
    {
        decimal Apply(List<Item> items);
    }
}