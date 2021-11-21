using System;
using System.Collections.Generic;
using System.Text;
using Home_Work_13.Models.Users;
using System.Collections.ObjectModel;
using Home_Work_13.View.DialogWindows;

namespace Home_Work_13.Services.DialogServices
{
    /// <summary>
    /// Окно авторизации
    /// </summary>
    internal class DialogAuthorizationService
    {
        /// <summary>
        /// Список пользователей
        /// </summary>
        private ObservableCollection<IUsers> users = new ObservableCollection<IUsers>
        {
            new Maneger(),
            new Consultant()
        };

        /// <summary>
        /// Выбранный пользователь
        /// </summary>
        public IUsers SelectedUser { get; set; }

        /// <summary>
        /// Открыть окно авторизации
        /// </summary>
        /// <returns></returns>
        public bool OpenAuthorizationDialog()
        {
            DialogAuthorizationWindow AW = new DialogAuthorizationWindow();
            AW.comboUsers.Items.Clear();
            AW.comboUsers.ItemsSource = users;

            if (AW.ShowDialog() == true)
            {
                SelectedUser = AW.comboUsers.SelectedItem as IUsers;
                return true;
            }

            return false;
        }
    }
}
