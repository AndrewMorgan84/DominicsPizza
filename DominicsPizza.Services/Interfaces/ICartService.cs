using DominicsPizza.Entities;
using DominicsPizza.Repositories.Models;
using System;

namespace DominicsPizza.Services.Interfaces
{
    interface ICartService
    {
        int GetCartCount(Guid cartId);

        CartModel GetCartDetails(Guid cartId);

        Cart AddItem(int userId, Guid cartId, int itemId, decimal unitPrice, int quantity);

        int DeleteItem(Guid cartId, int itemId);

        int UpdateQuantity(Guid cartId, int id, int quantity);

        int UpdateCart(Guid cartId, int userId);
    }
}
