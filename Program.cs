using System;
using static PasswordEncryption.General;
using static PasswordEncryption.Account;


namespace PasswordEncryption
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                UserInterface();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                string[] outString =
                {
                    "       EXITING APPLICATION.",
                    "        DROPING DATABASE: "
                };
                PrintOut(outString);
                int count = 1;
                foreach(Account item in UserAccounts)
                {

                    Console.WriteLine($"Account Number {count}:");
                    Console.WriteLine($"Username: {item.UserName}");
                    Console.WriteLine($"Password Hash: {item.PassHash}\n");
                }
            }
        }
    }
}
