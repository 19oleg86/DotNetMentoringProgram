using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using CsQuery;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace SiteCopier
{
    public class Copier2 : ICopier
    {
        private static readonly HttpClient client;
        private string uri;
        private string _destination;
        string sccFinalFolder = string.Empty;
        string finalPath = string.Empty;

        static Copier2()
        {
            client = new HttpClient();
        }
        public Copier2(string path, string destination, string cssDestination/*, string imageDestination*/)
        {
            uri = path;
            _destination = destination;
            sccFinalFolder = cssDestination;
            //imageFinalFolder = imageDestination;
        }


        public async void SaveSiteCopyAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            HtmlDocument hap = new HtmlDocument();
            hap.LoadHtml(responseBody);

            File.WriteAllText(_destination + "index.html", responseBody);

            //HtmlNodeCollection linkNodes = hap.DocumentNode.SelectNodes("//a");
            //if (linkNodes != null)
            //{
            //    foreach (HtmlNode node in linkNodes)
            //    {
            //        if (!node.GetAttributeValue("href", null).StartsWith("https"))
            //        {
            //            HttpResponseMessage innerrResponse = await client.GetAsync(uri + node.GetAttributeValue("href", null));
            //            innerrResponse.EnsureSuccessStatusCode();
            //            string innerResponseBody = await innerrResponse.Content.ReadAsStringAsync();
            //            if (node.InnerText.Replace("/n", "").Trim() == "")
            //            {
            //                string innerText = node.GetAttributeValue("href", null);
            //                string newInnerText = innerText.Replace("/", "-");
            //                finalPath = $"{_destination}{newInnerText}.html";
            //            }
            //            else
            //            finalPath = $"{_destination}{node.InnerText.Replace("/n", "").Trim()}.html";
            //            File.WriteAllText(finalPath, innerResponseBody);
            //            finalPath = string.Empty;
            //        }
            //    }
            //}

            HtmlNodeCollection styleHeadNodes = hap.DocumentNode.SelectNodes("//head/link");
            if (styleHeadNodes != null)
            {
                WebClient webClient = new WebClient();
                foreach (HtmlNode node in styleHeadNodes)
                {
                    string fileName = string.Empty;
                    if (node.GetAttributeValue("href", null).StartsWith("/"))
                    {
                        fileName = node.GetAttributeValue("href", null).Substring(1);
                        HttpResponseMessage innerrResponse = await client.GetAsync(uri + fileName);
                        innerrResponse.EnsureSuccessStatusCode();
                        string innerResponseBody = await innerrResponse.Content.ReadAsStringAsync();
                        string newFileName = fileName.Replace("/", "-");
                        webClient.DownloadFile(uri + fileName, sccFinalFolder + newFileName);
                        //File.WriteAllText(sccFinalFolder + fileName, innerResponseBody);
                    }
                }
            }
                HtmlNodeCollection scriptHeadNodes = hap.DocumentNode.SelectNodes("//head/script");

            HtmlNodeCollection linkNodesCQ = hap.DocumentNode.SelectNodes(".//a");
            CQ cq = CQ.Create(uri);
            foreach (IDomObject obj in cq.Find("a"))
                Console.WriteLine(obj.GetAttribute("href"));
        }
    }
}
