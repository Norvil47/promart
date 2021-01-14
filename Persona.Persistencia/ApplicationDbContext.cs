using Microsoft.EntityFrameworkCore;
using Persona.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Persistencia
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Persona.Modelo.Persona> Persona { get; set; }
        public DbSet<PersonaEmail> PersonaEmail { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
        public DbSet<PersonaDireccion> PersonaDireccion { get; set; }
        public DbSet<PersonaTelefono> PersonaTelefono { get; set; }

        public ApplicationDbContext(  DbContextOptions<ApplicationDbContext> options  )
            : base(options)
        {

        }
    }
}
    
