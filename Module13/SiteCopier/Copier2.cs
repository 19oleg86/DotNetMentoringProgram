using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using CsQuery;
using System.Text;
using System.Threading.Tasks;

namespace SiteCopier
{
    public class Copier2 : ICopier
    {
        private static readonly HttpClient client;
        private string uri;
        private string _destination;

        static Copier2()
        {
            client = new HttpClient();
        }
        public Copier2(string path, string destination/*, string cssDestination, string imageDestination*/)
        {
            uri = path;
            _destination = destination;
            //sccFinalFolder = cssDestination;
            //imageFinalFolder = imageDestination;
        }
        

        public  async void SaveSiteCopyAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            
            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(responseBody);
            
            HtmlNodeCollection linkNodes = hap.DocumentNode.SelectNodes("//a");


            

            HtmlNodeCollection linkNodesCQ = hap.DocumentNode.SelectNodes(".//a");
            CQ cq = CQ.Create(uri);
            foreach (IDomObject obj in cq.Find("a"))
                Console.WriteLine(obj.GetAttribute("href"));
        }
    }
}
