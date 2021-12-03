using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryStreetBakery.Data
{
    public enum TypeOfGood { Bread = 1, Cake, Pastry, Pies }
    public class FoodItem
    {
        public string FoodName
        {
            get
            {


                if (GoodType == TypeOfGood.Bread)
                {
                    return "Bread";
                }
                else if (GoodType == TypeOfGood.Cake)
                {
                    return "Cake";
                }
                else if (GoodType == TypeOfGood.Pastry)
                {
                    return "Pastry";
                }
                else if (GoodType == TypeOfGood.Pies)
                {
                    return "Pie";
                }

                return null;
            }
 
        }

        public TypeOfGood GoodType { get; set; }
        public decimal CostOfGoods
        {
            get
            {
                if (GoodType == TypeOfGood.Bread)
                {
                    return 500.01m;
                }
                else if (GoodType == TypeOfGood.Cake)
                {
                    return 2000m;
                }
                else if (GoodType == TypeOfGood.Pastry)
                {
                    return 200.10m;
                }
                else if (GoodType == TypeOfGood.Pies)
                {
                    return 851.5m;
                }
                return 0;
            }
        }
        public int Batches { get; set; }
        public FoodItem() { }
        public FoodItem(TypeOfGood goodsType)
        {
            GoodType = goodsType;
        }


    }
}