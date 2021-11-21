using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Users
{
    /// <summary>
    /// Интерфейс отображает сущность пользователя
    /// </summary>
    internal interface IUsers
    {
        /// <summary>
        /// Название должности
        /// </summary>
        public string Name { get; }
    }
}
