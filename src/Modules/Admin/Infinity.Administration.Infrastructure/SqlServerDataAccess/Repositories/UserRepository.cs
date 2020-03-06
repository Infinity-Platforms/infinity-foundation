using Infinity.Administration.Domain.Users;
using Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration;

namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Repositories
{
    public class UserRepository : SqlServerDatabaseBaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlDataContext context):base(context)
        {

        }
    }
}
