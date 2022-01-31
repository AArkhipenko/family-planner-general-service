namespace General.Service.Infrastructure.Database
{
    /// <summary>
    /// Настройки подключения к БД
    /// </summary>
    public class DatabaseOptions
    {
        /// <summary>
        /// Адрес в сети
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Номер порта
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Название БД
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
    }
}
