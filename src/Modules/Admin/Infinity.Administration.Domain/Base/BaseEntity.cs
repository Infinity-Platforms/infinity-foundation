using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Infinity.Administration.Domain.Base
{
    public class BaseEntity: IBaseEntity
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
    }

    public interface IBaseEntity
    {
        [JsonIgnore]
        int Id { get; set; }
    }
}
