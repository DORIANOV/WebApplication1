using System.Collections.Generic;
using System.Linq;
using BeerSupplyAPI.Data;
using BeerSupplyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerSupplyAPI.Services
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _context;

        public StockService(AppDbContext context)
        {
            _context = context;
        }

        public void UpdateStock(int kegId, int quantity)
        {
            var keg = _context.Kegs.Find(kegId);
            if (keg != null)
            {
                keg.Quantity -= quantity;
                _context.SaveChanges();
            }
        }

        public List<Keg> GetKegsToReorder()
        {
            return _context.Kegs.Where(k => k.Quantity < k.ReorderThreshold).ToList();
        }

        public Order CreateOrder()
        {
            var order = new Order { OrderDate = DateTime.Now, OrderItems = new List<OrderItem>() };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void AddOrderItem(int orderId, int kegId, int quantity)
        {
            var order = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                var orderItem = new OrderItem { KegId = kegId, Quantity = quantity };
                order.OrderItems.Add(orderItem);
                _context.SaveChanges();
            }
        }

        public void RemoveOrderItem(int orderId, int orderItemId)
        {
            var order = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
                if (orderItem != null)
                {
                    order.OrderItems.Remove(orderItem);
                    _context.SaveChanges();
                }
            }
        }

        public void FinalizeOrder(int orderId)
        {
            // Logic to finalize the order
            // For example, you can mark the order as completed or send it to the supplier
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                // Perform necessary actions to finalize the order
                _context.SaveChanges();
            }
        }
    }
}
