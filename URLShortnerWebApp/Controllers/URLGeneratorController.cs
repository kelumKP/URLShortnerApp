using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using URLShortnerWebApp.Models;
using System.IO;


namespace URLShortnerWebApp.Controllers
{
    public class URLGeneratorController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:51184";

        // GET: URLGenerator
        [HttpGet]
        public ActionResult GenerateShortenUrl()
        {
            try
            {
                URLShortenViewModel urlRquestInfo = new URLShortenViewModel();
                urlRquestInfo.longURL = null;
                urlRquestInfo.shortenURL = null;

                return View(urlRquestInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
            
        }

        [HttpPost]
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

        public async Task<ActionResult> VisitShortenUrl(URLShortenViewModel reqInfo)
        {
            try
            {
                VisitedUserData vistedUser = new VisitedUserData();
                IpInfo visitedIPData = new IpInfo();

                // Private details
                vistedUser.HostMachineName = Dns.GetHostName();
                vistedUser.MachinePrivateIP = Dns.GetHostByName(vistedUser.HostMachineName).AddressList[0].ToString();

                // Public details
                visitedIPData = GetUserDetailByIp(GetPublicIP());
                vistedUser.MachinePublicIP = visitedIPData.Ip;
                vistedUser.LongURL = reqInfo.longURL;
                vistedUser.ShortenURL = reqInfo.shortenURL;
                vistedUser.VisitedCountry = visitedIPData.Country;
                vistedUser.VisitedRegion = visitedIPData.Region;
                vistedUser.VisitedCity = visitedIPData.City;
                vistedUser.ServiceProviderName = visitedIPData.Hostname;

                // Save Details to DB

                return Redirect(reqInfo.shortenURL);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // Get user details
        internal static IpInfo GetUserDetailByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();

            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);                  
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo = null;
            }

            return ipInfo;
        }

        // Get the public IP address
        internal static string GetPublicIP()
        {
            try
            {
                string url = "http://checkip.dyndns.org";
                WebRequest req = WebRequest.Create(url);
                WebResponse resp = req.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] a = response.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                return a4;
            }
            catch (Exception ex)
            { 
                throw ex;
            } 
        }

    }
}