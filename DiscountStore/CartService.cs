using System.Collections.Generic;
using System.Linq;

namespace DiscountStore
{
    public class CartService : ICartService
    {
        private readonly IDiscountService _discountService;
        private readonly List<Item> _cart = new();

        public CartService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public void Add(Item item)
        {
            _cart.Add(item);
        }

        public void Remove(Item item)
        {
            _cart.Remove(item);
        }

        public decimal GetTotal()
        {
            var discount = _discountService.Apply(_cart);
            return _cart.Sum(x => x.Price) + discount;
        }
    }
}