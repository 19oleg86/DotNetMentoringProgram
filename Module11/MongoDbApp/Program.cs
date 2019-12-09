using System;
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
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("library");
            var collection = database.GetCollection<BsonDocument>("books");

            Console.WriteLine("Task 1 - Adding data to Database...");
            SaveDocs(collection).GetAwaiter().GetResult();
            Console.WriteLine("Data added to Database");
            Console.WriteLine();

            Console.WriteLine("Display all documents: ");
            DisplayDocs(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 2 - Books with count more than 1:");
            FindBooksMoreThanOne(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 3 - Books with Maximum and Minimum Count values:");
            FindBooksWithMaxAndMinCount(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 4 - All authors (without duplicates):");
            FindAllAuthorsOnce(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 5 - All books without authors:");
            FindAllBooksWithoutAuthors(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 6 - Change each book count on 1:");
            ChangeEachBookCountOnOne(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 7 - Add additional genre Favority where Fantasy exists");
            AddAdditionalGenreWhereFantasy(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Task 8 - Delete books where count is less than 3");
            DeleteBooksWhereCountLessThanThree(collection).GetAwaiter().GetResult();
            Console.WriteLine();

            Console.WriteLine("Press Enter to clear the database (Task 9 - Delete all documents)");
            Console.ReadLine();
            DeleteBooks(collection).GetAwaiter().GetResult();
        }

        private static async Task SaveDocs(IMongoCollection<BsonDocument> collection)
        {
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

        private static async Task DisplayDocs(IMongoCollection<BsonDocument> collection)
        {
            var filter = new BsonDocument();
            var books = await collection.Find(filter).ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task FindBooksMoreThanOne(IMongoCollection<BsonDocument> collection)
        {
            var filter = new BsonDocument("Count", new BsonDocument("$gt", 1));
            var books = await collection.Find(filter).Sort("{Name:1}").Limit(3).Project("{Name:1, _id:0}").ToListAsync();
            foreach (var doc in books)
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine($"Number of books: {books.Count}");
        }

        private static async Task FindBooksWithMaxAndMinCount(IMongoCollection<BsonDocument> collection)
        {
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

        private static async Task FindAllAuthorsOnce(IMongoCollection<BsonDocument> collection)
        {
            var filter = new BsonDocument();
            var books = await collection.Find(filter).Project("{Author:1, _id:0}").ToListAsync();
            var fiteredBooks = books.Distinct();
            foreach (var doc in fiteredBooks)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task FindAllBooksWithoutAuthors(IMongoCollection<BsonDocument> collection)
        {
            var filter = new BsonDocument("Author", "");
            var books = await collection.Find(filter).Project("{_id:0}").ToListAsync();
            var fiteredBooks = books.Distinct();
            foreach (var doc in fiteredBooks)
            {
                Console.WriteLine(doc);
            }
        }

        private static async Task ChangeEachBookCountOnOne(IMongoCollection<BsonDocument> collection)
        {
            var books = await collection.UpdateManyAsync(new BsonDocument(), new BsonDocument("$inc", new BsonDocument("Count", 1)));
            Console.WriteLine("Display all documents:");
            DisplayDocs(collection).GetAwaiter().GetResult();
            Console.WriteLine();
        }

        private static async Task AddAdditionalGenreWhereFantasy(IMongoCollection<BsonDocument> collection)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Genre", "Fantasy");
            var update = Builders<BsonDocument>.Update.AddToSet("Genre", "Favority");
            var books = await collection.UpdateManyAsync(filter, update);
            Console.WriteLine("Display all documents:");
            DisplayDocs(collection).GetAwaiter().GetResult();
            Console.WriteLine();
        }

        private static async Task DeleteBooksWhereCountLessThanThree(IMongoCollection<BsonDocument> collection)
        {
            var filter = Builders<BsonDocument>.Filter.Lt("Count", 3);
            await collection.DeleteManyAsync(filter);
            Console.WriteLine("Display all documents:");
            DisplayDocs(collection).GetAwaiter().GetResult();
            Console.WriteLine();
        }

        private static async Task DeleteBooks(IMongoCollection<BsonDocument> collection)
        {
            var filter = new BsonDocument();
            await collection.DeleteManyAsync(filter);
        }
    }
}
