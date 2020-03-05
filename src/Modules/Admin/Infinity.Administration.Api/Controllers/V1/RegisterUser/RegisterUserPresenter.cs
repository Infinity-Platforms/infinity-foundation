namespace Infinity.Administration.Api.Controllers.V1.RegisterUser
{
    using Infinity.Administration.Api.Base;
    using Infinity.Administration.Application.Boundaries.RegisterNewUser;
    using Infinity.Shared.Domain.Messages;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="RegisterUserPresenter" />
    /// </summary>
    public class RegisterUserPresenter : BasePresenter<RegisterUserOutput>, IOutputPort
    {
        public override void Standard(RegisterUserOutput output)
        {
            Result = new OkObjectResult(new ActionMessage("User registration successfull.","success"));
        }
    }
}
