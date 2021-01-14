using Persona.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Infraestructura.Persona.Dto
{
    public class PersonaDto
    {
        public Modelo.Persona persona { get; set; }
        public List<PersonaEmail> emails { get; set; }
        public List<PersonaDireccion> direcciones { get; set; }
        public List<PersonaTelefono> telefonos { get; set; }
    }
}
