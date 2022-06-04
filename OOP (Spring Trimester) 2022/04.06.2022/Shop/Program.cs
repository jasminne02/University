using System;

namespace Shop
{
    class MainClass
    {
        public static void Main()
        {
            Inventory inventoryDepartmentStore = new Inventory();
            Inventory inventoryGroceryStore = new Inventory();
            Inventory inventorySpecialtyStore = new Inventory();


            Inventory currentInventory = new Inventory();
            List<Product> currentProducts = new List<Product>();
            Product product;
            int command;
            string storeType;
            

            do
            {
                Console.WriteLine("0 Exit   1 Store");
                command = int.Parse(Console.ReadLine());
                if (command == 1)
                {
                    Console.WriteLine("What u wanna do? 1 Product   2 InteractWithInventory");
                    command = int.Parse(Console.ReadLine());
                    Console.WriteLine("Choose a store type:  DepartmentStore   GroceryStore    SpecialtyStore");
                    storeType = Console.ReadLine();

                    switch (storeType)
                    {
                        case "DepartmentStore":
                            currentInventory = inventoryDepartmentStore;
                            break;
                        case "GroceryStore":
                            currentInventory = inventoryGroceryStore;
                            break;
                        case "SpecialtyStore":
                            currentInventory = inventorySpecialtyStore;
                            break;
                        default:
                            continue;
                    }

                    switch (command)
                    {
                        case 1:
                            Console.WriteLine("1 CreateNewProduct   2 AddStockToAProduct  3 CalculateTotalValueOfProduct");
                            command = int.Parse(Console.ReadLine());

                            switch (command)
                            {
                                case 1:
                                    Console.WriteLine("What product u want to add? Choose a position of it ");
                                    if(storeType == "DepartmentStore")
                                    {
                                        Console.WriteLine("Shirt, Pants, Coat");
                                        command = int.Parse (Console.ReadLine());

                                        if (command == 1)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Size: ");
                                            string size = Console.ReadLine();
                                            Console.WriteLine("Color: ");
                                            string color = Console.ReadLine();
                                            Shirt createdProduct = new Shirt("Shirt", "Shirt", price, 1, size, color, "cotton");
                                            currentProducts.Add(createdProduct);
                                        }
                                        else if (command == 2)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Size: ");
                                            string size = Console.ReadLine();
                                            Console.WriteLine("Color: ");
                                            string color = Console.ReadLine();
                                            Pants createdProduct = new Pants("Jeans", "Skinny", price, 1, size, color, "denim");
                                            currentProducts.Add(createdProduct);
                                        }
                                        else if (command == 3)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Size: ");
                                            string size = Console.ReadLine();
                                            Console.WriteLine("Color: ");
                                            string color = Console.ReadLine();
                                            Coat createdProduct = new Coat("Coat", "Coat", price, 1, size, color, "cotton");
                                            currentProducts.Add(createdProduct);
                                        }

                                    }
                                    else if (storeType == "GroceryStore")
                                    {
                                        Console.WriteLine("Milk, Bread");
                                        command = int.Parse(Console.ReadLine());

                                        if (command == 1)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Milk createdProduct = new Milk("Milk", "It's a bottle of milk", price, 1, 1000, "End of June 2022");
                                            currentProducts.Add(createdProduct);
                                        }
                                        else if (command == 2)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Bread createdProduct = new Bread("Bread", "It's a bread", price, 1, 1000, "End of June 2022");
                                            currentProducts.Add(createdProduct);
                                        }

                                    }
                                    else if (storeType == "SpecialtyStore")
                                    {
                                        Console.WriteLine("Phone, Computer");
                                        command = int.Parse(Console.ReadLine());

                                        if(command == 1)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Model: ");
                                            string model = Console.ReadLine();
                                            Phone createdProduct = new Phone("Phone", "Brand new phone", price, 1, model, 4500, "A15");
                                            currentProducts.Add(createdProduct);
                                        }
                                        else if(command == 2)
                                        {
                                            Console.WriteLine("Price: ");
                                            decimal price = decimal.Parse(Console.ReadLine());
                                            Console.WriteLine("Model: ");
                                            string model = Console.ReadLine();
                                            Computer createdProduct = new Computer("Computer", "Brand new computer", price, 1, model, 9500, "M15");
                                            currentProducts.Add(createdProduct);
                                        }

                                    }

                                    command = -1;
                                    break;
                                case 2:
                                    product = ChooseProduct(currentProducts);
                                    Console.WriteLine("How many stock u want to add? ");
                                    command = int.Parse(Console.ReadLine());
                                    product.AddStockToAProduct(command);
                                    command = -1;
                                    break;
                                case 3:
                                    product = ChooseProduct(currentProducts);
                                    product.CalculateTotalValueOfProduct();
                                    command = -1;
                                    break;
                            }

                            command = -1;
                            break;
                        case 2:
                            Console.WriteLine("Choose an option: 1 AddToInventory  2 CalculateInventoryTotalValue");
                            command = int.Parse(Console.ReadLine());
                            if (command == 1)
                            {
                                Console.WriteLine("What product u want to add? Your current products: ");
                                if(currentProducts.Count > 0)
                                {
                                    currentInventory.AddProduct(ChooseProduct(currentProducts));
                                }
                                else
                                {
                                    Console.WriteLine("There are no products. Invalid action!");
                                }

                                command = -1;
                            }
                            else if (command == 2)
                            {
                                Console.WriteLine("Invetory total value: " + currentInventory.CalculateTotalValue());

                                command = -1;
                            }

                            break;
                        default:
                            Console.WriteLine("Invalid input!");
                            continue;
                    }

                    switch (storeType)
                    {
                        case "DepartmentStore":
                            inventoryDepartmentStore = currentInventory;
                            break;
                        case "GroceryStore":
                            inventoryGroceryStore = currentInventory;
                            break;
                        case "SpecialtyStore":
                            inventorySpecialtyStore = currentInventory;
                            break;
                        default:
                            continue;
                    }

                }

            } while (command != 0);
            
        }

        public static Product ChooseProduct(List<Product> currentProducts)
        {
            int command; 

            foreach (Product p in currentProducts)
            {
                Console.Write(p.Title + " ");
            }
            Console.WriteLine("\nEnter product's position u want: ");
            command = int.Parse(Console.ReadLine());

            return currentProducts[command-1];
        }
    }
}
