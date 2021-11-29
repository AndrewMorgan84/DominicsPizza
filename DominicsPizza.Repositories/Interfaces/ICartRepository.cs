using DominicsPizza.Entities;
using System;

namespace DominicsPizza.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid cartId);

        int DeleteItem(Guid cartId, int itemId);

        int UpdateQuantity(Guid cartId, int itemId, int Quantity);

        int UpdateCart(Guid cartId, int userId);
    }
}
