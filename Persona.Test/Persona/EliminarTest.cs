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
    class EliminarTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task EliminarUsuario()
        {
            var context = ApplicationDbContextInMemory.Get();
            var obj = new Eliminar.Ejecutar();
            obj.id = 1;
            var handler = new Eliminar.Manejador(context);
            var resp = await handler.Handle(obj, new CancellationToken());
            Assert.AreEqual(resp, "ok");
        }
    }
}
