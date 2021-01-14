using MediatR;
using Microsoft.EntityFrameworkCore;
using Persona.Infraestructura.Persona.Dto;
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
    public class Buscar
    {
        public class Ejecutar : IRequest<PersonaDto>
        {
            public int id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecutar, PersonaDto>
        {
            private readonly ApplicationDbContext db;
            public Manejador(ApplicationDbContext context)
            {
                db = context;
            }

            public async Task<PersonaDto> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
               
                    var obj =await db.Persona.FindAsync(request.id);
                    if (obj is null)
                        throw new ManageException(System.Net.HttpStatusCode.NotFound, new { mensaje = "La persona no fue encontrada" });
                    var emails =await db.PersonaEmail.Where(x => x.idpersona == request.id).ToListAsync();
                    var telefonos = await db.PersonaTelefono.Where(x => x.idpersona == request.id).ToListAsync();
                    var direcciones = await db.PersonaDireccion.Where(x => x.idpersona == request.id).ToListAsync();
                    
                    return new PersonaDto { persona=obj,emails=emails,telefonos=telefonos,direcciones=direcciones};
               

            }
        }
    }
}
