﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace MongoDbApp
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            MongoClient client = new MongoClient(connectionString);

            Console.WriteLine("Adding data to Database...");
            SaveDocs().GetAwaiter().GetResult();
            Console.WriteLine("Data added to Database");

            Console.WriteLine();

            Console.WriteLine("Display all documents: ");
            DisplayDocs().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Books with count more than 1:");
            FindBooksMoreThanOne().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Books with Maximum and Minimum Count values:");
            FindBooksWithMaxAndMinCount().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("All authors (without duplicates):");
            FindAllAuthorsOnce().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("All books without authors:");
            FindAllBooksWithoutAuthors().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Change each book count on 1:");
            ChangeEachBookCountOnOne().GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Press Enter to clear the database");
            Console.ReadLine();
            DeleteBooks().GetAwaiter().GetResult();
        }

        private static async Task ChangeEachBookCountOnOne()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var books = await collection.UpdateManyAsync(new BsonDocument(), new BsonDocument("$inc", new BsonDocument("Count", 1)));
            Console.WriteLine("Display all documents:");
            DisplayDocs().GetAwaiter().GetResult();
            Console.WriteLine();

        }

        private static async Task FindAllBooksWithoutAuthors()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var filter = new BsonDocument("Author", "");
            var books = await collection.Find(filter).Project("{_id:0}").ToListAsync();
            var fiteredBooks = books.Distinct();
            foreach (var doc in fiteredBooks)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task FindAllAuthorsOnce()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var filter = new BsonDocument();
            var books = await collection.Find(filter).Project("{Author:1, _id:0}").ToListAsync();
            var fiteredBooks = books.Distinct();
            foreach (var doc in fiteredBooks)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task FindBooksWithMaxAndMinCount()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var filter = new BsonDocument();
            var books = await collection.Find(filter).Sort("{Count:-1}").Limit(1).Project("{_id:0}").ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine("Book with Maximum of Count: " + doc);
            }
            books = await collection.Find(filter).Sort("{Count:1}").Limit(1).Project("{_id:0}").ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine("Book with Minimum of Count: " + doc);
            }
        }

        private static async Task FindBooksMoreThanOne()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var filter = new BsonDocument("Count", new BsonDocument("$gt", 1));
            var books = await collection.Find(filter).Sort("{Name:1}").Limit(3).Project("{Name:1, _id:0}").ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine($"Number of books: {books.Count}"); 
        }

        private static async Task DeleteBooks()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");

            var filter = new BsonDocument();
            await collection.DeleteManyAsync(filter);
        }

        private static async Task DisplayDocs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            var filter = new BsonDocument();
            var books = await collection.Find(filter).ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task SaveDocs()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");
            BsonDocument book1 = new BsonDocument
            {
                {"Name", "Hobbit"},
                {"Author", "Tolkien"},
                {"Count", 5},
                {"Genre", new BsonArray(new []{"Fantasy"})},
                {"Year", 2014}
            };
            BsonDocument book2 = new BsonDocument
            {
                {"Name", "Lord of the Rings"},
                {"Author", "Tolkien"},
                {"Count", 3},
                {"Genre", new BsonArray(new []{"Fantasy"})},
                {"Year", 2015}
            };
            BsonDocument book3 = new BsonDocument
            {
                {"Name", "Kolobok"},
                {"Author", ""},
                {"Count", 10},
                {"Genre", new BsonArray(new []{"Kids"})},
                {"Year", 2000}
            };
            BsonDocument book4 = new BsonDocument
            {
                {"Name", "Repka"},
                {"Author", ""},
                {"Count", 11},
                {"Genre", new BsonArray(new []{"Kids"})},
                {"Year", 2000}
            };
            BsonDocument book5 = new BsonDocument
            {
                {"Name", "Dyadya Stiopa"},
                {"Author", "Mihalkov"},
                {"Count", 1},
                {"Genre", new BsonArray(new []{"Kids"})},
                {"Year", 2001}
            };
            await collection.InsertManyAsync(new[] { book1, book2, book3, book4, book5 });
        }
    }
}
