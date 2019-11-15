using System;
using System.Collections;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources;
using MainHost;
using XmlReaderWriter;

namespace XmlReaderWriterTests
{
    [TestClass]
    public class ReaderFromXmlTests
    {
        [TestMethod]
        public void ReadFromXml_PathToXmlFile_ListOfFilledObjectsReturn()
        {
            //arrange
            //DirectoryInfo projectDirectory = new DirectoryInfo(@"..\..");
            //var pathToResource = projectDirectory.FullName + @"\Resources\XMLSource.xml";
            string pathToResource = @"D:\Programming\CSharp\DotNetMentoringProgram\Module07\MainHost\Resources\XMLSource.xml";
            Book book = new Book() { Name = "War and Peace", Author = "Leo Tolstoy", PublishCity = "Moscow", PublisherName = "MosIzdat", YearOfPublish = 1873, NumberOfPages = 6854, Remark = "History of Russian Empire during the war with France", ISBN = "1324-765" };
            Newspaper newspaper = new Newspaper() { Name = "New York Times", PublishCity = "New York", PublisherName = "Arthur Ochs Sulzberger, Jr.", YearOfPublish = 2011, NumberOfPages = 44, Remark = "Weekly News", Number = 14375, Date = DateTime.Parse("10/16/2011"), ISSN = "4321-666" };
            Patent patent = new Patent() { Name = "Radio", Inventer = "William Crookes", Country = "United Kingdom", RegisterNumber = 186174, ApplyDate = DateTime.Parse("07/13/1873"), PublishDate = DateTime.Parse("11/22/1873"), NumberOfPages = 1713, Remark = "Technical documentation" };
            ArrayList expected = new ArrayList() { book, newspaper, patent };

            //act
            ArrayList actual = ReaderFromXml.ReadFromXml(pathToResource);
            bool result = expected == actual;

            //assert
            Assert.IsTrue(result);
        }
    }
}
