using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Home_Work_13.Models.DataHistory;

namespace Home_Work_13.Models.Data
{
    /// <summary>
    /// Класс хранит в себе данные о клиентах и операциях
    /// </summary>
    internal class DataList
    {
        /// <summary>
        /// Коллекция клиентов
        /// </summary>
        public ObservableCollection<ClientAbstract> clientsList;

        /// <summary>
        /// Коллекция операций произведенных со счетами клиентов
        /// </summary>
        public ObservableCollection<History> historyList;

        /// <summary>
        /// Конструктор класса DataList
        /// </summary>
        public DataList()
        {
            clientsList = new ObservableCollection<ClientAbstract>();
            historyList = new ObservableCollection<History>();
        }
    }
}
