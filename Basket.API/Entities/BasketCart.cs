using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class BasketCart

    {
        public BasketCart()
        {

        }
        public BasketCart(string userName)
        {
            UserName= userName ;
        }
        //calc totalprice
        public decimal Totalprice {
            
            get{
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += (item.Price * item.Quality);
                }
                return totalPrice;            
            }
        
        
        }
        public string  UserName { get; set; }
        public List<BasketCartItem> Items { get; set; } = new List<BasketCartItem>();
      

    }
}
