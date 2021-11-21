using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Users
{
    /// <summary>
    /// Пользователь - Менеджер
    /// </summary>
    internal class Maneger : IUsers
    {
        public string Name => "Менеджер";

        public override string ToString()
        {
            return Name;
        }
    }
}
