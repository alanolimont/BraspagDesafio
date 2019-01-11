using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrasPag.Desafio.Models
{
    public class MdrRequest
    {
        public Nullable<double> Valor { get; set; }
        public string Adquirente { get; set; }
        public string Bandeira { get; set; }
        public string Tipo { get; set; }
    }
}