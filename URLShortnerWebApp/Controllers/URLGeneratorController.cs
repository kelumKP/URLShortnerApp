using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using URLShortnerWebApp.Models;

namespace URLShortnerWebApp.Controllers
{
    public class URLGeneratorController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:51184";

        // GET: URLGenerator
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GenerateShortenUrl(URLShortenViewModel reqInfo)
        {
            URLShortenViewModel urlRquestInfo = new URLShortenViewModel();


            if (ModelState.IsValid)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        //Passing service base url  
                        client.BaseAddress = new Uri(Baseurl);

                        client.DefaultRequestHeaders.Clear();
                        //Define request data format  
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.GetAsync("api/URLGenerate?longUrl=" + reqInfo.longURL);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var URLShortenResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            urlRquestInfo = JsonConvert.DeserializeObject<URLShortenViewModel>(URLShortenResponse);

                        }
                        //returning the employee list to view  
                        return View(urlRquestInfo);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }

           return View(reqInfo);     

        }
    }
}