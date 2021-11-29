using DominicsPizza.Entities;
using DominicsPizza.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DominicsPizza.Repositories.Implementation
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private AppDbContext appContext => _dbContext as AppDbContext;

        public CartRepository(DbContext dbContext) : base(dbContext)
        {
                
        }

        public Cart GetCart(Guid CartId)
        {
            return appContext.Carts
                .Include("Items")
                .Where(c => c.Id == CartId && c.IsActive)
                .FirstOrDefault();
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            var item = appContext.CartItems
                .Where(ci => ci.CartId == cartId && ci.Id == itemId)
                .FirstOrDefault();

            if(item != null)
            {
                appContext.CartItems.Remove(item);
                return appContext.SaveChanges();
            }
            else
            {
                return 0;
            }
        }

        public int UpdateQuantity(Guid cartId, int itemId, int Quantity)
        {
            bool flag = false;
            var cart = GetCart(cartId);
            if(cart != null)
            {
                for(int i = 0; i < cart.Items.Count; i++)
                {
                    if(cart.Items[i].Id == itemId)
                    {
                        flag = true;

                        if (Quantity < 0 && cart.Items[i].Quantity > 1)
                            cart.Items[i].Quantity += (Quantity);
                        else if (Quantity > 0)
                            cart.Items[i].Quantity += (Quantity);
                        break;
                    }
                }

                if (flag)
                    return appContext.SaveChanges();
            }
            return 0;
        }

            

        public int UpdateCart(Guid cartId, int userId)
        {
            Cart cart = GetCart(cartId);
            cart.UserId = userId;
            return appContext.SaveChanges();
        }
    }
}
