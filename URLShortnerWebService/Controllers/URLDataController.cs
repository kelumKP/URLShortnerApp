using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using URLShortnerDataAccess;
using URLShortnerDataAccess.ViewModels;

namespace URLShortnerWebService.Controllers
{
    public class URLDataController : ApiController
    {
        TEST_DBEntities context = new TEST_DBEntities();

        [HttpGet]
        public UrlData GetURLDetails(string shortenUrl)
        {
            try
            {
                var fetchRecord = (from url_data in context.URL_DATA
                                   where url_data.SHORTEN_URL_NAME == shortenUrl
                                   select new UrlData()
                                   {
                                       SHORTEN_URL_ID = url_data.SHORTEN_URL_ID,
                                       LONG_URL_NAME = url_data.LONG_URL_NAME,
                                       SHORTEN_URL_NAME = url_data.SHORTEN_URL_NAME,
                                       TOTAL_VISIT_COUNT = url_data.TOTAL_VISIT_COUNT,

                                   }).SingleOrDefault();

                return fetchRecord;
            }
            catch (Exception)
            { 
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }  
        }
    }
}
