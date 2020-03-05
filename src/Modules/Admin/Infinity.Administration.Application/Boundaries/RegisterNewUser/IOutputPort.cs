using Infinity.Administration.Application.Base;
using Infinity.Administration.Application.Boundaries.UserDetails;

namespace Infinity.Administration.Application.Boundaries.RegisterNewUser
{
    public interface IOutputPort : IOutputPortStandard<RegisterUserOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
