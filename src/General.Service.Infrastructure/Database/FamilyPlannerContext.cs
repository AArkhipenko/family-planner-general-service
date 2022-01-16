using General.Service.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.Service.Infrastructure.Database
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    internal class FamilyPlannerContext: DbContext
    {
        /// <summary>
        /// Конструктор <see cref="FamilyPlannerContext" />
        /// </summary>
        /// <param name="options">настройки для подключения к БД</param>
        public FamilyPlannerContext(DbContextOptions options): base(options)
        { }

        /// <summary>
        /// Таблица пользователей
        /// </summary>
        internal DbSet<User> Users { get; set; }

        /// <summary>
        /// Действия во время создания модели
        /// </summary>
        /// <param name="modelBuilder"><see cref="ModelBuilder" /></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User.Configure(modelBuilder.Entity<User>());
        }
    }
}
