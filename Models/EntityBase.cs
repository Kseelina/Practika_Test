using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{/// <summary>
/// ИД как для вопросов, так и для ответов
/// </summary>
    public abstract class EntityBase
    {
        [Key]
        [Index]
        public string Id { set; get; }
    }
}
