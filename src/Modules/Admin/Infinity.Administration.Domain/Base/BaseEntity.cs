namespace Infinity.Administration.Domain.Base
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }

    public interface IBaseEntity
    {
        int Id { get; set; }
    }
}
