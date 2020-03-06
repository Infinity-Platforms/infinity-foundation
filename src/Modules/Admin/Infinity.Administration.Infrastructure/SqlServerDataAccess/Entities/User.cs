using Infinity.Administration.Domain.Users;
using System;

namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Entities
{
    public class User: Domain.Users.User, IUser
    {
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }
    }
}
