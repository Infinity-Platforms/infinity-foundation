using Infinity.Administration.Application.Base;

namespace Infinity.Administration.Application.Boundaries.UserDetails
{
    public interface IOutputPort : IOutputPortStandard<UserDetailsOutput>, IOutputPortNotFound, IOutputPortError
    {
    }
}
