using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCatalog
{
    static class User
    {
        private static string username;
        private static string password;
        private static Dictionary<string, string> users = new Dictionary<string, string>();
        private static List<UserProfile> userProfiles = new List<UserProfile>();

        public static List<UserProfile> UserProfiles {  get { return userProfiles; } }

        public static UserProfile EnterAsUser()
        {
            bool userFound = false;

            if(users.Count == 0)
            {
                Console.WriteLine("Create a user first");
                return null;
            }

            Console.Write("username: ");
            username = Console.ReadLine();

            foreach(KeyValuePair<string, string> u in users)
            {
                if (username == u.Key)
                {
                    userFound = true;
                }
            }

            if (!userFound)
            {
                Console.WriteLine("The user does not exist");
                return null;
            }

            userFound = true;

            do
            {
                userFound = true;
                Console.Write("password: ");
                password = Console.ReadLine();

                foreach (KeyValuePair<string, string> u in users)
                {
                    if (password != u.Value)
                    {
                        userFound = false;
                    }
                }
            } while (!userFound);

            UserProfile profile = new UserProfile(username);
            userProfiles.Add(profile);

            return profile;
        }

        public static void CreateUser()
        {
            string pass1, pass2;
            bool freeUsername = true;

            do
            {
                freeUsername = true;
                Console.Write("Create User\nusername: ");
                username = Console.ReadLine();

                foreach (KeyValuePair<string, string> u in users)
                {
                    if (username == u.Key)
                    {
                        freeUsername = false;
                        Console.WriteLine("This username is already taken");
                    }
                }

            } while (!freeUsername);

            do
            {
                Console.Write("password: ");
                pass1 = Console.ReadLine();
                Console.Write("confirm password: ");
                pass2 = Console.ReadLine();
            } while (pass1 != pass2);

            password = pass1;

            users.Add(username, password);
            Console.WriteLine("User created!\n");
        }

        public static void DeleteUser()
        {
            bool userFound = false;

            Console.Write("Enter the username of the user u want to delete: ");
            username = Console.ReadLine();

            foreach(KeyValuePair<string, string> u in users)
            {
                if(username == u.Key)
                {
                    users.Remove(u.Key);
                    userFound = true;
                }
            }

            if (!userFound)
            {
                Console.WriteLine(username + " does not exist");
            }
        }

    }
}
