using Dapper;
using lesson2Dapper.Model;
using System.Data.SqlClient;

var conStr = "Data Source=DESKTOP-VKCKL67\\MSSQLSERVER02;Initial Catalog=Employees;Integrated Security=true"; // for windows auth
using var sqlConnection = new SqlConnection(conStr);

var query = "SELECT Books.Name,Categories.Name FROM Books JOIN Categories ON Books.Id_Category=Categories.Id";

//var BooksWithCategory = sqlConnection.Query(query);
//var books = sqlConnection.Query<Category, Book, Book>(query,
//    map: (Category, Book) =>
//    {
//        Book.Category = Category;
//        return Book;
//    },
//    splitOn: "Id").ToList();
 
//foreach (var book in books)
//    Console.WriteLine($"{book.Name}-{book.Category.name}");
//Console.WriteLine();

//var CategoryDict = new Dictionary<int, Category>();
//var BooksWithCategory = sqlConnection.Query(query);
//var books = sqlConnection.Query<Category, Book, Category>(query,
//    map: (Category, Book) =>
//    {
//        Book.Category = Category;
//        return Category;
//    },
//    splitOn: "Id").ToList();

//foreach (var book in books)
   // Console.WriteLine($"{book.Name}-{book.Category.name}");

var CategoryDict = new Dictionary<int, Category>();

var BooksWithCategory = sqlConnection.Query<Book, Category, Category>(query,
    map:
    (book, category) => {
        if (!CategoryDict.TryGetValue(category.id, out Category currentCateg))
        {
            currentCateg = category;
            CategoryDict.Add(category.id, currentCateg);
        }
        book.Category = currentCateg;
        currentCateg.Books.Add(book);
        return currentCateg;
    },
    splitOn: "Id"
    );