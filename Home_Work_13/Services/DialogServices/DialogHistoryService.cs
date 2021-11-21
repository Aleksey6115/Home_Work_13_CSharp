using System;
using System.Collections.Generic;
using System.Text;
using Home_Work_13.Models.DataHistory;
using System.Collections.ObjectModel;
using Home_Work_13.View.DialogWindows;

namespace Home_Work_13.Services.DialogServices
{
    /// <summary>
    /// Работа с окном истории
    /// </summary>
    internal class DialogHistoryService
    {
        /// <summary>
        /// Выбранная запись
        /// </summary>
        public History SelectedLog { get; set; }

        /// <summary>
        /// Открыть окно с историей
        /// </summary>
        /// <param name="historyList">Лист истории который нужно отобразить</param>
        /// <returns></returns>
        public bool OpenHistoryWindow (ObservableCollection<History> historyList)
        {
            HistoryWindow HW = new HistoryWindow();
            HW.historyList.Items.Clear();
            HW.historyList.ItemsSource = historyList;

            if (HW.ShowDialog() == true) return true;
            return false;
        }
    }
}
