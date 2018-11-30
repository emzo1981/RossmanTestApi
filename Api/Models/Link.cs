using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class Link
    {
        public string Rel { get; set; }
        public string Method { get; set; }
        public string Href { get; set; }
    }
}
