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

namespace Persona.Infraestructura.Email
{
    public class CrearEmail
    {
        public class Ejecutar : IRequest<string>
        {
            [Required]
            public int idpersona { get; set; }
            [Required]
            public string email { get; set; }
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
                var existe = db.PersonaEmail.Where(x => x.idpersona == request.idpersona && x.email == request.email).Any();
                if (existe)
                    throw new ManageException(System.Net.HttpStatusCode.BadRequest, new { mensaje = "Ya se ha registrado el email" });
                await db.AddAsync(new PersonaEmail { idpersona = request.idpersona, email = request.email });
                await db.SaveChangesAsync();

                return "ok";


            }
        }
    }
}
