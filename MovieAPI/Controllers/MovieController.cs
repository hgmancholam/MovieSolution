using Application.Movies.Command;
using Application.Movies.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private ISender? _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>() ?? throw new InvalidOperationException("ISender service not found.");

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetMovies([FromRoute] GetMoviesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // GET api/<ValuesController>/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] GetMovieByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] DeleteMovieCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}