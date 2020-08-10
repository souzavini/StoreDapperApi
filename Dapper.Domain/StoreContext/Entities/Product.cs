using FluentValidator;

namespace Dapper.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public Product(string title, string image, decimal price, decimal quantityOnHand)
        {
            this.Title = title;
            this.Image = image;
            this.Price = price;
            this.QuantityOnHand = quantityOnHand;

        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public override string ToString()
        {
            return Title;
        }

    }
}