using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace URLShortnerWebApp.Models
{
    public class URLShortenViewModel
    {
        public string longURL { get; set; }
        public string shortenURL { get; set; }
    }
}