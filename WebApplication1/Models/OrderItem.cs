﻿namespace BeerSupplyAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int KegId { get; set; }
        public int Quantity { get; set; }
    }
}
