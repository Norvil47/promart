using Microsoft.AspNetCore.Mvc;
using Persona.Infraestructura.Direccion;
using Persona.Infraestructura.Email;
using Persona.Infraestructura.Persona;
using Persona.Infraestructura.Persona.Dto;
using Persona.Infraestructura.Telefono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persona.Api.Controllers
{
    
    [ApiController]
    public class PersonaController : _baseController
    {
    
       
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> Get( int id)
        {
            return await _mediator.Send(new Buscar.Ejecutar { id=id});
        }

       
        [HttpPost("Crear")]
        public async Task<string> PostAsync(Crear.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }

       
        [HttpPut("Editar")]
        public async Task<string> PutAsync(Editar.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            return await _mediator.Send(new Eliminar.Ejecutar { id = id });
        }
        [HttpPost("CrearDireccion")]
        public async Task<string> PostDireccionAsync(CrearDireccion.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }
        [HttpPut("EditarDireccion")]
        public async Task<string> PutDireccionAsync(EditarDireccion.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }
        [HttpDelete("EliminarDireccion/{id}")]
        public async Task<string> DeleteDireccionAsync(int id)
        {
            return await _mediator.Send(new EliminarDireccion.Ejecutar { id = id });
        }
        [HttpPost("CrearTelefono")]
        public async Task<string> PostTelefonoAsync(CrearTelefono.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }
        [HttpPost("CrearEmail")]
        public async Task<string> PostEmailAsync(CrearEmail.Ejecutar obj)
        {
            return await _mediator.Send(obj);
        }
    }
}
