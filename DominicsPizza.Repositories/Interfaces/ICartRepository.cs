using DominicsPizza.Entities;
using System;

namespace DominicsPizza.Repositories.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Cart GetCart(Guid CartId);
    }
}
