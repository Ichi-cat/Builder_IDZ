﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Api.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private IMapper _mapper;
        protected IMapper Mapper =>
            _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    }
}
