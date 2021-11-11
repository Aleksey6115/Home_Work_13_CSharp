﻿using System;
using System.Collections.Generic;
using System.Text;
using Home_Work_13.View.DialogWindows;

namespace Home_Work_13.Services
{
    class DialogHelpService
    {
        // Короткая инструкция
        private string helpStr = "Приветствую тебя! Эта короткая инструкция поможет тебе понять как работает эта программа.\n\n\n" +
            " 1. Счёт (Депозитный или обычный) считается открытым если баланс больше 0.\n\n" +
            " 2. Для того чтобы произвести какое либо действие со счётом нужно:\n" +
            "   - Ввести сумму для операции (Слева от кнопки с действием).\n" +
            "   - Нажать кнопку с действием.\n\n" +
            " 3. Перевод другому клиенту осуществляется следующим образом:\n" +
            "   - Ввести сумму для операции (Слева от кнопки с действием).\n" +
            "   - Нажать кнопку с действием.\n" +
            "   - Откроется список тех клиентов у которых открыт счёт.\n" +
            "   - Выбрать клиента и нажать кнопку ОК.\n\n" +
            " 4. Создание нового клиента:\n" +
            "   - Если клиент с такими данными уже существует, то в список он добавлен не будет.\n" +
            "   - Если какое-то поле осталось пустым, то новый клиент не будет создан.\n" +
            "   - В случае успешного добавления клиента в список, программа оповестит об этом.\n\n" +
            " 5. Процентнные ставки клиентов по депозиту:\n" +
            "   - Физическое лицо - 10%\n" +
            "   - Юридическое лицо - 15%\n" +
            "   - VIP клиенты - 20%";

        /// <summary>
        /// Открыть диалоговое окно помощи
        /// </summary>
        public bool OpenDialogHelp()
        {
            HelpWindow HW = new HelpWindow();
            HW.TxtHelp.Text = helpStr;

            if (HW.ShowDialog() == true) return true;
            return false;
        }
    }
}
