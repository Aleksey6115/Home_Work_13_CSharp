using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Home_Work_13.Models;
using Home_Work_13.Models.Client;
using System.Windows;
using Home_Work_13.Models.Users;

namespace Home_Work_13.Services
{
    /// <summary>
    /// Дополнительная работа с базой клиентов
    /// </summary>
    internal class ClientBaseService
    {
        /// <summary>
        /// Добавление измений с базой в список
        /// </summary>
        public event Action<IUsers, string, decimal, ClientAbstract> BaseAddHistory;

        /// <summary>
        /// Сгенерировать базу данных
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Добавить нового клиента в Базу
        /// </summary>
        /// <param name="clientList"></param>
        /// <param name="newClient"></param>
        /// <returns></returns>
        public ObservableCollection<ClientAbstract> AddClient (ObservableCollection<ClientAbstract> clientList, ClientAbstract newClient, IUsers user)
        {
            bool flag = false;

            for (int i = 0; i < clientList.Count; i++)
            {
                if (clientList[i].Equals(newClient))
                {
                    MessageBox.Show("Такой клиент уже существует!");
                    flag = true;
                    return clientList;
                }
            }

            if (!flag)
            {
                clientList.Add(newClient);
                BaseAddHistory(user, "Клиент добавлен в БД", 0, newClient);
                MessageBox.Show("Новый клиент успешно добавлен");
            }

            return clientList;
        }

        /// <summary>
        /// Удалить клиента из базы
        /// </summary>
        /// <param name="clientlist"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public ObservableCollection<ClientAbstract> DeleteClient (ObservableCollection<ClientAbstract> clientlist, ClientAbstract client, IUsers user)
        {
            clientlist.Remove(client);
            BaseAddHistory(user, "Клиент удалён из БД", 0, client);
            return clientlist;
        }
    }
}
