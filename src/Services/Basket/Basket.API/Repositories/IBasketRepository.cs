﻿using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);

        Task<ShoppingCart> UpdateBaket(ShoppingCart basket);// alse create

        Task DeleteBasket(string userName);
    }
}
