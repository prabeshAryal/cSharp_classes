using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginForm
{
    public class User
    {
        // Private fields
        private string _username;
        private string _password;
        private string _role;

        // Public properties with encapsulation
        public string Username
        {
            get { return _username; }
            private set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            private set { _password = value; }
        }
        public string Role
        {
            get { return _role; }
            private set { _role = value; }
        }

        // Constructor
        public User(string username, string password, string role = "User")
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }

    public class LoginActivity
    {


        public static bool Login(string username, string password, List<User> users)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine($"Login successful! Welcome, {user.Username}. Role: {user.Role}");
                    return true;
                }
            }

            Console.WriteLine("Login failed. Invalid username or password.");
            return false;
        }

    }
}
