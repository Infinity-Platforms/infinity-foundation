namespace Infinity.Administration.Service.Controllers
{
    using FluentMediator;
    using Infinity.Administration.Api.Base;
    using Infinity.Administration.Api.Controllers.V1.RegisterUser;
    using Infinity.Administration.Api.Controllers.V1.UserDetails;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="RegisterUserController" />
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : BaseController
    {
        // POST: api/RegisterUser
        /// <summary>
        /// Registers new user
        /// </summary>
        /// <param name="mediator">The mediator<see cref="IMediator"/></param>
        /// <param name="presenter">The presenter<see cref="UserDetailsPresenter"/></param>
        /// <param name="request">The request<see cref="RegisterUserRequest"/></param>
        /// <returns>The <see cref="Task{IActionResult}"/></returns>
        [HttpPost(Name = "RegisterUser")]
        public async Task<IActionResult> Post(
            [FromServices] IMediator mediator,
            [FromServices] RegisterUserPresenter presenter,
            [FromBody] RegisterUserRequest request)
        {

            if (!ModelState.IsValid) 
            {
                presenter.WriteError(ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage).ToArray());
                return presenter.Result;
            }

            var input = request.ToUserInput();

            await mediator.PublishAsync(input);

            return presenter.Result;
        }
    }
}
