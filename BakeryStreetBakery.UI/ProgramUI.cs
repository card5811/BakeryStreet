using BakeryStreetBakery.Data;
using BakeryStreetBakery.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BakeryStreetBakery.UI
{
    internal class ProgramUI
    {
        private readonly OrderRepo _repo = new OrderRepo();

        public void Run()
        {
            SeedContent();
            MainMenu();
        }

        private void MainMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option by number. \n" +
                    "1. Add Item\n" +
                    "2. Get all items\n" +
                    "3. Get Item by order number\n" +
                    "4. Update item by order number\n" +
                    "5. Delete order by order number\n" +
                    "6. Exit");
                string userInput = Console.ReadLine();
                bool check = CheckMainInput(userInput);
                if (check == true)
                {
                    switch (userInput)
                    {
                        case "1": //add item
                            CreateOrder();
                            break;
                        case "2":
                            GetAllOrders();
                            break;
                        case "3"://remove item
                            GetOrderById();
                            break;
                        case "4":
                            UpdateOrderById();
                            break;
                        case "5":
                            DeleteOrder();
                            break;
                        case "6"://exit
                            continueToRun = false;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Incorrect input please try again.");
                    Thread.Sleep(3000);
                }
            }
        }
        private void CreateOrder()
        {
            Console.Clear();
            Orders order = new Orders();
            FoodItem foodItem = new FoodItem();
            List<FoodItem> item = new List<FoodItem>();
            order.Items = item;

            Console.WriteLine("What is the name for the order?");
            order.Name = Console.ReadLine().Trim();

            Console.WriteLine("What type of goods would you like to purchase? \n" +
                "Please  type in your value by id number. \b\n" +
                "1. Bread\n" +
                "2. Cake\n" +
                "3. Pastry \n" +
                "4. Pie");

            string input = Console.ReadLine();
            int userInput = Convert.ToInt32(input);
            bool check = CheckForInt(input);
            if (check == true)
            {
                TypeOfGood goodType = (TypeOfGood)userInput;
                foodItem.GoodType = goodType;
                item.Add(foodItem);

                Console.WriteLine("Would you like to add another item y or n?");
                string userInput1 = Console.ReadLine().ToLower().Trim();
                while (userInput1 == "y")
                {
                    Console.WriteLine("Please  type in your value by id number. \b\n" +
                    "1. Bread\n" +
                    "2. Cake\n" +
                    "3. Pastry \n" +
                    "4. Pie");
                    int userInput3 = Int16.Parse(Console.ReadLine().Trim());
                    TypeOfGood goodTypes = (TypeOfGood)userInput3;
                    foodItem.GoodType = goodTypes;
                    item.Add(foodItem);

                    Console.WriteLine("Would you like to add another item y or n?");
                    userInput1 = Console.ReadLine().ToLower().Trim();
                }

                _repo.CreateOrder(order);
            }
            else
                Console.WriteLine("Incorrect number has been used. Please try again.");
            userInput = Int16.Parse(Console.ReadLine().Trim());

        }
        private void GetAllOrders()
        {
            List<Orders> directory = _repo.ReadAllOrder();
            Console.WriteLine($"{"Customer Name",15} {"Order Number",15}{"Cost",15}{"Items",15} ");
            foreach (Orders content in directory)
            {


                Console.WriteLine($"{content.Name,10} {content.OrderNumber,15} {content.TotalCost,17} {content.Items.Count(),15}");
            }

            Thread.Sleep(3000);
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
        private void GetOrderById()
        {
            Console.WriteLine("What is your order number?");
            int id = Convert.ToInt32(Console.ReadLine().Trim());
            Orders order = _repo.GetOrderById(id);
            string itemName = _repo.GetItemNameDisplayBatches(id);

            Console.WriteLine($"{order.Name}, {order.OrderNumber}, {order.TotalCost}, {itemName}");
            Thread.Sleep(3000);
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

        }
        private void UpdateOrderById()
        {
            Console.WriteLine("What is your order number?");
            int id = Convert.ToInt32(Console.ReadLine().Trim());
            Orders order = _repo.GetOrderById(id);

            List<FoodItem> newItem = new List<FoodItem>();
            FoodItem foodItem = new FoodItem();


            order.Items = newItem;

            List<FoodItem> items = order.Items;
            string itemList = String.Join(",", items);

            Console.WriteLine($"{order.Name}, {order.OrderNumber}, {order.TotalCost}, {itemList}");

            Console.WriteLine("Would you like to change the Name or Items? Press y or n");
            string userInput = Console.ReadLine().ToLower().Trim();
            if (userInput == "y")
            {
                Console.WriteLine("What is the name for the order?");
                string newContent = Console.ReadLine();
                order.Name = newContent;

                Console.WriteLine("All previous goods have been deleted. What type of goods would you like to add? \n" +
               "Please  type in your value by id number. \b\n" +
               "1. Bread\n" +
               "2. Cake\n" +
               "3. Pastry \n" +
               "4. Pie");
                int goodInput = Int16.Parse(Console.ReadLine().Trim());
                TypeOfGood goodType = (TypeOfGood)goodInput;
                foodItem.GoodType = goodType;
                newItem.Add(foodItem);

                Console.WriteLine("Would you like to add another item y or n?");
                string userInput1 = Console.ReadLine().ToLower().Trim();
                while (userInput1 == "y")
                {
                    Console.WriteLine("Please  type in your value by id number. \b\n" +
                    "1. Bread\n" +
                    "2. Cake\n" +
                    "3. Pastry \n" +
                    "4. Pie");
                    int userInput3 = Int16.Parse(Console.ReadLine().Trim());
                    TypeOfGood goodTypes = (TypeOfGood)userInput3;
                    foodItem.GoodType = goodTypes;
                    newItem.Add(foodItem);

                    Console.WriteLine("Would you like to add another item y or n?");
                    userInput1 = Console.ReadLine().ToLower().Trim();
                }

                Console.WriteLine("Your order has been updated.\b" +
                    "Press any key to continue.");
                Console.ReadLine();

            }
            Console.WriteLine("Your order has not been updated.\b" +
                    "Press any key to continue.");
            Console.ReadLine();
        }
        private void DeleteOrder()
        {
            Console.WriteLine("What is your order number?");
            int id = Convert.ToInt32(Console.ReadLine().Trim());
            Orders order = _repo.GetOrderById(id);
            List<FoodItem> items = order.Items;
            string itemList = String.Join(",", items);

            Console.WriteLine($"{order.Name}, {order.OrderNumber}, {order.TotalCost}, {itemList}");

            Console.WriteLine("Would you like to delete this order? Press y or n");
            string userInput = Console.ReadLine().ToLower().Trim();
            if (userInput == "y")
            {
                _repo.DeleteOrder(id);
                if (_repo.DeleteOrder(id) == true)
                {
                    Console.WriteLine("Your order has been deleted. Press any key to continue.");
                    Console.ReadLine();
                }
                else Console.WriteLine("Something went wrong try again later. Press any key to continue.");
            }
            else
                Console.WriteLine("Ok no problem... Press any key to continue.");
            Console.ReadLine();
        }


        private bool CheckMainInput(string input)
        {
           var userInput = input.ToLower().Trim().Replace(" ", "");
            if (userInput == "1" || userInput == "2" || userInput == "3" || userInput == "4" || userInput == "5" || userInput == "6")
            {
                return true;
            }
            else
                return false;
        }
        private bool CheckForChar(string userInput)
        {
            userInput.ToLower().Trim().Replace(" ", "");
            if (userInput == "y" || userInput == "n")
            {
                return true;
            }
            else
                return false;
        }
        private bool CheckForInt(string id)
        {
           int userInput = Convert.ToInt32(Console.ReadLine().Trim().Replace(" ", ""));
            if (userInput == 1 || userInput == 2 || userInput == 3 || userInput == 4 || userInput == 5 || userInput == 6)
            {
                return true;
            }
            return false;
        }


        private void SeedContent()
        {
            FoodItem item1 = new FoodItem(TypeOfGood.Bread);
            FoodItem item2 = new FoodItem(TypeOfGood.Cake);
            FoodItem item3 = new FoodItem(TypeOfGood.Pastry);
            FoodItem item4 = new FoodItem(TypeOfGood.Pies);

            Orders one = new Orders("Craig", new List<FoodItem> { item1 });
            _repo.CreateOrder(one);

            Orders two = new Orders("Jon", new List<FoodItem> { item2, item3, item4 });
            _repo.CreateOrder(two);
        }
    }
}
