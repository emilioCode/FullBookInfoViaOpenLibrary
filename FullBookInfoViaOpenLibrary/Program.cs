using FullBookInfoViaOpenLibrary.Models;
using FullBookInfoViaOpenLibrary.Services;

Console.Write("Please write the filePath here: ");
string filePath = "C:\\Users\\Owner\\Desktop\\ISBN_Input_File.txt";// Console.ReadLine();
Console.WriteLine(filePath);
string outFilepath = Path.Combine(Path.GetTempPath(), "IBSN_results.csv"); // ..\AppData\Local\Temp\IBSN_results.csv

var books = await FileContent.ReadToEnd(filePath);

const string Server = "Server";
const string Cache = "Cache";
const char Comma = ',';
const char Space = ' ';
const char Dot = '.';

foreach (var book in books)
{
    var memoryBook = books.Where(b => b.Isbn == book.Isbn && b.Title != null).FirstOrDefault();
    var RetrievalType = memoryBook is not null ? Cache : Server;
    if (RetrievalType == Server)
    {
        var data = await HttpService<Book>.Get($"https://openlibrary.org/isbn/{book.Isbn}.json");
        var contributions = data.Contributions is not null ? string.Join(";", data.Contributions) : string.Empty;
        while (contributions.Contains(Comma))
        {
            contributions = contributions.Replace(Comma, Space);
        }
        book.Title = data.Title;
        book.Subtitle = data.Subtitle;
        book.PublishDate = data.PublishDate.Replace(Comma, Dot);
        book.NumberOfPages = data.NumberOfPages;
        book.AuthorNames = contributions;
        book.DataRetrievalType = RetrievalType;
    }
    else
    {
        book.Title = memoryBook.Title;
        book.Subtitle = memoryBook.Subtitle;
        book.PublishDate = memoryBook.PublishDate;
        book.NumberOfPages = memoryBook.NumberOfPages;
        book.AuthorNames = memoryBook.AuthorNames;
        book.DataRetrievalType = RetrievalType;
    }
}

FileContent.createCsv(@"Row Number,Data Retreival Type,ISBN,Title,Subtitlem,Authos Name(s),Number of Pages,Publish Date", books, outFilepath);
Console.WriteLine("Complete!!");
Console.WriteLine($"Ouput path: {outFilepath}");

