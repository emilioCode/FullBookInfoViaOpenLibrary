using FullBookInfoViaOpenLibrary.Models;
using FullBookInfoViaOpenLibrary.Services;

Console.Write("Please write the filePath here: ");
string filePath = "C:\\Users\\Owner\\Desktop\\ISBN_Input_File.txt";// Console.ReadLine();

string outFilepath = Path.Combine(Path.GetTempPath(), "IBSN_results.csv"); // ..\AppData\Local\Temp\IBSN_results.csv

var books = await FileContent.ReadToEnd(filePath);

foreach (var book in books)
{
    var RetrievalType = books.Where(b => b.Isbn == book.Isbn && b.Title != null).Count() > 0 ? "Cache": "Server";
    var data = await HttpService<Book>.Get($"https://openlibrary.org/isbn/{book.Isbn}.json");
    var contributions = data.Contributions is not null ? string.Join(";", data.Contributions) : "";
    while (contributions.Contains(','))
    {
        contributions = contributions.Replace(',', ' ');
    }
    book.Title = data.Title;
    book.Subtitle = data.Subtitle;
    book.PublishDate = data.PublishDate.Replace(',','.');
    book.NumberOfPages = data.NumberOfPages;
    book.AuthorNames = contributions;
    book.DataRetrievalType = RetrievalType;
}

FileContent.createCsv(@"Row Number, Data Retreival Type,ISBN,Title,Subtitlem,Authos Name(s),Number of Pages,Publish Date", books, outFilepath);

Console.WriteLine("Finished!!");

