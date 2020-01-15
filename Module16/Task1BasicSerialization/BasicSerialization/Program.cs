using System;
using System.IO;
using System.Xml.Serialization;

namespace BasicSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("bk101", 
                                  "0-596-00103-7",
                                  "Löwy, Juval",
                                  "COM and .NET Component Services",
                                  Genre.Computer,
                                  "O'Reilly",
                                  DateTime.Now,
                                  "COM &amp; .NET Component Services provides both traditional COM programmers and new .NET component developers with the information they need to begin developing applications that take full advantage of COM + services. This book focuses on COM + services, including support for transactions, queued components, events, concurrency management, and security",
                                  DateTime.Now);
            Book book2 = new Book("bk102", 
                                   null,
                                  "Ralls, Kim",
                                  "Midnight Rain",
                                  Genre.Fantasy,
                                  "R & D",
                                  DateTime.Now,
                                  "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world.",
                                  DateTime.Now);
            Book book3 = new Book("bk103", 
                                   null,
                                  "Corets, Eva",
                                  "Maeve Ascendant",
                                  Genre.Fantasy,
                                  "R & D",
                                  DateTime.Now,
                                  "After the collapse of a nanotechnology society in England, the young survivors lay the foundation for a new society.",
                                  DateTime.Now);
            Book[] book = new Book[] { book1, book2, book3 };


            // Serializing object
            Catalog catalog = new Catalog();
            catalog.book = new Book[] { book1, book2, book3 };
            
            Console.WriteLine("Object is Created");
            Console.WriteLine();

            XmlSerializer formatter = new XmlSerializer(typeof(Catalog));

            using (FileStream fs = new FileStream("outputXmlBooks.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, catalog);

                Console.WriteLine(@"Object is serialized (check outputXmlBooks.xml file in bin\Debug directory)");
                Console.WriteLine();
            }

            //Deserializing object
            using (FileStream fs = new FileStream("outputXmlBooks.xml", FileMode.OpenOrCreate))
            {
                Catalog desCatalog = (Catalog)formatter.Deserialize(fs);

                Console.WriteLine("Object is Deserialized");
                Console.WriteLine();

                for (int i = 0; i < catalog.book.Length; i++)
                {
                    Console.WriteLine($"Desirialized Object is:\n ISBN: {catalog.book[i].Isbn},\n Author: {catalog.book[i].Author},\n Title: {catalog.book[i].Title},\n Genre: {catalog.book[i].Genre},\n Publisher: {catalog.book[i].Publisher},\n " +
                $"Publish Date: {catalog.book[i].PublishDate},\n Description: {catalog.book[i].Description},\n Registration Date: {catalog.book[i].RegistrationDate}");
                }
            }

            Console.ReadLine();
        }
    }

    public class Catalog
    {
        [XmlElement]
        public Book[] book = new Book[3];

        public Catalog()
        {
        }
    }

    [Serializable]
    public class Book
    {
        [XmlAttribute]
        public string id { get; set; }
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

        public Book(string id, string isbn, string author, string title, Genre genre, string publisher, DateTime publishDate, string description, DateTime registrationDate)
        {
            this.id = id;
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
