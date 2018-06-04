using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Xml;
using URLShortnerWebService.Models;

namespace URLShortnerWebService.Controllers
{
    public class URLGenerateController : ApiController
    {
        URLShortenViewModel urlRquestOutput = new URLShortenViewModel();

        // GET api/values/5
        [HttpGet]
        public URLShortenViewModel GenerateURL(string longUrl)
        {
            string shortenUrl = null;
            var regex = @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)$";

            string BITLY_API_URI = "http://api.bit.ly/shorten?";
            string BITLY_VERSION_NAME = "version=2.0.1";
            string BITLY_FORMAT = "&format=xml";
            string BITLY_LONG_URL = "&longUrl=";
            string BITLY_LOGIN = "&login=";
            string BITLY_APIKEY = "&apiKey=";
            string BITLY_REQUEST_METHOD = "GET";
            string BITLY_CONTENT_TYPE = "application/x-www-form-urlencoded";
            string BITLY_USER_NAME = "kelumkp";
            string BITLY_API_KEY = "R_e8a2e639cdb04552a8a0ea1e4822483d";
            bool BITLY_SERVICE_POINT = false;
            string BITLY_SHORT_URL = "//shortUrl";
            int BITLY_CONTENT_LENGTH = 0;

            if (longUrl != null && longUrl != "")
            {
                var match = Regex.Match(longUrl, regex, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    try
                    {
                        StringBuilder uri = new StringBuilder(BITLY_API_URI);

                        uri.Append(BITLY_VERSION_NAME);

                        uri.Append(BITLY_FORMAT);
                        uri.Append(BITLY_LONG_URL);
                        uri.Append(HttpUtility.UrlEncode(longUrl));
                        uri.Append(BITLY_LOGIN);
                        uri.Append(HttpUtility.UrlEncode(BITLY_USER_NAME));
                        uri.Append(BITLY_APIKEY);
                        uri.Append(HttpUtility.UrlEncode(BITLY_API_KEY));

                        HttpWebRequest request = WebRequest.Create(uri.ToString()) as HttpWebRequest;
                        request.Method = BITLY_REQUEST_METHOD;
                        request.ContentType = BITLY_CONTENT_TYPE;
                        request.ServicePoint.Expect100Continue = BITLY_SERVICE_POINT;
                        request.ContentLength = BITLY_CONTENT_LENGTH;
                        WebResponse objResponse = request.GetResponse();
                        XmlDocument objXML = new XmlDocument();
                        objXML.Load(objResponse.GetResponseStream());

                        XmlNode nShortUrl = objXML.SelectSingleNode(BITLY_SHORT_URL);

                        shortenUrl = nShortUrl.InnerText;

                        urlRquestOutput.longURL = longUrl;
                        urlRquestOutput.shortenURL = shortenUrl;

                        return urlRquestOutput;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            

            return null;
        }
    }
}
