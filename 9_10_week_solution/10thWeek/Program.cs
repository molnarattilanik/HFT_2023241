using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;

namespace _10thWeek
{
    class Marvel
    {

        public string Name { get; set; }
        public string Actor { get; set; }

        public string RealName { get; set; }

        public string Species { get; set; }
        public string CitizenShip { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Affiliations { get; set; }
        public List<string> Appearances { get; set; }

        public string Image { get; set; }

        public Marvel()
        {
            Affiliations = new List<string>(); ;
            Appearances = new List<string>();
        }


    }
    class Book
    {
        public string Category { get; set; }
        public string Title { get; set; }

        public string Language { get; set; }

        public string Author { get; set; }
        public bool Isin { get; set; }
        public int DaysUntilReturn { get; set; }
        public double Price { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var xdoc = XDocument.Load("book.xml");
            List<Book> books = new List<Book>();
            foreach (var x in xdoc.Descendants("category"))
            {
                foreach (var book in x.Descendants("book"))
                {
                    Book temp = new Book();
                    temp.Category = x.Attribute("name").Value;
                    temp.Language = book.Element("title").Attribute("lang").Value;
                    temp.Title = book.Element("title").Value;
                    temp.Author = book.Element("author").Value;
                    if (book.Element("isin").Value == "true")
                    {
                        temp.Isin = true;
                    }
                    else { temp.Isin = false; }
                    temp.DaysUntilReturn = int.Parse(book.Element("daysuntilreturn").Value);
                    temp.Price = double.Parse(book.Element("price").Value, CultureInfo.InvariantCulture);
                    books.Add(temp);
                }
            }



            string json = File.ReadAllText("marvel.json");
            var list =
             JsonConvert.DeserializeObject<List<Marvel>>(json);

            ;
        }
    }
}
