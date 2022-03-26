using GIPHY_API.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GIPHY_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIKey"];
            string query = "funny cats";
            string offset = "0";
            //create the request to the API
            WebRequest request = WebRequest.Create("https://api.giphy.com/v1/gifs/search?q="+query+"&api_key="+apiKey+"&offset="+offset);
            //Send that request off
            WebResponse response = request.GetResponse();
            //Getb back the response stream
            Stream stream = response.GetResponseStream();
            // make it accessible
            StreamReader reader = new StreamReader(stream);
            //Put into string which is JSON formatted
            string responseFromServer = reader.ReadToEnd();
            JObject parsedString = JObject.Parse(responseFromServer);
            Gif MyGifs = parsedString.ToObject<Gif>();

           
            //Debug.WriteLine(myPokemon.moves[0].move.version_group_details);

            
            return View(MyGifs);
        }

       
    }
}