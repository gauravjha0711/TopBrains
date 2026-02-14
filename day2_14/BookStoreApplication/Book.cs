using System;
using System.Net;

namespace BookStoreApplication
{
    public class Book
    {
        // TODO: Create public properties
        // Id -> string
        // Title -> string
        // Author -> string (Optional)
        // Price -> int
        // Stock -> int

        public string Id { get; set; }
        public string Title { get; set; }
        public string  Author { get; set; }=string.Empty;
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
