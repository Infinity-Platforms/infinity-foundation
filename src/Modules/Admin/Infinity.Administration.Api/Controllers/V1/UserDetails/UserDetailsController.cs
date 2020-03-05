namespace Infinity.Administration.Service.Controllers
{
    using FluentMediator;
    using Infinity.Administration.Api.Controllers.V1.UserDetails;
    using Infinity.Administration.Application.Boundaries.UserDetails;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UserDetailsController" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        // GET: api/Users/5
        /// <summary>
        /// The GetByUserId
        /// </summary>
        /// <param name="mediator">The mediator<see cref="IMediator"/></param>
        /// <param name="presenter">The presenter<see cref="UserDetailsPresenter"/></param>
        /// <param name="input">The input<see cref="UserDetailsInput"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpGet("{Id}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(
            [FromServices] IMediator mediator,
            [FromServices] UserDetailsPresenter presenter,
            [FromRoute] [Required] UserDetailsInput input)
        {
            await mediator.PublishAsync(input);

            return presenter.Result;
        }
    }
}
