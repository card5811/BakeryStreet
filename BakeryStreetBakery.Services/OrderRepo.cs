using BakeryStreetBakery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BakeryStreetBakery.Services
{
    //Repo
    //The cost of each order is $100, plus the total cost of the batches in the order (base price per batch* number of batches)
    //We need methods to add an order to the list, get the list, remove from list, and print the contents of the list.
    public class OrderRepo : IOrderRepo
    {
        private readonly List<Orders> _repo = new List<Orders>();

        public bool CreateOrder(Orders order)
        {
            int directoryLength = _repo.Count();
            int num = _repo.Count() + 1;
            order.OrderNumber = num;
            _repo.Add(order);
            order.TotalCost = GetTotalCost(order.OrderNumber);
            bool wasAdded = directoryLength + 1 == _repo.Count();
            return wasAdded;
        }
        public List<Orders> ReadAllOrder()
        {
            foreach (Orders order in _repo)
            {
                int id = order.OrderNumber;
                order.TotalCost = GetTotalCost(id);
                return _repo;
            }
            return _repo;
        }
        public Orders GetOrderById(int id)
        {
            foreach (Orders orders in _repo)
            {
                if (orders.OrderNumber == id)
                    //orders.TotalCost = GetTotalCost(orders.OrderNumber);
                    return orders;
            }
            return null;
        }

        public Orders UpdateOrderbyId(int id, Orders oldContent)
        {
            foreach (Orders newContent in _repo)
            {
                if (newContent.OrderNumber == oldContent.OrderNumber)
                {
                    oldContent.Name = newContent.Name;
                    oldContent.Items = newContent.Items;
                    newContent.TotalCost = GetTotalCost(oldContent.OrderNumber);
                }
                return newContent;
            }
            return null;
        }
        public bool DeleteOrder(int id)
        {
            Orders itemFound = GetOrderById(id);
            bool deleteResult = _repo.Remove(itemFound);
            return deleteResult;
        }

        //Helper
        public decimal GetCostOfBatches(int id)
        {
            Orders content = GetOrderById(id);
            int batchNumber = content.Items.Count();
            return (batchNumber * 100);
        }

        public decimal GetCostOfGoods(int id)
        {
            Orders order = GetOrderById(id);
            if (order.OrderNumber == id)
            {
                var cost = order.Items.Sum(e => e.CostOfGoods);
                return cost;
                //foreach (var item in order.Items)
                //{
                //    decimal cost = Decimal.Add(c => c.);
                //    decimal totalPrice = cost;
                //}
            }
            return 0;
        }

        public decimal GetTotalCost(int id)
        {
            Orders orders = GetOrderById(id);
            if (orders != null)
            {
                decimal goodsCost = GetCostOfGoods(id);
                decimal totalCost = GetCostOfBatches(id);
                return (totalCost + goodsCost);
            }
            else
                return 0;
        }

        public string JoinListItemsTogether(int id)
        {
            Orders order = GetOrderById(id);
            List<string> itemName = new List<string>();
            foreach (var item in order.Items)
            {
                string name = item.FoodName;
                itemName.Add(name);
            }
            string itemList = String.Join(", ", itemName);
            return itemList;

        }
        public string GetItemNameDisplayBatches(int id)
        {
            Orders order = GetOrderById(id);
            Dictionary<string, int> item = new Dictionary<string, int>();
            foreach (var items in order.Items)
            {
                string name = items.FoodName;
                int batch = items.Batches;
                item.Add(name, batch);
            }

            var result = string.Join(" | ", item.Select(kp => string.Format("{0}, {1}", kp.Key, string.Join(", ", kp.Value))));
            return result;
        }
    }
}