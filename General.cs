using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordEncryption
{
    public class General
    {
        public static void UserInterface()
        {
            bool exit = false;
            while (exit == false)
            {
                string[] message =
                    {   "             AUTHENTICATE",
                    " ",
                    "       PLEASE SELECT AN OPTION",
                    "       1. Create User Account.",
                    "       2. Authenticate User.",
                    "       3. Loggout and Clear Database."
                    };
                PrintOut(message);
                string input = Console.ReadLine();
                while (input != "1" && input != "2" && input != "3")
                {
                    PrintOut("Incorrect format, please make a selection.");
                    input = Console.ReadLine();
                }
                switch (input)
                {
                    case "1":
                        Account.EstablishAccount();
                        break;
                    case "2":
                        Account.AuthenticateAccount();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        public static void PrintOut(string message)
        {
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("\n");

            Console.WriteLine("         " + message);

            Console.WriteLine("\n");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = =");
        }
        public static void PrintOut(string[] message)
        {
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("\n");
            foreach (string x in message)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\n");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = =");
        }
    }
}
