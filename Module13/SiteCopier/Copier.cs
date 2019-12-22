using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.IO;
using CsQuery;
using System.Net;

namespace SiteCopier
{
    public class Copier : ICopier
    {
        private string uri;
        private string _destination;
        private static readonly HttpClient client;
        string finalPath = string.Empty;
        string cssAddress = string.Empty;
        string sccFinalFolder = string.Empty;
        static Copier()
        {
            client = new HttpClient();
        }
        public Copier(string path, string destination, string cssDestination)
        {
            uri = path;
            _destination = destination;
            sccFinalFolder = cssDestination;
        }
        public async void SaveSiteCopy()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                HtmlDocument hap = new HtmlDocument();
                hap.LoadHtml(responseBody);

                CQ cq = CQ.CreateFromUrl(uri);
                var cssHrefs = cq["link[rel=stylesheet]"].Select(q => q.GetAttribute("href")).ToArray();
                WebClient webClient = new WebClient();
                sccFinalFolder += @"style.css";
                for (int i = 0; i < cssHrefs.Length; i++)
                {
                    cssAddress = uri += cssHrefs[i];
                    webClient.DownloadFile(cssAddress, sccFinalFolder);
                }

                HtmlNodeCollection linkNodes = hap.DocumentNode.SelectNodes("//a");
                if (linkNodes != null)
                    foreach (HtmlNode node in linkNodes)
                    {
                        if (!node.InnerText.Contains("\n"))
                        { 
                            finalPath = $"{_destination}{node.InnerText}.html"; 
                            File.WriteAllText(finalPath, node.OuterHtml);
                            finalPath = string.Empty;
                        }
                    }

                //Console.WriteLine(node.GetAttributeValue("href", null));
                //File.WriteAllText(_destination + "res.html", responseBody);
                //Console.WriteLine(responseBody);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
