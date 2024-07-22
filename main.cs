using System;

namespace GreenvilleIdol
{
    class GreenvilleRevenue
    {
        public static void Main(string[] args)
        {
            var app = new GreenvilleIdolApp();
            app.Run();
        }
    }

    public class GreenvilleIdolApp
    {
        private string motto = "************************************\n*  The stars shine in Greenville.  *\n************************************";
        private int lastYearContestants = 0;
        private int thisYearContestants = 0;
        private int revenuePerContestant = 25;  

        public string DisplayMotto()
        {
            return motto;
        }

        public string DisplayMenu()
        {
            return "Please Enter the following number below from the following menu:\n" +
                   "1. CALCULATE Greenville Revenue Year-Over-Year\n" +
                   "2. Exit";
        }

        public string CalculateRevenue()
        {
            int expectedRevenue = thisYearContestants * revenuePerContestant;
            return $"Expected Revenue this year is ${expectedRevenue}";
        }

        public string CheckContestantNumbers()
        {
            if (thisYearContestants == 2 * lastYearContestants)
            {
                return "The competition is more than twice as big this year!";
            }
            else if (thisYearContestants > lastYearContestants)
            {
                return "The competition is bigger than ever!";
            }
            else
            {
                return "A tighter race this year! Come out and cast your vote!";
            }
        }

        private int GetContestantNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number >= 0 && number <= 30)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 30.");
                }
            }
            return number;
        }

        public void Run()
        {
            Console.WriteLine(DisplayMotto());
            while (true)
            {
                Console.WriteLine(DisplayMenu());
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    lastYearContestants = GetContestantNumber("Enter the number of contestants from last year (0-30): ");
                    thisYearContestants = GetContestantNumber("Enter the number of contestants from this year (0-30): ");

                    Console.WriteLine(CalculateRevenue());
                    Console.WriteLine(CheckContestantNumbers());
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Thank you for using the Greenville Revenue App, good bye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option, please try again.");
                }
            }
        }
    }
}
