using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Io;
using ZeeKer.DndTracker.DndSu.Entities;

namespace ZeeKer.DndTracker.DndSu.Parsers
{
    public abstract class DndsuParser
    {
        protected const string baseUrl = "https://dnd.su";
        protected string spellsUrl => $"{baseUrl}/spells/";

        protected readonly HttpClient client;

        protected readonly IBrowsingContext context;
        public DndsuParser()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
            client.DefaultRequestHeaders.Add("Referer", "https://www.google.com/");
            client.DefaultRequestHeaders.Add("Viewport-Width", "1920");
            client.DefaultRequestHeaders.Add("Width", "1920");
            client.DefaultRequestHeaders.Add("Dpr", "1");
            client.DefaultRequestHeaders.Add("Device-Memory", "8");

            var config = Configuration.Default.WithDefaultLoader();
            context = BrowsingContext.New(config);
        } 
    }
}
