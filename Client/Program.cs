using System;
using System.Collections.Generic;
using Client.Controllers;
using Domain.ingredients;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var ingredientController = new IngredientController();
            var userController = new UserController();
            var recepiesController = new RecepiesController();

            var menuDisplay = "---- Menu ----\n" +
                                    "1 - Ingredients\n" +
                                    "2 - Login\n" +
                                    "3 - Recipies\n" +
                                    "0 - Exit\n";

            Console.WriteLine(menuDisplay);
            string input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        ingredientController.menu();
                        break;
                    case "2":
                        userController.menu();
                        break;
                    case "3":
                        recepiesController.menu();
                        break;
                    default:
                        Console.WriteLine(
                            "==================\n" +
                            "Invalid Operation!\n" +
                            "==================\n"
                            );
                        break;
                }   
                
                Console.WriteLine(menuDisplay);
                input = Console.ReadLine();
            }
            
        }
    }
}