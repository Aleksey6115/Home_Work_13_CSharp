using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using Home_Work_13.Models;
using Newtonsoft.Json;
using Home_Work_13.Models.Client;
using Home_Work_13.Models.Data;
using Home_Work_13.Services.FileServices;

namespace Home_Work_13.Services
{
    /// <summary>
    /// Работа с файлом БД
    /// </summary>
    internal class FileService : IFile
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
        public DataList OpenFile(string path)
        {
            DataList dl = new DataList();
            dl = JsonConvert.DeserializeObject<DataList>(File.ReadAllText(path), settings);
            return dl;
        }

        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        public void SaveFile(string path, DataList data)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data, settings));
        }
    }
}
