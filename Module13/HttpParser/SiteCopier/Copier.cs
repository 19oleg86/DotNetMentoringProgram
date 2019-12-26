using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using CsQuery;

namespace SiteCopier
{
    public class Copier
    {
        private static readonly HttpClient client;
        string address = string.Empty;
        string passToSaveSite = string.Empty;
        string passToSaveFiles = string.Empty;
        string imageFinalFolder;

        static Copier()
        {
            client = new HttpClient();
        }
        public Copier(string address, string passToSaveSite, string passToSaveFiles)
        {
            this.address = address;
            this.passToSaveSite = passToSaveSite;
            this.passToSaveFiles = passToSaveFiles;
        }
        public async void SaveSiteCopy()
        {
            //HttpResponseMessage response = await client.GetAsync(address);
            //response.EnsureSuccessStatusCode();
            //string responseBody = await response.Content.ReadAsStringAsync();

            //string responseBodyUTF = responseBody.Replace("windows-1251", "utf-8");

            //File.WriteAllText(passToSaveSite + "index.html", responseBodyUTF);

            //HtmlDocument hap = new HtmlDocument();
            //hap.LoadHtml(responseBody);

            ////collecting css
            CQ cq = CQ.CreateFromUrl(address);
            //var cssHrefs = cq["link[rel=stylesheet]"].Select(q => q.GetAttribute("href")).ToArray();
            WebClient webClient = new WebClient();
            //for (int i = 0; i < cssHrefs.Length; i++)
            //{
            //    if (!cssHrefs[i].StartsWith("//"))
            //    {
            //        webClient.DownloadFile(cssHrefs[i], passToSaveFiles + "style.css");
            //    }
            //}

            //collecting images
            //cq = CQ.CreateFromUrl(address);
            var images = cq.Find("//body/div/img").Select(q => q.GetAttribute("src")).ToArray();
            for (int i = 0; i < images.Length; i++)
            {
                if (!images[i].StartsWith("//"))
                {
                    imageFinalFolder = passToSaveFiles + images[i];
                    webClient.DownloadFile(images[i], imageFinalFolder);
                }
            }


        }
    }
}
