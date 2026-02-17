using System;
using Services;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagementService service = new ManagementService();

            while (true)
            {
                Console.WriteLine("1. Display");
                Console.WriteLine("2. Add");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Remove");
                Console.WriteLine("5. Exit");

                // TODO: Read user choice


                int choice = 0; // TODO
                choice = int.TryParse(Console.ReadLine(), out choice) ? choice : 0;

                switch (choice)
                {
                    case 1:
                        // TODO: Display data
                        foreach (var entity in service.GetAll())
                        {
                            Console.WriteLine(entity); // Assuming BaseEntity has a meaningful ToString() implementation
                        }
                        break;
                    case 2:
                        // TODO: Add entity
                            Console.WriteLine("Enter key:");
                            int key = 0;
                            Console.WriteLine("Enter entity details:"); 
                            key = int.TryParse(Console.ReadLine(), out key) ? key : 0;
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer key.");
                        }
                        break;
                    case 3:
                        // TODO: Update entity
                         Console.WriteLine("Enter key:");
                         int updateKey;
                         Console.WriteLine("Enter updated entity details:"); 
                            updateKey = int.TryParse(Console.ReadLine(), out updateKey) ? updateKey : 0;
                        break;
                    case 4:
                        // TODO: Remove entity
                            Console.WriteLine("Enter key:");
                            int removeKey;
                            Console.WriteLine("Enter entity details:");
                            removeKey = int.TryParse(Console.ReadLine(), out removeKey) ? removeKey : 0;
                        break;
                    case 5:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        // TODO: Handle invalid choice
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
