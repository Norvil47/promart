using MediatR;
using Persona.Infraestructura.SeekWork;
using Persona.Modelo;
using Persona.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persona.Infraestructura.Telefono
{
   public class CrearTelefono
    {
        public class Ejecutar : IRequest<string>
        {
            [Required]
            public int idpersona { get; set; }
            [Required]
            public string telefono { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecutar, string>
        {
            private readonly ApplicationDbContext db;
            public Manejador(ApplicationDbContext context)
            {
                db = context;
            }

            public async Task<string> Handle(Ejecutar request, CancellationToken cancellationToken)
            {

                var persona = db.Persona.Find(request.idpersona);
                if (persona is null)
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, new { mensaje = "No existe persona" });
                var existe = db.PersonaTelefono.Where(x => x.idpersona == request.idpersona && x.telefono==request.telefono).Any();
                if (existe)
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, new { mensaje = "Ya se ha registrado el telefono" });
                await db.AddAsync(new PersonaTelefono { idpersona=request.idpersona , telefono=request.telefono});
                await db.SaveChangesAsync();
               
                return "ok";


            }
        }
    }
}
