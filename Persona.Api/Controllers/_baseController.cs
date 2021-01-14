using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Persona.Api.Controllers
{
    public class _baseController: ControllerBase
    {
        private readonly IMediator mediator;
        protected IMediator _mediator => mediator ?? HttpContext.RequestServices.GetService<IMediator>();

    }
}
