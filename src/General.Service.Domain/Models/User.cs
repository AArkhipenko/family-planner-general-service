using System;

namespace General.Service.Domain.Models
{
    /// <summary>
    /// Доменная модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Конструктор <see cref="GetUserListQuery" />
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">имя пользователя</param>
        /// <param name="surname">фамилия пользователя</param>
        /// <param name="birthday">дата рождения</param>
        public User(
            int id,
            string name,
            string surname,
            DateTime birthday)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }

        /// <summary>
        /// Конструктор <see cref="GetUserListQuery" />
        /// </summary>
        /// <param name="name">имя пользователя</param>
        /// <param name="surname">фамилия пользователя</param>
        /// <param name="birthday">дата рождения</param>
        public User(
            string name,
            string surname,
            DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Birthday = birthday;
        }

        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; }
    }
}
