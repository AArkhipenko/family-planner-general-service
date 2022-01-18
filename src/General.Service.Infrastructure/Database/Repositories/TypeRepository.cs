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
    /// Репозиторий для работы с типами
    /// </summary>
    internal class TypeRepository: ITypeRepository
    {
        private readonly FamilyPlannerContext _context;

        /// <summary>
        /// Конструктор <see cref="TypeRepository" />
        /// </summary>
        /// <param name="context">контекст базы данных</param>
        public TypeRepository(FamilyPlannerContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

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
    }
}
