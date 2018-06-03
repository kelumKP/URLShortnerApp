using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URLShortnerWebService.Models
{
    public class URLShortenViewModel
    {
        [DisplayName("Long URL")]
        [RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Invalid URL!")]
        public string longURL { get; set; }

        [DisplayName("Shorten URL")]
        public string shortenURL { get; set; }
    }
}