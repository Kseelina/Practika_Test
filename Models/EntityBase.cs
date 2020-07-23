using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    // abstract - позволяет использовать в любых других дочерних класовых
    public abstract class EntityBase
    {
        [Key]
        public string Id { get; set; }
      
    }
}
