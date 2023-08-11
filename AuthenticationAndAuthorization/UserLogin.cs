using System;
using System.IO;

namespace AuthenticationAndAuthorization
{
    public class UserLogin
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Register New User");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Admin Login");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterNewUser();
                        break;
                    case 2:
                        UserLogin();
                        break;
                    case 3:
                        AdminLogin();
                        break;
                    case 4:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select again.");
                        break;
                }
            }
        }

        static void RegisterNewUser()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            UserLogin newUser = new UserLogin(username, email);
            SaveUserToFile(newUser, "user.txt");

            Console.WriteLine("User registration successful. Data saved to user.txt.");
        }

        static void AurhenticateUserLogin()
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            UserLogin user = LoadUserFromFile("user.txt");

            if (user != null && user.Username == username && user.Email == email)
            {
                Console.WriteLine("User login successful.");
            }
            else
            {
                Console.WriteLine("User login failed. Please try again.");
            }
        }

        static void AdminLogin()
        {
            Console.Write("Enter admin username: ");
            string adminUsername = Console.ReadLine();

            Console.Write("Enter admin password: ");
            string adminPassword = Console.ReadLine();

            if (adminUsername == "admin" && adminPassword == "adminpassword")
            {
                Console.WriteLine("Admin login successful.");
            }
            else
            {
                Console.WriteLine("Admin login failed. Please try again.");
            }
        }

        static void SaveUserToFile(User user, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Username: {user.Username}");
                writer.WriteLine($"Email: {user.Email}");
            }
        }

        static UserLogin LoadUserFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string username = reader.ReadLine()?.Substring(10);
                    string email = reader.ReadLine()?.Substring(7);
                    return new LoginSuccess(username, email);
                }
            }
            return null;
        }
    }
}