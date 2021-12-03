using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryStreetBakery.Data
{
    public class Orders
    {
        public string Name { get; set; }
        public int OrderNumber { get; set; }
        public decimal TotalCost { get; set; }
        public List<FoodItem> Items { get; set; }

        public Orders() { }
        public Orders(string name, List<FoodItem> items)
        {
            Name = name;
            Items = items;
        }
        public Orders(string name, int orderID, decimal totalCost, List<FoodItem> items)
        {
            Name = name;
            OrderNumber = orderID;
            TotalCost = totalCost;
            Items = items;
        }

    }
}
