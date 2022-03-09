using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adomany.Models
{
    public class Kereso
    {
        public string NevKereso { get; set; }
        public string KategoriaKereso { get; set; }
        public SelectList KategoriaLista { get; set; }
        public List<Raktar> Aruk { get; set; }
    }
}
