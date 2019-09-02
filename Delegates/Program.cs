using DemoLibrary;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    //delegate is:
    //passing in a method instead of a parameter to a method.
    class Program
    {
        static ShoppingCartModel cart = new ShoppingCartModel();
        static void Main()
        {
            PopulateCartWithDemoData();

            //passing in just the name of the method without any parentheses <- delegate passing
            Console.WriteLine($"The total for the cart is {cart.GenerateTotal(SubTotalAlert, CalculateLeveledDiscount, AlertUser)}");
            Console.WriteLine();
            //passing in an anonymous method - shorthand
            //the delegate cares only about output and input types.
                            //passing in subTotal to a method without a name the arrow describes the logic behind the method.
                            //the same goes for (products, subTotal) and (message).
            decimal total = cart.GenerateTotal((subTotal) => Console.WriteLine($"The subtotal for cart 2 is {subTotal}"), 
                                                (products, subTotal) => {
                                                    if(products.Count > 3) { return subTotal * 0.5M; }
                                                    else { return subTotal; }
                                                },
                                                (message) => Console.WriteLine($"Cart 2 Alert: { message }"));

            Console.WriteLine($"The total for cart 2 is {total}");
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Please press any key to exit the application...");
            Console.ReadKey();
        }

        //declaring the delegate method
        private static void SubTotalAlert(decimal subTotal)
        {
            Console.WriteLine($"The subtotal is {subTotal}");
        }

        private static void AlertUser(string message)
        {
            Console.WriteLine(message);
        }

        private static decimal CalculateLeveledDiscount(List<ProductModel> items, decimal subTotal)
        {
            if (subTotal > 100)     { return subTotal * 0.80M; }
            else if (subTotal > 50) { return subTotal * 0.85M; }
            else if (subTotal > 10) { return subTotal * 0.95M; }
            else                    { return subTotal; }
        }

        private static void PopulateCartWithDemoData()
        {
            cart.Items.Add(new ProductModel { ItemName = "Cereal", Price = 3.63M });
            cart.Items.Add(new ProductModel { ItemName = "Milk", Price = 2.95M });
            cart.Items.Add(new ProductModel { ItemName = "Strawberries", Price = 7.51M });
            cart.Items.Add(new ProductModel { ItemName = "Blueberries", Price = 8.84M });
        }
    }
}
