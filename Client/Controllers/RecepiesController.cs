using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Client.ingredients;
using Client.utils;
using DAL.recepie;
using Domain;
using Domain.ingredients;
using Domain.Recepies;

namespace Client.Controllers
{
    public class RecepiesController
    {
        private RecepiesServices _recepiesServices = new RecepiesServices();
        
        public void menu(User loggedUser)
        {
            var menuDisplay = "---- Menu ----\n" +
                              "1 - Create\n" +
                              "2 - Personal Area\n" +
                              "3 - Pending Recipies\n" +
                              "4 - Favorite Recipies\n" +
                              "5 - Rate/Comment Recipies\n" +
                              "6 - Search\n" +
                              "0 - Exit\n";

            Console.WriteLine(menuDisplay);
            string input = Console.ReadLine();

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        createRecepie(loggedUser);
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        pendingRecipies(loggedUser);
                        break;
                    case "4":
                        favoriteRecipies(loggedUser);
                        break;
                    case "5":
                        rateAndComment(loggedUser);
                        break;
                    case "6":
                        
                        break;
                    default:
                        Console.WriteLine(
                            "==================\n" +
                            "Invalid Operation!\n" +
                            "==================\n"
                        );
                        break;
                }

                input = Utils.AskInput(menuDisplay);
            }
        }

        private void rateAndComment(User loggedUser)
        {
            if (loggedUser.Role == UserRole.User)
            {
                Console.WriteLine("Favorite Recipies");
                var recepies =_recepiesServices.GetAllAccepted();

                for (int i = 0; i < recepies.Count; i++)
                {
                    Console.WriteLine($"{i} -> {recepies[i]}");
                }
                
                var acceptIndex = int.Parse(Utils.AskInput("Choose number to accept: "));
                if (acceptIndex >= 0  && acceptIndex < recepies.Count)
                {
                    var value = recepies[acceptIndex];
                    var comment = Utils.AskInput("Comment: ");
                    var rating = int.Parse(Utils.AskInput("Rating: ")) ;


                    _recepiesServices.saveInfo(new RecepieInfo()
                    {
                        Comment = comment,
                        CreatedBy = loggedUser,
                        Rating = rating,
                        Recepie = value
                    });
                }
            }
            else
            {
                Console.WriteLine("Operation only allowed for registered users");
            }
        }

        private void favoriteRecipies(User loggedUser)
        {
            if (loggedUser.Role == UserRole.User)
            {
                Console.WriteLine("Favorite Recipies");
                var favoriteRecipies = loggedUser.FavoriteRecepies.ToList();

                for (int i = 0; i < favoriteRecipies.Count; i++)
                {
                    Console.WriteLine($"{i} -> {favoriteRecipies[i]}");
                }
            }
            else
            {
                Console.WriteLine("Operation only allowed for registered users");
            }
        }

        private void pendingRecipies(User loggedUser)
        {
            if (loggedUser.Role == UserRole.Admin)
            {
                var recipies = _recepiesServices.GetAllPending();
                Console.WriteLine("Select recipie to approve");
                
                for (int i = 0; i < recipies.Count; i++)
                {
                    Console.WriteLine($"{i} - {recipies[i]}");    
                }

                var acceptIndex = int.Parse(Utils.AskInput("Choose number to accept: "));
                if (acceptIndex >= 0  && acceptIndex < recipies.Count)
                {
                    var value = recipies[acceptIndex];
                    value.Status = RecepieStatus.Accepted;
                    _recepiesServices.Create(value);
                }
            }
            else
            {
                Console.WriteLine("Operation only allowed for admin");
            }
        }

        private void createRecepie(User loggedUser)
        {
            if (loggedUser.Role == UserRole.User)
            {
                var name = Utils.AskInput("Insert name: ");
                var description = Utils.AskInput("Insert description: ");
                var ingredients = askForIngredients();
                var categories = askForCategories();
                var difficulty = int.Parse(Utils.AskInput("Difficulty: "));
                var duration = int.Parse(Utils.AskInput("Duration: "));
                
                _recepiesServices.Create(new Recepie()
                {
                    Categories = categories,
                    CreatedBy = loggedUser,
                    Description = description,
                    Difficulty = difficulty,
                    Duration = duration,
                    Ingredients = ingredients,
                    Name = name,
                    Status = RecepieStatus.Pending
                });
            }
            else
            {
                Console.WriteLine("Operation only allowed for registered users");
            }
        }

        private List<Ingredient> askForIngredients()
        {
            var menuDisplay = "===== Menu =====\n" +
                              "1 - Add ingredient\n" +
                              "0 - Exit\n";
            var result = new List<Ingredient>();
            string input = Utils.AskInput(menuDisplay);

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        var ingredient = createIngredient();
                        if (ingredient != null)
                        {
                            Console.WriteLine("added ingredient");
                            result.Add(ingredient);
                        }

                        break;
                    default:
                        Console.WriteLine(
                            "==================\n" +
                            "Invalid Operation!\n" +
                            "==================\n"
                        );
                        break;
                }

                input = Utils.AskInput(menuDisplay);
            }

            return result;
        }

        private Ingredient createIngredient()
        {
            var name = Utils.AskInput("Name: ");
            var quantity = Utils.AskInput("Quantity: ");
            var measure = Utils.AskInput("Measure: ");
            Double quantityDouble = 0;

            if (Double.TryParse(quantity, out quantityDouble))
            {
                return new Ingredient()
                {
                    Measure = measure,
                    Name = name,
                    Quantity = quantityDouble
                };    
            }
            else
            {
                return null;
            }
        }

        private ISet<string> askForCategories()
        {
            var menuDisplay = "===== Menu =====\n" +
                              "1 - Add categories\n" +
                              "0 - Exit\n";
            var result = new HashSet<string>();
            string input = Utils.AskInput(menuDisplay);

            while (input != "0")
            {
                switch (input)
                {
                    case "1":
                        var category = Utils.AskInput("input category: ");
                        if (category != null)
                        {
                            Console.WriteLine("added category");
                            result.Add(category);
                        }
                        
                        break;
                    default:
                        Console.WriteLine(
                            "==================\n" +
                            "Invalid Operation!\n" +
                            "==================\n"
                        );
                        break;
                }

                input = Utils.AskInput(menuDisplay);
            }

            return result;
        }
    }
}