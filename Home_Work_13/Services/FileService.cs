using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using Home_Work_13.Models;
using Newtonsoft.Json;
using Home_Work_13.Models.Client;

namespace Home_Work_13.Services
{
    /// <summary>
    /// Работа с файлом БД
    /// </summary>
    class FileService
    {
        /// <summary>
        /// Настройки для сериализации и десериализации
        /// </summary>
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        /// <summary>
        /// Открыть файл
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public ObservableCollection<ClientAbstract> OpenFile(string path)
        {
            ObservableCollection<ClientAbstract> clients = new ObservableCollection<ClientAbstract>();
            clients = JsonConvert.DeserializeObject<ObservableCollection<ClientAbstract>>(File.ReadAllText(path), settings);
            return clients;
        }

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        public void SaveFile(string path, ObservableCollection<ClientAbstract> clients)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(clients, settings));
        }
    }
}
