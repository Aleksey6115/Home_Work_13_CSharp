using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Home_Work_13.Models;
using Home_Work_13.Models.Client;

namespace Home_Work_13.Services
{
    /// <summary>
    /// Дополнительная работа с базой клиентов
    /// </summary>
    internal class ClientBaseService
    {
        public ObservableCollection<ClientAbstract> GeneratorBase()
        {
            ObservableCollection<ClientAbstract> result = new ObservableCollection<ClientAbstract>();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
                result.Add(new ClientIndividual($"Имя {i}", $"Фамилия {i}", rand.Next(18, 60)));

            for (int i = 10; i < 20; i++)
                result.Add(new ClientBusiness($"Имя {i}", $"Фамилия {i}", rand.Next(18, 60)));

            for (int i = 20; i < 30; i++)
                result.Add(new ClientVIP($"Имя {i}", $"Фамилия {i}", rand.Next(18, 60)));

            return result;
        }
    }
}
