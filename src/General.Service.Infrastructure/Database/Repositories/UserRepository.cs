using General.Service.Domain.Repositories;
using General.Service.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainExt = General.Service.Domain.Models;

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

        public IAsyncEnumerable<DomainExt.User> GetListAsync(int offset, int count)
        {
            return this._context
                .Users
                .Skip(offset)
                .Take(count)
                .Select(x => new DomainExt.User(
                    x.Id,
                    x.Name,
                    x.Surname,
                    x.Birthday))
                .AsAsyncEnumerable();
        }

        public async Task<int> CreateAsync(DomainExt.User model)
        {
            var data = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Birthday = model.Birthday
            };

            this._context.Users.Add(data);
            await this._context.SaveChangesAsync();

            return data.Id;
        }
    }
}
