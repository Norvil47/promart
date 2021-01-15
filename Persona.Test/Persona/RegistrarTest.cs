using NUnit.Framework;
using Persona.Infraestructura.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persona.Test.Persona
{
    class RegistrarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RegistrarUsuario()
        {
            var context = ApplicationDbContextInMemory.Get();
            var obj = new Crear.Ejecutar();
            obj.persona = new Modelo.Persona
            {
                apellidos = "Guevara Torres",
                nombres = "Norvil Stalin",
                numdocumento = "73514049",
                fechanacimiento = DateTime.Now.AddYears(-22)
            };
            obj.telefonos = new List<string> ();
            obj.telefonos.Add("78956585");
            obj.direcciones = new List<string>();
            obj.direcciones.Add("La libertad Pacanga");
            obj.emails = new List<string>();
            obj.emails.Add("Norvilguevara@gmail.com");
            var handler = new Crear.Manejador(context);
            var resp = await handler.Handle(obj,new CancellationToken());
            Assert.AreEqual(resp,"ok");
        }
       
    }
}
