using System;
using System.Collections.Generic;
using System.Text;
using Home_Work_13.Models.Data;

namespace Home_Work_13.Services.FileServices
{
    interface IFile
    {
        /// <summary>
        /// Открыть файл
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public DataList OpenFile(string path);
        /// <summary>
        /// Сохранить файл
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void SaveFile(string path, DataList data);
    }
}
