using MediatR;
using Persona.Infraestructura.SeekWork;
using Persona.Modelo;
using Persona.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persona.Infraestructura.Persona
{
    public class Crear
    {
        public class Ejecutar : IRequest<string>
        {
            public Modelo.Persona persona { get; set; }
            public List<string> telefonos { get; set; }
            public List<string> direcciones { get; set; }
            public List<string> emails { get; set; }
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
              
                    var obj = request.persona;
                    var existe = db.Persona.Where(x => x.numdocumento == obj.numdocumento).Any();
                    if(existe)
                        throw new ManageException(System.Net.HttpStatusCode.BadRequest, new { mensaje = "Ya existe un registro con el documento ingresado" });
                    await db.AddAsync(obj);
                    await db.SaveChangesAsync();
                    if(request.telefonos is not null && request.telefonos.Count>0)
                    {
                        List<PersonaTelefono> data = new List<PersonaTelefono>();
                        foreach (var item in request.telefonos)                        
                            data.Add(new PersonaTelefono {telefono=item, idpersona=obj.id });
                        await db.AddRangeAsync(data);
                        await db.SaveChangesAsync();
                    }if(request.emails is not null && request.emails.Count>0)
                    {
                        List<PersonaEmail> data = new List<PersonaEmail>();
                        foreach (var item in request.emails)                        
                            data.Add(new PersonaEmail {email=item, idpersona=obj.id });
                        await db.AddRangeAsync(data);
                        await db.SaveChangesAsync();
                    }if(request.direcciones is not null && request.direcciones.Count>0)
                    {
                        List<PersonaDireccion> data = new List<PersonaDireccion>();
                        foreach (var item in request.direcciones)                        
                            data.Add(new PersonaDireccion {direccion=item, idpersona=obj.id });
                        await db.AddRangeAsync(data);
                        await db.SaveChangesAsync();
                    }
                    return "ok";                
               
               
            }
        }
    }
}
