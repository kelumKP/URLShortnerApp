﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URLShortnerWebApp.Models
{
    public class URLShortenViewModel
    {
        [DisplayName("Long URL")]
        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)$", ErrorMessage = "Invalid URL!")]
        public string longURL { get; set; }

        [DisplayName("Shorten URL")]
        public string shortenURL { get; set; }
    }
}