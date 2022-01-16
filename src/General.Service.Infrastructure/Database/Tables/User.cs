using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace General.Service.Infrastructure.Database.Tables
{
    /// <summary>
    /// Модель записи из таблицы users
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        internal string Surname { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        internal DateTime Birthday { get; set; }

        /// <summary>
        /// Конфигурирование маппера
        /// </summary>
        /// <param name="builder"></param>
        internal static void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("users")
                .HasKey(x => x.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("id");

            builder
                .Property(b => b.Name)
                .HasColumnName("name");

            builder
                .Property(b => b.Surname)
                .HasColumnName("surname");

            builder
                .Property(b => b.Birthday)
                .HasColumnName("birthday");
        }
    }
}
