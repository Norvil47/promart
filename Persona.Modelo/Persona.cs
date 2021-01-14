using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Modelo
{
    [Table("Persona")]

    public class Persona
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nombres { get; set; }
        [Required]

        public string apellidos { get; set; }
        [Required]

        public string numdocumento { get; set; }
        public string imagen { get; set; }
        public DateTime? fechanacimiento { get; set; }
        public int? idtipodocumento { get; set; }

        //[NotMapped]
        //[ForeignKey("idtipodocumento")]
        //public TipoDocumento tipodocumento { get; set; }
    }
}
