using System;
using Course.Entities;
using Course.Entities.Exceptions;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the account data:");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw Limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account acc = new Account(number, holder, initialBalance, withdrawLimit);
                Console.Write("\nEnter amount for withdraw: ");
                double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                acc.WithDraw(withdraw);
                Console.WriteLine("New balance: $" + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch(DomainException e)
            {
                Console.WriteLine("Withdraw error : " + e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
