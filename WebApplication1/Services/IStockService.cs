using System.Collections.Generic;
using BeerSupplyAPI.Models;

namespace BeerSupplyAPI.Services
{
    public interface IStockService
    {
        void UpdateStock(int kegId, int quantity);
        List<Keg> GetKegsToReorder();
        Order CreateOrder();
        void AddOrderItem(int orderId, int kegId, int quantity);
        void RemoveOrderItem(int orderId, int orderItemId);
        void FinalizeOrder(int orderId);
    }
}
