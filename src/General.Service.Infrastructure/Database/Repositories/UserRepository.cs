using General.Service.Domain.Exceptions;
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
                .OrderBy(x => x.Id)
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
            var member = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Birthday = model.Birthday
            };

            this._context.Users.Add(member);
            await this._context.SaveChangesAsync();

            return member.Id;
        }

        public async Task UpdateAsync(DomainExt.User model)
        {
            var member = await this.GetMemberAsync(model.Id);

            member.Name = model.Name;
            member.Surname = model.Surname;
            member.Birthday = model.Birthday;

            await this._context.SaveChangesAsync();
        }

        /// <summary>
        /// Поиск пользователя по ид
        /// </summary>
        /// <param name="id">ид записи</param>
        /// <returns>данные пользователь</returns>
        private async Task<User> GetMemberAsync(int id)
        {
            var result = await this._context.Users.FindAsync(id);
            if (result is null)
                throw new NotFoundException($"Пользователь с идентификатором {id} не найден");
            return result;
        }
    }
}
