using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Modelo
{
    [Table("PersonaEmail")]
    public class PersonaEmail
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public int idpersona { get; set; }
        //[ForeignKey("idpersona")]
        //public Persona persona { get; set; }
    }
}
