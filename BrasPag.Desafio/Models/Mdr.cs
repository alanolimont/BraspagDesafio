﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrasPag.Desafio.Models
{
    public class Mdr
    {
        public string Adquirente { get; set; }
        public List<Taxa> Taxas { get; set; }
    }
}