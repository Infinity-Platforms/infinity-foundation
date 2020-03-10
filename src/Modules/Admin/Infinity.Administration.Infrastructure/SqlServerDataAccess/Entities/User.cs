using Infinity.Administration.Domain.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Entities
{
    [Table("UserMaster")]
    public class User: Domain.Users.User, IUser
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
