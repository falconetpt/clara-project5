using System;
using System.Runtime.CompilerServices;
using Client.ingredients;
using Client.utils;
using Domain;

namespace Client.Controllers
{
    public class UserController
    {
        public User loggedUser { set; get; }
        private UserService _userService = new UserService();

        public void menu()
        {
            var menuDisplay = "---- Menu ----\n" +
                              "1 - Login\n" +
                              "2 - Sign Up\n" +
                              "3 - Guest\n" +
                              "4 - Sign out\n" +
                              "0 - Exit\n";

            Console.WriteLine(menuDisplay);
            string input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        login();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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

        private void login()
        {
            var username = Utils.AskInput("Username: ");
            var password = Utils.AskInput("Password: ");

            var user = _userService.GetByUserName(username);

            if (user.Pass == password)
            {
                Console.WriteLine($"Looged in as {user.Name}");
                loggedUser = user;
            }
            else
            {
                Console.WriteLine("Invalid User");
            }
        }
        
        private void logout()
        {
            loggedUser = null;
        }
    }
}