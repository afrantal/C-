using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace adomany.Models
{
    public class Raktar
    {
        public int Id { get; set; }

        [StringLength(60)] 
        public string Elnevezes { get; set; }
        
        [StringLength(60)] 
        public string Kategoria { get; set; }
        
        [StringLength(30)]
        public string Csomagolas { get; set; }
        
        [Column(TypeName="decimal(18,2)")] 
        public decimal Darab { get; set; }
    }
}
