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
            var userController = new UserController();
            var recepiesController = new RecepiesController();

            var menuDisplay = "---- Menu ----\n" +
                                    "1 - Recipies\n" +
                                    "2 - Login\n" +
                                    "0 - Exit\n";

            Console.WriteLine(menuDisplay);
            string input = Console.ReadLine();
            
            var loggedUser = userController.loggedUser;

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        recepiesController.menu(loggedUser);
                        break;
                    case "2":
                        userController.menu();
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
                
                loggedUser = userController.loggedUser;
                if (loggedUser != null)
                {
                    Console.WriteLine($"Logged in as: {loggedUser.Name}");
                }
                
                input = Console.ReadLine();
            }
            
        }
    }
}