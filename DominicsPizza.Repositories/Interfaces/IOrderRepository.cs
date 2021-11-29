using DominicsPizza.Entities;
using System.Collections.Generic;

namespace DominicsPizza.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetUserOrders(int UserId);
    }
}
