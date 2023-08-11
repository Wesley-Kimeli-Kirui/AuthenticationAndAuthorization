using System.IO;

namespace AuthenticationAndAuthorization
{
    public class RegisterNewUser
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            // Create user object
            UserModel newUser = new UserModel(username, email);

            // Save user data to file
             Directory.CreateDirectory(@"D:\The Jitu\Data");
            //SaveUserToFile(newUser, UserLogin);
            var path = (@"D:\The Jitu\Data\user.txt");
            File.CreateText(path);


            Console.WriteLine("User registration successful. Data saved to user.txt.");
        }

        static void SaveUserToFile(UserModel user, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Username: {user.Username}");
                writer.WriteLine($"Email: {user.Email}");
            }
        }
    }

}

