using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("General.Service.Api.Test")]

namespace General.Service.Infrastructure.Database.Tables
{
    /// <summary>
    /// Модель записи из таблицы types
    /// </summary>
    internal class Type
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        internal string Code { get; set; }

        /// <summary>
        /// Конфигурирование маппера
        /// </summary>
        /// <param name="builder"></param>
        internal static void Configure(EntityTypeBuilder<Type> builder)
        {
            builder
                .ToTable("types")
                .HasKey(x => x.Id);

            builder
                .Property(b => b.Id)
                .HasColumnName("id");

            builder
                .Property(b => b.Name)
                .HasColumnName("name");

            builder
                .Property(b => b.Code)
                .HasColumnName("code");
        }
    }
}
