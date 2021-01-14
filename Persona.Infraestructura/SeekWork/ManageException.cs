using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Persona.Infraestructura.SeekWork
{
    public class ManageException : Exception
    {
        public HttpStatusCode codigo { get; }
        public object errores { get; }
        public ManageException(HttpStatusCode _codigo, object _errores = null)
        {
            codigo = _codigo;
            errores = _errores;
        }
    }
}
