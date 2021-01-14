using MediatR;
using Persona.Infraestructura.SeekWork;
using Persona.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persona.Infraestructura.Persona
{
    public class Eliminar
    {
        public class Ejecutar : IRequest<string>
        {
            public int id { get; set; }
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
                
                    var obj = db.Persona.Find(request.id);
                    if (obj is null)
                        throw new ManageException(System.Net.HttpStatusCode.NotFound, new { mensaje = "La persona no fue encontrada" });
                    var emails = db.PersonaEmail.Where(x => x.idpersona == request.id).ToList();
                    var telefonos = db.PersonaTelefono.Where(x => x.idpersona == request.id).ToList();
                    var direcciones = db.PersonaDireccion.Where(x => x.idpersona == request.id).ToList();
                    if(emails.Count>0)
                    {
                        db.RemoveRange(emails);
                        await db.SaveChangesAsync();
                    } if(telefonos.Count>0)
                    {
                        db.RemoveRange(telefonos);
                        await db.SaveChangesAsync();
                    } if(direcciones.Count>0)
                    {
                        db.RemoveRange(direcciones);
                        await db.SaveChangesAsync();
                    }
                    db.Remove(obj);
                    await db.SaveChangesAsync();
                    return "ok";
               

            }
        }
    }
}
