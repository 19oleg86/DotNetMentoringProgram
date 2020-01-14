using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace BasicSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] listOfBooks = new Book[3];
            Book book1 = new Book("0-596-00103-7",
                                  "Löwy, Juval",
                                  "COM and .NET Component Services",
                                  Genre.Computer,
                                  "O'Reilly",
                                  DateTime.Now,
                                  "COM &amp; .NET Component Services provides both traditional COM programmers and new .NET component developers with the information they need to begin developing applications that take full advantage of COM + services. This book focuses on COM + services, including support for transactions, queued components, events, concurrency management, and security",
                                  DateTime.Now);
            Book book2 = new Book(null,
                                  "Ralls, Kim",
                                  "Midnight Rain",
                                  Genre.Fantasy,
                                  "R & D",
                                  DateTime.Now,
                                  "A former architect battles corporate zombies, an evil sorceress, and her own childhood to become queen of the world.",
                                  DateTime.Now);
            Book book3 = new Book(null,
                                  "Corets, Eva",
                                  "Maeve Ascendant",
                                  Genre.Fantasy,
                                  "R & D",
                                  DateTime.Now,
                                  "After the collapse of a nanotechnology society in England, the young survivors lay the foundation for a new society.",
                                  DateTime.Now);
            listOfBooks.SetValue(book1, 0);
            listOfBooks.SetValue(book2, 1);
            listOfBooks.SetValue(book3, 2);


            // Serializing object
            Catalog catalog = new Catalog(listOfBooks);

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

                for (int i = 0; i < desCatalog.innerArray.Length; i++)
                {
                    Console.WriteLine($"Desirialized Object is:\n ISBN: {desCatalog.innerArray[i].Isbn},\n Author: {desCatalog.innerArray[i].Author},\n Title: {desCatalog.innerArray[i].Title},\n Genre: {desCatalog.innerArray[i].Genre},\n Publisher: {desCatalog.innerArray[i].Publisher},\n " +
                $"Publish Date: {desCatalog.innerArray[i].PublishDate},\n Description: {desCatalog.innerArray[i].Description},\n Registration Date: {desCatalog.innerArray[i].RegistrationDate}");
                }
            }

            Console.ReadLine();
        }
    }

    [XmlRoot("Catalog", Namespace = "http://library.by/catalog")]
    [Serializable]
    public class Catalog
    {
        public Book book1;
        public Book book2;
        public Book book3;
        public Book[] innerArray = new Book[3];
        
        public Catalog()
        {
        }

        public Catalog(Book[] books)
        {
            innerArray.SetValue(books[0], 0);
            innerArray.SetValue(books[1], 1);
            innerArray.SetValue(books[2], 2);
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
