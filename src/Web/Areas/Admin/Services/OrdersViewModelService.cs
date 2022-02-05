using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Admin.Interfaces;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Services
{
    public class OrdersViewModelService : IOrdersViewModelService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrdersViewModelService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderViewModel>> GetOrderViewModelAsync()
        {
            var specOrders = new OrderWithItemsSpecification();
            var ListOfOrders = await _orderRepository.ListAsync(specOrders);
            var vm = ListOfOrders.Select(x => new OrderViewModel()
            {
                BuyerId = x.BuyerId,
                Items = x.Items,
                OrderDate = x.OrderDate,
                ShipToAdress = x.ShipToAdress,
            }).ToList();
            return vm;
        }
    }
}
