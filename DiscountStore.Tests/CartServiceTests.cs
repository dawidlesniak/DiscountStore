using Xunit;

namespace DiscountStore.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public void GetTotal_WithoutAnyItems()
        {
            //Arrange
            var service = new CartService(new DiscountService());
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void GetTotalAmount_AfterAddingItemWithoutDiscount()
        {
            //Arrange
            var service = new CartService(new DiscountService());
            var vase = new Item() { Price = 1.2m, SKU = "Vase" };
            service.Add(vase);
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(1.2m, result);
        }
        
        [Fact]
        public void GetTotalAmount_AfterAddingAndRemovingItemWithoutDiscount()
        {
            //Arrange
            var service = new CartService(new DiscountService());
            var vase = new Item() { Price = 1.2m, SKU = "Vase" };
            service.Add(vase);
            service.Remove(vase);
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(0, result);
        }
        
        [Fact]
        public void GetTotalAmount_AfterAddingTwoItemsWithDiscount()
        {
            //Arrange
            var discountService = new DiscountService();
            discountService.AddDiscount(new() {DiscountName = "2 for 1.5 Euro", DiscountAmount = 0.5m, ItemName = "Big mug", NumberOfItems = 2});
            var service = new CartService(discountService);
                
            var bigMug = new Item() { Price = 1, SKU = "Big mug" };
            service.Add(bigMug);
            service.Add(bigMug);
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(1.5m, result);
        }
        
        [Fact]
        public void GetTotalAmount_AfterAddingFiveItemsWithDiscount()
        {
            //Arrange
            var discountService = new DiscountService();
            discountService.AddDiscount(new() {DiscountName = "2 for 1.5 Euro", DiscountAmount = 0.5m, ItemName = "Big mug", NumberOfItems = 2});
            var service = new CartService(discountService);
                
            var bigMug = new Item() { Price = 1, SKU = "Big mug" };
            service.Add(bigMug);
            service.Add(bigMug);
            service.Add(bigMug);
            service.Add(bigMug);
            service.Add(bigMug);
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(4, result);
        }
        
        [Fact]
        public void GetTotalAmount_AfterAddingTwoItemsAndRemovingOneWithDiscount()
        {
            //Arrange
            var discountService = new DiscountService();
            discountService.AddDiscount(new() {DiscountName = "2 for 1.5 Euro", DiscountAmount = 0.5m, ItemName = "Big mug", NumberOfItems = 2});
            var service = new CartService(discountService);
            
            var bigMug = new Item() { Price = 1, SKU = "Big mug" };
            service.Add(bigMug);
            service.Add(bigMug);
            service.Remove(bigMug);
            
            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(1, result);
        }
        
        [Fact]
        public void GetTotalAmount_AddFewItemsThatApplyForADiscount()
        {
            //Arrange
            var discountService = new DiscountService();
            discountService.AddDiscount(new() {DiscountName = "2 for 1.5 Euro", DiscountAmount = 0.5m, ItemName = "Big mug", NumberOfItems = 2});
            discountService.AddDiscount(new() {DiscountName = "3 for 0.9 Euro", DiscountAmount = 0.45m, ItemName = "Napkins pack", NumberOfItems = 3});
            var service = new CartService(discountService);
            
            var bigMug = new Item() { Price = 1, SKU = "Big mug" };
            var napkins = new Item() { Price = 0.45m, SKU = "Napkins pack" };
            service.Add(napkins);
            service.Add(bigMug);
            service.Add(napkins);
            service.Add(bigMug);
            service.Add(napkins);

            //Act
            var result = service.GetTotal();
            
            //Assert
            Assert.Equal(2.4m, result);
        }
    }
}