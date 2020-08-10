using System.Collections.Generic;
using FluentValidator;

namespace Dapper.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if(product.QuantityOnHand < quantity){
                //Notifications.Add("Quantidade", "Produto fora do estoque");
                //throw new System.Exception("Quantidade inválida");
                AddNotification("Quantity", "Produto fora de estoque");
            }
        }

        public Product Product { get;private set; }

        public decimal Quantity { get;private set; }

        public decimal Price { get; private set; }
        //public IDictionary<string,string> Notifications  { get; set; }
    }
}