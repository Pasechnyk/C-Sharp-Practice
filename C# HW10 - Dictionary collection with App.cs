using System;
using System.Collections.Generic;

// Task - create managment system for users using Dictionary collection
namespace Manager
{
    public class ManagerApp
    {
        // dictionary collection
        private Dictionary<string, string> UserInformation { get; set; }

        // methods
        public void AddUser(string login, string password)
        {
            UserInformation.Add(login, password);
        }

        public void RemoveLogin(string login)
        {
            if (UserInformation.ContainsKey(login))
            {
                UserInformation.Remove(login);
            }
            else { Console.WriteLine("Cannot hold the operation due to the missing login!"); }
        }

        public void EditUser(string login, string password)
        {
            UserInformation[login] = password;
        }

        public void FindPassword(string login)
        {
            if (UserInformation.ContainsKey(login))
            {
                Console.WriteLine(UserInformation[login]);
            }
            else { Console.WriteLine("There is no such login in a system!"); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // initializing app class
            ManagerApp manager = new ManagerApp();

            Dictionary<string, string> UserInformation = new Dictionary<string, string>
            {
                ["Paul"] = "Yjco25",
                ["isak"] = "kainfo8ej",
                ["juen"] = "Imrof778899",
                ["Vivi"] = "JneiOmel",
                ["Pola"] = "Ioooppp54",
                ["Tony"] = "Win733",
            };

            // menu with switch
            Console.WriteLine("------------ USER MANAGEMENT APP ------------");
            Console.WriteLine("Choose your option: \n 1 - Show collection of users \n 2 - Add new user" +
                "\n 3 - Remove existing login \n 4 - Edit user information \n 5 - Find password by given login");
            int option;
            option = Console.Read();
            switch (option)
            {
                case 1:
                    {
                        Console.WriteLine("Collection of users:");
                        foreach (var user in UserInformation)
                        {
                            Console.WriteLine($"{user.Key} - {user.Value}");
                        }
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Enter the login and password you want to ADD:");
                        string login = Console.ReadLine();
                        string password = Console.ReadLine();
                        manager.AddUser(login, password);
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Enter the login you want to REMOVE:");
                        string login = Console.ReadLine();
                        manager.RemoveLogin(login);
                    }
                    break;
                case 4:
                    {
                        Console.WriteLine("Enter the login and password you want to EDIT:");
                        string login = Console.ReadLine();
                        string password = Console.ReadLine();
                        manager.EditUser(login, password);
                    }
                    break;
                case 5:
                    {
                        Console.WriteLine("Enter the login to FIND password information:");
                        string login = Console.ReadLine();
                        manager.FindPassword(login);
                    }
                    break;
                default:
                    break;
            }    
        }
    }
}
