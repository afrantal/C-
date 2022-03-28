using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Search
    {
        public string NevKereso { get; set; }
        public string TipusKereso { get; set; }
        public SelectList TipusLista { get; set; }
        public List<Store> Aruk { get; set; }
    }
}
