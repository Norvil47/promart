using MediatR;
using Persona.Infraestructura.SeekWork;
using Persona.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persona.Infraestructura.Direccion
{
    public class EditarDireccion
    {
        public class Ejecutar : IRequest<string>
        {
            [Required]
            public int id { get; set; }
            [Required]
            public string direccion { get; set; }
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


                var obj = db.PersonaDireccion.Find(request.id);
                if (obj is null)
                    throw new ManageException(System.Net.HttpStatusCode.NotFound, new { mensaje = "No se ha registrado la dirección" });

                obj.direccion = request.direccion;
                db.Update(obj);
                await db.SaveChangesAsync();

                return "ok";


            }
        }
    }
}
