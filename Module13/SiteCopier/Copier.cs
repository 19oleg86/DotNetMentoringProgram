using System;
using System.Linq;
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
        string imageAddress = string.Empty;
        string imageFinalFolder = string.Empty;

        static Copier()
        {
            client = new HttpClient();
        }
        public Copier(string path, string destination, string cssDestination, string imageDestination)
        {
            uri = path;
            _destination = destination;
            sccFinalFolder = cssDestination;
            imageFinalFolder = imageDestination;
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

                //collecting all css
                CQ cq = CQ.CreateFromUrl(uri);
                var cssHrefs = cq["link[rel=stylesheet]"].Select(q => q.GetAttribute("href")).ToArray();
                WebClient webClient = new WebClient();
                sccFinalFolder += @"style.css";
                for (int i = 0; i < cssHrefs.Length; i++)
                {
                    cssAddress = uri + @"/";
                    cssAddress += cssHrefs[i];
                    webClient.DownloadFile(cssAddress, sccFinalFolder);
                    cssAddress = string.Empty;
                }

                //collecting all images
                cq = CQ.CreateFromUrl(uri);
                var images = cq.Find("img").Select(q => q.GetAttribute("src")).ToArray();
                for (int i = 0; i < images.Length; i++)
                {
                    imageAddress = uri + @"/";
                    if (images[i].StartsWith("/"))
                        images[i] = images[i].Substring(1);
                    imageAddress += images[i];
                    imageFinalFolder += images[i];
                    if (imageFinalFolder.Contains("/"))
                        imageFinalFolder = imageFinalFolder.Replace("/", "-");
                    webClient.DownloadFile(imageAddress, imageFinalFolder);
                    imageAddress = string.Empty;
                }

                //collecting all URLs
                HtmlNodeCollection linkNodes = hap.DocumentNode.SelectNodes("//a");
                if (linkNodes != null)
                {
                    foreach (HtmlNode node in linkNodes)
                    {
                        if (!node.InnerText.Contains("\n"))
                        {
                            if (node.OuterHtml.Contains("href=\"/"))
                            {
                                HttpResponseMessage innerrResponse = await client.GetAsync(uri + node.GetAttributeValue("href", null));
                                innerrResponse.EnsureSuccessStatusCode();
                                string innerResponseBody = await innerrResponse.Content.ReadAsStringAsync();
                                finalPath = $"{_destination}{node.InnerText}.html";
                                File.WriteAllText(finalPath, innerResponseBody);
                                finalPath = string.Empty;
                            }
                        }
                    }
                } 
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
