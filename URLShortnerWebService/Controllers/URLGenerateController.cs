using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace URLShortnerWebService.Controllers
{
    public class URLGenerateController : ApiController
    {
        // GET api/values/5
        [HttpGet]
        public string GenerateURL(string longUrl)
        {
            string shortenUrl = null;


            try
            {
                StringBuilder uri = new StringBuilder("http://api.bit.ly/shorten?");

                uri.Append("version=2.0.1");

                uri.Append("&format=xml");
                uri.Append("&longUrl=");
                uri.Append(HttpUtility.UrlEncode(longUrl));
                uri.Append("&login=");
                uri.Append(HttpUtility.UrlEncode("kelumkp"));
                uri.Append("&apiKey=");
                uri.Append(HttpUtility.UrlEncode("R_e8a2e639cdb04552a8a0ea1e4822483d"));

                HttpWebRequest request = WebRequest.Create(uri.ToString()) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ServicePoint.Expect100Continue = false;
                request.ContentLength = 0;
                WebResponse objResponse = request.GetResponse();
                XmlDocument objXML = new XmlDocument();
                objXML.Load(objResponse.GetResponseStream());

                XmlNode nShortUrl = objXML.SelectSingleNode("//shortUrl");

                shortenUrl = nShortUrl.InnerText; 
                return nShortUrl.InnerText;
            }
            catch(Exception ex)
            {                   
                throw ex;
            }      
        }
    }
}
