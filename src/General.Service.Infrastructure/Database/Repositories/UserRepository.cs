using General.Service.Domain.Models;
using General.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Infrastructure.Database.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    internal class UserRepository: IUserRepository
    {
        private readonly FamilyPlannerContext _context;

        /// <summary>
        /// Конструктор <see cref="UserRepository" />
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public UserRepository(FamilyPlannerContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IAsyncEnumerable<User> GetListAsync(int offset, int count)
        {
            return this._context
                .Users
                .Skip(offset)
                .Take(count)
                .Select(x => new User(
                    x.Id,
                    x.Name,
                    x.Surname,
                    x.Birthday))
                .AsAsyncEnumerable();
        }
    }
}
