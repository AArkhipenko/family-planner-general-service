namespace General.Service.Domain.Models
{
    /// <summary>
    /// Доменная модель типов
    /// </summary>
    public class Type
    {
        /// <summary>
        /// Конструктор <see cref="Type" />
        /// </summary>
        /// <param name="id">идентификатор записи</param>
        /// <param name="name">наименование</param>
        /// <param name="code">код</param>
        public Type(
            int id,
            string name,
            string code)
        {
            this.Id = id;
            this.Name = name;
            this.Code = code;
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Код
        /// </summary>
        public string Code { get; }
    }
}
