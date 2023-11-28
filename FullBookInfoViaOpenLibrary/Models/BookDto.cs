namespace FullBookInfoViaOpenLibrary.Models
{
    public class BookDto
    {
        public int RowNumber { get; set; }
        public string DataRetrievalType { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string AuthorNames { get; set; }
        public int NumberOfPages { get; set; }
        public string PublishDate { get; set; }
    }
}
