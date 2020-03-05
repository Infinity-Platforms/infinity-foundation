using Infinity.Administration.Domain.Base;

namespace Infinity.Administration.Domain.Users
{
    public interface IUser: IBaseEntity
    {
        string Guid { get; set; }
    }
}
