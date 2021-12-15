using DominicsPizza.Entities;
using DominicsPizza.Repositories.Interfaces;
using DominicsPizza.Repositories.Models;
using DominicsPizza.Services.Interfaces;
using System;
using System.Linq;

namespace DominicsPizza.Services.Implementations
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IRepository<CartItem> _cartItem;

        public CartService(ICartRepository cartRepository, IRepository<CartItem> cartItem)
        {
            _cartRepository = cartRepository;
            _cartItem = cartItem;
        }
        public Cart AddItem(int userId, Guid cartId, int itemId, decimal unitPrice, int quantity)
        {
            try
            {
                Cart cart = _cartRepository.GetCart(cartId);
                if(cart == null)
                {
                    cart = new Cart();
                    CartItem item = new CartItem(itemId, quantity, unitPrice);
                    cart.Id = cartId;
                    cart.UserId = userId;
                    cart.CreatedDate = DateTime.Now;

                    item.CartId = cart.Id;
                    cart.Items.Add(item);
                    _cartRepository.Add(cart);
                    _cartRepository.SaveChanges();
                }
                else
                {
                    CartItem item = cart.Items.Where(p => p.ItemId == itemId).FirstOrDefault();
                    if(item != null)
                    {
                        item.Quantity += quantity;
                        _cartItem.Update(item);
                        _cartItem.SaveChanges();
                    }
                    else
                    {
                        item = new CartItem(itemId, quantity, unitPrice);
                        item.CartId = cart.Id;
                        cart.Items.Add(item);

                        _cartItem.Update(item);
                        _cartItem.SaveChanges();
                    }
                }
                return cart;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public int DeleteItem(Guid cartId, int itemId)
        {
            return _cartRepository.DeleteItem(cartId, itemId);
        }

        public int GetCartCount(Guid cartId)
        {
            var cart = _cartRepository.GetCart(cartId);
            return cart != null ? cart.Items.Count() : 0;
        }

        public CartModel GetCartDetails(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public int UpdateCart(Guid cartId, int userId)
        {
            return _cartRepository.UpdateCart(cartId, userId);
        }

        public int UpdateQuantity(Guid cartId, int id, int quantity)
        {
            return _cartRepository.UpdateQuantity(cartId, id, quantity);
        }
    }
}
