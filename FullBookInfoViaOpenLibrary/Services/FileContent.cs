using FullBookInfoViaOpenLibrary.Models;

namespace FullBookInfoViaOpenLibrary.Services
{
    public static class FileContent
    {
        public static async Task<IEnumerable<BookDto>> ReadToEnd(string filePath)
        {
            List<BookDto> enumerable = new();
            int rowNumber = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        rowNumber++;
                        string line = await sr.ReadLineAsync();

                        string[] values = line.Split(',');

                        foreach (string value in values)
                        {
                            enumerable.Add(new()
                            {
                                RowNumber = rowNumber,
                                Isbn = value,
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
            return enumerable;
        }

        public static void createCsv(string headers, IEnumerable<BookDto> books, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(headers);

                foreach (var book in books)
                {
                    writer.WriteLine($"{book.RowNumber},{book.DataRetrievalType},{book.Isbn},{book.Title},{book.Subtitle},{book.AuthorNames},{book.NumberOfPages},{book.PublishDate}");
                }
            }
        }
    }
}
