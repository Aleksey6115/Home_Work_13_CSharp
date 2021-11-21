using System;
using System.Collections.Generic;
using System.Text;

namespace Home_Work_13.Models.Users
{
    /// <summary>
    /// Пользователь - Консультант
    /// </summary>
    internal class Consultant : IUsers
    {
        public string Name => "Консультант";

        public override string ToString()
        {
            return Name;
        }
    }
}
