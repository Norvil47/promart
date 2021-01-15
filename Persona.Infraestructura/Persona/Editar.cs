using MediatR;
using Microsoft.Extensions.Logging;
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
   public class Editar
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
            private readonly ILogger<Editar> _logger;

            public Manejador(ApplicationDbContext context,
            ILogger<Editar> logger)
            {
                db = context;
                _logger = logger;

            }

            public async Task<string> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                try
                {
                    _logger.LogInformation($"Edicion de persona cod{request.persona.id} started");
                    var obj = request.persona;
                    var existe = db.Persona.Find(obj.id);
                    if (existe is null)
                    {
                        _logger.LogWarning($"No existe la persona con cod{request.persona.id} {request.persona.nombres} started");
                        throw new ManageException(System.Net.HttpStatusCode.NotFound, new { mensaje = "La persona no fue encontrada" });
                    }

                    db.Update(obj);
                    await db.SaveChangesAsync();
                    _logger.LogInformation($"El empleado con cod {request.persona.id} ha sido actualizado");

                    return "ok";
                }
                catch (Exception e)
                {
                    _logger.LogError($"Error en el servidor ");

                    throw new ManageException(System.Net.HttpStatusCode.NotFound, new { mensaje = "Error en el servidor " + e.Message });
                }

            }
        }
    }
}
