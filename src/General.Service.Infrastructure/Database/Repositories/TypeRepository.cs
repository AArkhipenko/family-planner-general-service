using General.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DomainExt = General.Service.Domain.Models;
using ApplicationExt = General.Service.Infrastructure.Database.Tables;

namespace General.Service.Infrastructure.Database.Repositories
{
    /// <summary>
    /// Репозиторий для работы с типами
    /// </summary>
    internal class TypeRepository: BaseRepository, ITypeRepository
    {
        /// <summary>
        /// Конструктор <see cref="TypeRepository" />
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public TypeRepository(FamilyPlannerContext context): base(context)
        { }

        public IAsyncEnumerable<DomainExt.Type> GetListByCodeAsync(int offset, int count, string code)
        {
            return this._context
                .Types
                .OrderBy(x => x.Id)
                .Where(x=>x.Code == code)
                .Skip(offset)
                .Take(count)
                .Select(x => new DomainExt.Type(
                    x.Id,
                    x.Name,
                    x.Code))
                .AsAsyncEnumerable();
        }

        public async Task<DomainExt.Type> GetAsync(int id)
        {
            var member = await this.GetMemberAsync<ApplicationExt.Type>(id);
            return new DomainExt.Type(
                member.Id,
                member.Name,
                member.Code);
        }

        public async Task<int> CreateAsync(DomainExt.Type model)
        {
            var member = new ApplicationExt.Type
            {
                Name = model.Name,
                Code = model.Code
            };

            this._context.Types.Add(member);
            await this._context.SaveChangesAsync();

            return member.Id;
        }

        public async Task UpdateAsync(DomainExt.Type model)
        {
            var member = await this.GetMemberAsync<ApplicationExt.Type>(model.Id);

            member.Name = model.Name;
            member.Code = model.Code;

            await this._context.SaveChangesAsync();
        }
    }
}
