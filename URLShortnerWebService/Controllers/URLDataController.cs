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

        /// <summary>
        /// GET URL basic data by once pass shorten URL its retriving the its "Id", "Long Url", "Total Visits"
        /// </summary>
        [HttpGet]
        [Route("api/URLData/GetURLDetails")]
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

        /// <summary>
        /// GET URL vistors list data by once pass shorten URL. its retriving the "User Id", "User Name", "IP Address" , "User Location"
        /// </summary>
        [HttpGet]
        [Route("api/URLData/GetURL_USERDetails")]
        public IEnumerable<UserData> GetURL_USERDetails(string shortenUrl)
        {
            try
            {
                var fetchRecord = (from urld in context.URL_DATA
                                   join usrurl in context.USER_URL_RECORDS on urld.SHORTEN_URL_ID equals usrurl.URL_ID
                                   join usrdta in context.USER_DATA on usrurl.USER_ID equals usrdta.USER_ID
                                   where urld.SHORTEN_URL_NAME == shortenUrl
                                   select new UserData
                                   {
                                       USER_ID = usrdta.USER_ID,
                                       USER_NAME = usrdta.USER_NAME,
                                       USER_IP_ADRESS = usrdta.USER_IP_ADRESS,
                                       USER_LOCATION = usrdta.USER_LOCATION,

                                   });

                return fetchRecord.Distinct().ToList();
            }
            catch (Exception)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
        }
    }
}
