using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class Store
    {
        public int Id { get; set; }  //kötelező első mező!!!
        [StringLength(60)]  //ha a következő string mező 60 hosszúságú, akkor így állítjuk be
        public string Name { get; set; }
        [StringLength(60)]
        public string Category { get; set; }
        [Column(TypeName="decimal(16,2)")]  //ha 2 tizedessel kell beállítani a számot
        public decimal Price { get; set; }
    }
}
