using Infinity.Administration.Application.Base;
using Microsoft.AspNetCore.Mvc;

namespace Infinity.Administration.Api.Base
{
    public class BasePresenter<T>: IOutputPortStandard<T>, IOutputPortNotFound, IOutputPortError
    {
        public IActionResult Result { get; set; }

        public virtual void NotFound(string message)
        {
            Result = new NotFoundObjectResult(message);
        }

        public virtual void Standard(T output)
        {
            Result = new OkObjectResult(output);
        }

        public virtual void WriteError(string message)
        {
            Result = new BadRequestObjectResult(message);
        }

        public virtual void WriteError(string[] message)
        {
            Result = new BadRequestObjectResult(message);
        }
    }
}
