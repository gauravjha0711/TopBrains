using System;
public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public bool IsAvailable { get; set; }
}

// Generic catalog class
public class Catalog<T> where T : Book
{
    private List<T> items = new List<T>();
    private HashSet<string> isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> genreIndex = new SortedDictionary<string, List<T>>();
    
    // Add item with genre indexing
    public bool AddItem(T item)
    {
        // TODO: Check ISBN uniqueness, add to list and genre index
        // ISBN uniqueness check
        if (isbnSet.Contains(item.ISBN))
        {
            return false;
        }
        items.Add(item);
        isbnSet.Add(item.ISBN);

        // Genre indexing
        if (!genreIndex.ContainsKey(item.Genre))
        {
            genreIndex[item.Genre] = new List<T>();
        }

        genreIndex[item.Genre].Add(item);
        return true;
    }
    
    // Get books by genre using indexer
    public List<T> this[string genre]
    {
        get
        {
            // TODO: Return books by genre or empty list
            if (genreIndex.ContainsKey(genre))
            {
                return genreIndex[genre];
            }
            return new List<T>(); // empty list if genre not found
        }
    }
    
    // Find books using LINQ and lambda expressions
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        // TODO: Use LINQ Where with predicate
        return items.Where(predicate);
    }
}

public class Program
{
    public static void Main()
    {
        Catalog<Book> library = new Catalog<Book>();

        Book book1 = new Book 
        { 
            ISBN = "978-3-16-148410-0", 
            Title = "C# Programming", 
            Author = "John Sharp", 
            Genre = "Programming" 
        };

        library.AddItem(book1);

        var programmingBooks = library["Programming"];
        Console.WriteLine(programmingBooks.Count); // Should output: 1

        var johnsBooks = library.FindBooks(b => b.Author.Contains("John"));
        Console.WriteLine(johnsBooks.Count()); // Should output: 1

    }
}