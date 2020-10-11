using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Client.ingredients;
using Client.utils;
using Domain;
using Domain.Recepies;

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

            var input = Utils.AskInput(menuDisplay);

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        login();
                        break;
                    case "2":
                        signUp();
                        break;
                    case "3":
                        guestAccount();
                        break;
                    case "4":
                        logout();
                        break;
                    default:
                        Console.WriteLine(
                            "==================\n" +
                            "Invalid Operation!\n" +
                            "==================\n"
                        );
                        break;
                }

                if (loggedUser != null)
                {
                    return;
                }

                input = Utils.AskInput(menuDisplay);
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
            Console.WriteLine($"Logging out of {loggedUser.Name} account ... ");
            loggedUser = null;
        }

        private void guestAccount()
        {
            Console.WriteLine("logging in as guest");
            loggedUser = new User()
            {
                Role = UserRole.Guest,
                UserStatus = UserStatus.Accepted
            };
        }

        private void signUp()
        {
            var username = Utils.AskInput("Username: ");
            var password = Utils.AskInput("Password: ");

            var user = new User()
            {
                FavoriteRecepies = new HashSet<Recepie>(),
                Name = username,
                Pass = password,
                Role = UserRole.User,
                UserStatus = UserStatus.Pending
            };
            
            _userService.Create(user);
            loggedUser = user;
        }
    }
}