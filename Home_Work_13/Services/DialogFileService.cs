﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace Home_Work_13.Services
{
    class DialogFileService
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Открыть окно для открытия файла
        /// </summary>
        /// <returns></returns>
        public bool OpenFileDialog()
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();

            if (openfiledialog.ShowDialog() == true) // Если пользователь нажал кнопку ОК
            {
                FilePath = openfiledialog.FileName;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Открыть окно для сохранения файла
        /// </summary>
        /// <returns></returns>
        public bool SaveFileDialog()
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();

            if (savefiledialog.ShowDialog() == true) // Если пользователь нажал ОК
            {
                FilePath = savefiledialog.FileName;
                return true;
            }
            return false;
        }
    }
}
