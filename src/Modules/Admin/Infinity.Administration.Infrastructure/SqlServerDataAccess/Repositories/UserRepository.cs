using Infinity.Administration.Domain.Users;
using Infinity.Administration.Infrastructure.SqlServerDataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infinity.Administration.Infrastructure.SqlServerDataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlDataContext _context;
        public UserRepository(SqlDataContext context)
        {
            _context = context;
        }

        public Task Delete(IUser entityToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IUser>> Get(Expression<Func<IUser, bool>> filter = null, Func<IQueryable<IUser>, IOrderedQueryable<IUser>> orderBy = null, string includeProperties = "")
        {
            IQueryable<IUser> query = _context.Users;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IUser> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task Insert(IUser entity)
        {
            await _context.Users.AddAsync(entity as Entities.User);
            await _context.SaveChangesAsync();
        }

        public async Task Update(IUser entity)
        {
            _context.Users.Update(entity as Entities.User);
            await _context.SaveChangesAsync();
        }
    }
}
