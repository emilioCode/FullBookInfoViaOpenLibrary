using System.Text.Json.Serialization;

namespace FullBookInfoViaOpenLibrary.Models
{
    public class Book
    {
        [JsonPropertyName("publishers")]
        public List<string> Publishers { get; set; }
        [JsonPropertyName("number_of_pages")]
        public int NumberOfPages { get; set; }
        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }
        [JsonPropertyName("isbn_10")]
        public List<string> Isbn10 { get; set; }
        [JsonPropertyName("covers")]
        public List<int> Covers { get; set; }
        [JsonPropertyName("lc_classifications")]
        public List<string> LcClassifications { get; set; }
        [JsonPropertyName("latest_revision")]
        public int LatestRevision { get; set; }
        [JsonPropertyName("key")]
        public string Key { get; set; }
        [JsonPropertyName("authors")]
        public List<Author> Authors { get; set; }
        [JsonPropertyName("ocaid")]
        public string Ocaid { get; set; }
        [JsonPropertyName("publish_places")]
        public List<string> PublishPlaces { get; set; }
        [JsonPropertyName("contributions")]
        public List<string> Contributions { get; set; }
        [JsonPropertyName("subjects")]
        public List<string> Subjects { get; set; }
        [JsonPropertyName("languages")]
        public List<Language> Languages { get; set; }
        [JsonPropertyName("pagination")]
        public string Pagination { get; set; }
        [JsonPropertyName("source_records")]
        public List<string> SourceRecords { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("dewey_decimal_class")]
        public List<string> DeweyDecimalClass { get; set; }
        [JsonPropertyName("notes")]
        public Note Notes { get; set; }
        [JsonPropertyName("identifiers")]
        public Identifiers Identifiers { get; set; }
        [JsonPropertyName("created")]
        public CustomDate Created { get; set; }
        [JsonPropertyName("edition_name")]
        public string EditionName { get; set; }
        [JsonPropertyName("lccn")]
        public List<string> Lccn { get; set; }
        [JsonPropertyName("local_id")]
        public List<string> LocalId { get; set; }
        [JsonPropertyName("publish_date")]
        public string PublishDate { get; set; }
        [JsonPropertyName("publish_country")]
        public string PublishCountry { get; set; }
        [JsonPropertyName("last_modified")]
        public CustomDate LastModified { get; set; }
        [JsonPropertyName("by_statement")]
        public string ByStatement { get; set; }
        [JsonPropertyName("works")]
        public List<Work> Works { get; set; }
        [JsonPropertyName("type")]
        public Type Type { get; set; }
        [JsonPropertyName("revision")]
        public int Revision { get; set; }
    }

    public class Author
    {
        public string Key { get; set; }
    }

    public class Language
    {
        public string Key { get; set; }
    }

    public class Note
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Identifiers
    {
        public List<string> Librarything { get; set; }
        public List<string> Wikidata { get; set; }
        public List<string> Goodreads { get; set; }
    }

    public class Work
    {
        public string Key { get; set; }
    }

    public class Type
    {
        public string Key { get; set; }
    }

}
