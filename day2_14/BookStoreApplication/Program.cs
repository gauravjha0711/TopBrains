using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            Console.WriteLine("Enter Details space separated: BookID Title Price Stock");
            string input = Console.ReadLine();
            string[] part = input.Split(" ");
            Book book = new Book();
            book.Id = part[0];
            book.Title = part[1];
            book.Price = int.Parse(part[2]);
            book.Stock = int.Parse(part[3]);
            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit

                int choice = 0; // TODO: Read user choice
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;

                    case 2:
                        // TODO:
                        // Read new price
                        // Call UpdateBookPrice()
                        int newPrice = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(newPrice);
                        break;

                    case 3:
                        // TODO:
                        // Read new stock
                        // Call UpdateBookStock()
                        int newStock = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(newStock);
                        break;

                    case 4:
                        Console.WriteLine("Thank You");
                        return;

                    default:
                        // TODO: Handle invalid choice
                        break;
                }
            }
        }
    }
}
