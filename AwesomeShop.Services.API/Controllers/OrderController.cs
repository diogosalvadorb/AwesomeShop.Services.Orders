using AwesomeShop.Services.Application.Commands;
using AwesomeShop.Services.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetOrderById(id);

            var result = await _mediator.Send(query);   

            if(result == null) 
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddOrder command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id = id }, command);
        }
    }
}
