using BakeryStreetBakery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryStreetBakery.Services
{
    internal interface IOrderRepo
    {
        bool CreateOrder(Orders order);
        List<Orders> ReadAllOrder();
        Orders GetOrderById(int id);
        Orders UpdateOrderbyId(int id, Orders oldContent);
        bool DeleteOrder(int id);
        //Helpers
        decimal GetTotalCost(int id);
        decimal GetCostOfBatches(int id);
        decimal GetCostOfGoods(int orderNumber);
    }
}
