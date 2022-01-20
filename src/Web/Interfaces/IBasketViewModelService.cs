﻿using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<Order> CreateOrderAsync(Address address);
        Task<BasketViewModel> GetBasketAsync();
        Task<BasketViewModel> AddBasketItemAsync(int productId, int quantity);
        Task<int> BasketItemsCountAsync();
        Task EmptyBasketAsync();
        Task RemoveBasketItemAsync(int basketItemId);
        Task UpdateBasketItemsAsync(int[] basketItemIds, int[] quantities);

        
    }
}
