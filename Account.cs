using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncryption
{
    public class Account
    {

        public static List<Account> UserAccounts = new List<Account>();
        public string UserName { get; }
        public string PassHash { get; }

        public static string Encrypt(string input)
        {
            string output = "";
            foreach(char x in input)
            {
                output += x + 797;
            }
            return output;
        }

        public static void EstablishAccount()
        {
            string name;
            string pw;
            Console.WriteLine("Please enter a username for your account:");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must enter a username for your account.");
                    name = Console.ReadLine();
            }
            if (UserAccounts.Count > 0)
            {
                for (int i = 0; i < UserAccounts.Count; i++)
                {
                    if (name == UserAccounts[i].UserName)
                    {
                        Console.WriteLine("That username is taken, please enter another name: ");
                        name = Console.ReadLine();
                        i = -1;
                    }
                }
            }
            Console.WriteLine("Please enter a password for your account:");
            pw = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must enter a password for your account.");
                pw = Console.ReadLine();
            }

            General.PrintOut("PROCESSING...");
           pw = Encrypt(pw);

            UserAccounts.Add(new Account(name, pw));
            General.PrintOut("ACCOUNT CREATED.");
        }
        public static void AuthenticateAccount()
        {
            if(UserAccounts.Count == 0)
            {
                General.PrintOut("No Accounts Exist in the Database.");
                return;
            }
            string name;
            string pw;
            int userInd = 0;
            Console.WriteLine("Please enter your username: ");
            name = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must enter the username for your account.");
                name = Console.ReadLine();
            }
            
            for (int i = 0; i < UserAccounts.Count; i++)
            {
                if (name == UserAccounts[i].UserName)
                {
                    userInd = i;
                    break;
                }
                General.PrintOut("That account does not exist.");
                return;
            }

            Console.WriteLine("Enter your password: ");
            pw = Console.ReadLine();
            while (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("You must enter your password: ");
                pw = Console.ReadLine();
            }
            pw = Encrypt(pw);

            if(pw == UserAccounts[userInd].PassHash)
            {
                General.PrintOut("ACCOUNT AUTHENTICATED.");
                return;
            }
            General.PrintOut("INCORRECT USERNAME / PASSWORD.");
        }
        public Account()
        {
            UserName = "DefaultUsername";
            PassHash = "P4$$W0RD";
        }
        public Account(string userN, string pw)
        {
            UserName = userN;
            PassHash = pw;
        }
    }
}
