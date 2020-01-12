using System;
using System.IO;
using System.Xml.Serialization;

namespace BasicSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serializing object
            Catalog catalog = new Catalog(new Book("0-596-00103-7",
                                                   "Löwy, Juval",
                                                   "COM and .NET Component Services",
                                                   Genre.Computer,
                                                   "O'Reilly",
                                                   DateTime.Now,
                                                   "COM &amp; .NET Component Services provides both traditional COM programmers and new .NET component developers with the information they need to begin developing applications that take full advantage of COM + services. This book focuses on COM + services, including support for transactions, queued components, events, concurrency management, and security",
                                                   DateTime.Now));

            Console.WriteLine("Object is Created");
            Console.WriteLine();

            XmlSerializer formatter = new XmlSerializer(typeof(Catalog));

            using (FileStream fs = new FileStream("outputXmlBooks.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, catalog);

                Console.WriteLine(@"Object is serialized (check outputXmlBooks.xml file in bin\Debug directory)");
                Console.WriteLine();
            }

            // Deserializing object
            using (FileStream fs = new FileStream("outputXmlBooks.xml", FileMode.OpenOrCreate))
            {
                Catalog desCatalog = (Catalog)formatter.Deserialize(fs);

                Console.WriteLine("Object is Deserialized");
                Console.WriteLine();

                Console.WriteLine($"Desirialized Object is:\n ISBN: {desCatalog.book.Isbn},\n Author: {desCatalog.book.Author},\n Title: {desCatalog.book.Title},\n Genre: {desCatalog.book.Genre},\n Publisher: {desCatalog.book.Publisher},\n " +
                    $"Publish Date: {desCatalog.book.PublishDate},\n Description: {desCatalog.book.Description},\n Registration Date: {desCatalog.book.RegistrationDate}");
            }

            Console.ReadLine();
        }
    }

    [XmlRoot("Catalog", Namespace = "http://library.by/catalog")]
    [Serializable]
    public class Catalog
    {
        public Book book;
        public Catalog()
        {
        }

        public Catalog(Book book)
        {
            this.book = book;
        }
    }

    [Serializable]
    public class Book
    {
        public string Catalog { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Book()
        {
        }

        public Book(string isbn, string author, string title, Genre genre, string publisher, DateTime publishDate, string description, DateTime registrationDate)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Genre = genre;
            Publisher = publisher;
            PublishDate = publishDate;
            Description = description;
            RegistrationDate = registrationDate;
        }
    }

    public enum Genre 
    {
        Computer,
        Fantasy,
        Romance,
        Horror,
        ScienceFiction
    }
}
