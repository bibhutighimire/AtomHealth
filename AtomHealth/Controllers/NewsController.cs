using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using Newtonsoft.Json;
using static AtomHealth.Models.News;

namespace AtomHealth.Controllers
{
    public class NewsController : Controller
    {
        public async Task<IActionResult> Index()
        {

            string url = string.Format("http://newsapi.org/v2/top-headlines?country=ca&category=health&apiKey=9c3bc0733617451fbff5f91e151dbd87");


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var jsonstring = JsonConvert.DeserializeObject<Example>(json);

                var a = jsonstring.articles;

                return View(a);
            }


        }
    }
}
