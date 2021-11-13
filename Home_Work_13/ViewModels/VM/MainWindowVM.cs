using System;
using System.Collections.Generic;
using System.Text;
using Home_Work_13.Models;
using System.Collections.ObjectModel;
using Home_Work_13.Commands;
using Home_Work_13.Models.Client;
using System.Windows;

namespace Home_Work_13.ViewModels.VM
{
    class MainWindowVM : ViewModelBase
    {
        #region Поля
        private ClientAbstract selectedClient; // Выбранный клиент
        private decimal txtReplenishDeposit; // Сумма для пополнения депозита
        private decimal txtTransferToAccount; // Сумма для перевода на счёт
        private decimal txtReplenishAccount; // Сумма для пополнения счёта
        private decimal txtWithdrawAccount; // Сумма для снятие счёта
        private decimal txtTransferToDeposit; // Сумма перевода со счёта на депозит
        private decimal txtTransferToClient; // Сумма для перевода другому клиенту
        #endregion

        #region Сервисы
        private Services.ServiceClient serviceClient = new Services.ServiceClient(); // Работа с данными клиента
        private Services.DialogAddClientService dialogAddClientService = new Services.DialogAddClientService(); // Добавление клиента
        private Services.DialogTransferClientService dialogTransfer = new Services.DialogTransferClientService(); // Перевод клиенту
        private Services.FileService fileService = new Services.FileService(); // Работа с файлами
        private Services.DialogFileService dialogFileService = new Services.DialogFileService(); // Окна для работы с файлами
        private Services.DialogHelpService dialogHelpService = new Services.DialogHelpService(); // Окно с короткой инструкцией
        #endregion

        #region Свойства
        /// <summary>
        /// Выбранный клиент
        /// </summary>
        public ClientAbstract SelectedClient
        {
            get => selectedClient;
            set => Set(ref selectedClient, value);
        }

        /// <summary>
        /// Список клиентов
        /// </summary>
        public ObservableCollection<ClientAbstract> ClientsList { get; set; }

        /// <summary>
        /// Сумма для пополнения депозита
        /// </summary>
        public decimal TxtReplenishDeposit
        {
            get => txtReplenishDeposit;
            set => Set(ref txtReplenishDeposit, value);
        }

        /// <summary>
        /// Сумма для перевода на счёт с депозита
        /// </summary>
        public decimal TxtTransferToAccount
        {
            get => txtTransferToAccount;
            set => Set(ref txtTransferToAccount, value);
        }

        /// <summary>
        /// Сумма для пополнения счёта
        /// </summary>
        public decimal TxtReplenishAccount
        {
            get => txtReplenishAccount;
            set => Set(ref txtReplenishAccount, value);
        }

        /// <summary>
        /// Сумма для снятие счёта
        /// </summary>
        public decimal TxtWithdrawAccount
        {
            get => txtWithdrawAccount;
            set => Set(ref txtWithdrawAccount, value);
        }

        /// <summary>
        /// Сумма перевода со счёта на депозит
        /// </summary>
        public decimal TxtTransferToDeposit
        {
            get => txtTransferToDeposit;
            set => Set(ref txtTransferToDeposit, value);
        }

        /// <summary>
        /// Сумма для перевода другому клиенту
        /// </summary>
        public decimal TxtTransferToClient
        {
            get => txtTransferToClient;
            set => Set(ref txtTransferToClient, value);
        }
        #endregion

        #region Конструктор
        public MainWindowVM()
        {
            ClientsList = new ObservableCollection<ClientAbstract>();
        }
        #endregion

        #region Комманды - общие комманды
        private RelayCommand generatorBaseCommand; // Комманда создания БД
        private RelayCommand addClientCommand; // Комманда добавления клиента
        private RelayCommand deleteClientCommand; // Команда удаление выбранного клиента
        private RelayCommand openFileCommand; // Комманда открыть файл
        private RelayCommand saveFileCommand; // Комманда сохранить файл
        private RelayCommand openHelpCommand; // Команда открывает окно помощи


        /// <summary>
        /// Комманда создания БД
        /// </summary>
        public RelayCommand GeneratorBaseCommand
        {
            get
            {
                return generatorBaseCommand ?? (generatorBaseCommand = new RelayCommand(obj =>
                {
                    ClientsList.Clear();
                    ObservableCollection<ClientAbstract> cli = serviceClient.GeneratorBase();

                    for (int i = 0; i < cli.Count; i++)
                        ClientsList.Add(cli[i]);
                }));
            }
        }

        /// <summary>
        /// Комманда добавления клиента
        /// </summary>
        public RelayCommand AddClientCommand
        {
            get
            {
                return addClientCommand ?? (addClientCommand = new RelayCommand(obj =>
                {
                    bool flag = false;

                        if (dialogAddClientService.OpenAddClientDialog() == true)
                        {
                            for (int i = 0; i < ClientsList.Count; i++)
                            {
                                if (ClientsList[i].Equals(dialogAddClientService.client))
                                {
                                    MessageBox.Show("Такой клиент уже существует!");
                                    flag = true;
                                    break;
                                }
                            }

                            if (!flag)
                            {
                                ClientsList.Add(dialogAddClientService.client);
                                MessageBox.Show("Новый клиент успешно добавлен!");
                            }
                        }
                }));
            }
        }

        /// <summary>
        /// Комманда удаления текущего клиента
        /// </summary>
        public RelayCommand DeleteClientCommand
        {
            get
            {
                return deleteClientCommand ?? (deleteClientCommand = new RelayCommand(obj =>
                {
                    ClientAbstract client = obj as ClientAbstract;
                    ClientsList.Remove(client);
                },
                obj => ClientsList.Count > 0));
            }
        }

        /// <summary>
        /// Команда открыть файл с БД
        /// </summary>
        public RelayCommand OpenFileCommand
        {
            get
            {
                return openFileCommand ?? (openFileCommand = new RelayCommand(obj =>
                {
                try
                {
                    if (dialogFileService.OpenFileDialog() == true)
                        {
                            ClientsList.Clear();
                            var clients = fileService.OpenFile(dialogFileService.FilePath);

                            foreach (var c in clients)
                                ClientsList.Add(c);

                            MessageBox.Show("Файл успешно загружен");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                }));
            }
        }

        /// <summary>
        /// Комманда сохранить файл с БД
        /// </summary>
        public RelayCommand SaveFileCommand
        {
            get
            {
                return saveFileCommand ?? (saveFileCommand = new RelayCommand(obj =>
                {
                    try
                    {
                        if (dialogFileService.SaveFileDialog() == true)
                        {
                            fileService.SaveFile(dialogFileService.FilePath, ClientsList);
                            MessageBox.Show("Файл сохранён");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка");
                    }
                },
                obj => ClientsList.Count > 0));
            }
        }

        /// <summary>
        /// Команда открывает окно помощи
        /// </summary>
        public RelayCommand OpenHelpCommand
        {
            get
            {
                return openHelpCommand ?? (openHelpCommand = new RelayCommand(obj =>
                {
                    dialogHelpService.OpenDialogHelp();
                }));
            }
        }
        #endregion

        #region Комманды - работа с депозитом

        private RelayCommand openDepositAccountCommand; // Добавление депозитного счёта
        private RelayCommand closeDepositAccountComand; // Закрытие депозитного счёта
        private RelayCommand replenishDepositCommand; // Пополнить депозит
        private RelayCommand transferToAccountCommand; // Перевод с депозита на счёт

        /// <summary>
        /// Открыть клиенту депозитный счёт
        /// </summary>
        public RelayCommand OpenDepositAccountCommand
        {
            get
            {
                return openDepositAccountCommand ?? (openDepositAccountCommand = new RelayCommand(obj =>
                {
                    ClientAbstract client = obj as ClientAbstract;
                    client.DepositAccount = 1;
                    TxtReplenishDeposit = 0;
                    TxtTransferToAccount = 0;
                    client.AccumulatedDeposit = client.DepositRate * client.DepositAccount;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.DepositAccount == 0;
                }));
            }
        }

        /// <summary>
        /// Закрыть депозит клиенту
        /// </summary>
        public RelayCommand CloseDepositAccountComand
        {
            get
            {
                return closeDepositAccountComand ?? (closeDepositAccountComand = new RelayCommand(obj =>
                {
                    ClientAbstract client = obj as ClientAbstract;
                    client.DepositAccount = 0;
                    TxtReplenishDeposit = 0;
                    TxtTransferToAccount = 0;
                    SelectedClient.AccumulatedDeposit = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.DepositAccount > 0;
                }));
            }
        }

        /// <summary>
        /// Пополнить депозит
        /// </summary>
        public RelayCommand ReplenishDepositCommand
        {
            get
            {
                return replenishDepositCommand ?? (replenishDepositCommand = new RelayCommand(obj =>
                {
                    SelectedClient.DepositAccount += txtReplenishDeposit;
                    TxtReplenishDeposit = 0;
                    SelectedClient.AccumulatedDeposit = SelectedClient.DepositAccount * SelectedClient.DepositRate;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.DepositAccount > 0 && TxtReplenishDeposit > -1;
                }));
            }
        }

        /// <summary>
        /// Перевести средства с депозита а счёт
        /// </summary>
        public RelayCommand TransferToAccountCommand
        {
            get
            {
                return transferToAccountCommand ?? (transferToAccountCommand = new RelayCommand(obj =>
                {
                    SelectedClient.DepositAccount -= txtTransferToAccount;
                    SelectedClient.Account += txtTransferToAccount;
                    TxtTransferToAccount = 0;
                    SelectedClient.AccumulatedDeposit = SelectedClient.DepositAccount * SelectedClient.DepositRate;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return (SelectedClient.DepositAccount > txtTransferToAccount && SelectedClient.Account > 0 
                        && TxtTransferToAccount > -1);
                }));
            }
        }
        #endregion

        #region Комманды - работа со счётом
        private RelayCommand openAccountCommand; // Открыть счёт клиенту
        private RelayCommand closeAccountCommand; // Закрыть счёт клиенту
        private RelayCommand replenishAccountCommand; // Пополнить счёт клиента
        private RelayCommand withdrawAccountCommand; // Снять средства со счёта
        private RelayCommand transferToDepositCommand; // Перевести средства со счёта на депозит
        private RelayCommand transferToClientCommand; // Перевести средства другому клиенту

        /// <summary>
        /// Открыть счёт клиенту
        /// </summary>
        public RelayCommand OpenAccountCommand
        {
            get
            {
                return openAccountCommand ?? (openAccountCommand = new RelayCommand(obj =>
                {
                    ClientAbstract client = obj as ClientAbstract;
                    client.Account = 1;
                    TxtReplenishAccount = 0;
                    TxtTransferToDeposit = 0;
                    TxtTransferToClient = 0;
                    TxtWithdrawAccount = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account == 0;
                }));
            }
        }

        /// <summary>
        /// Закрыть счёт клиента
        /// </summary>
        public RelayCommand CloseAccountCommand
        {
            get
            {
                return closeAccountCommand ?? (closeAccountCommand = new RelayCommand(obj =>
                {
                    ClientAbstract client = obj as ClientAbstract;
                    client.Account = 0;
                    TxtReplenishAccount = 0;
                    TxtTransferToDeposit = 0;
                    TxtTransferToClient = 0;
                    TxtWithdrawAccount = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account > 0;
                }));
            }
        }

        /// <summary>
        /// Пополнить счёт клиента
        /// </summary>
        public RelayCommand ReplenishAccountCommand
        {
            get
            {
                return replenishAccountCommand ?? (replenishAccountCommand = new RelayCommand(obj =>
                {
                    SelectedClient.Account += TxtReplenishAccount;
                    TxtReplenishAccount = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account > 0 && TxtReplenishAccount > -1;
                }));
            }
        }

        /// <summary>
        /// Снять средства со счёта
        /// </summary>
        public RelayCommand WithdrawAccountCommand
        {
            get
            {
                return withdrawAccountCommand ?? (withdrawAccountCommand = new RelayCommand(obj =>
                {
                    SelectedClient.Account -= TxtWithdrawAccount;
                    TxtWithdrawAccount = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account > 0 && TxtWithdrawAccount < SelectedClient.Account 
                        && TxtWithdrawAccount > -1;
                }));
            }
        }

        /// <summary>
        /// Перевести средства со счёта на депозит
        /// </summary>
        public RelayCommand TransferToDepositCommand
        {
            get
            {
                return transferToDepositCommand ?? (transferToDepositCommand = new RelayCommand(obj =>
                {
                    SelectedClient.Account -= TxtTransferToDeposit;
                    SelectedClient.DepositAccount += TxtTransferToDeposit;
                    TxtTransferToDeposit = 0;
                    SelectedClient.AccumulatedDeposit = SelectedClient.DepositAccount * SelectedClient.DepositRate;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account > TxtTransferToDeposit && SelectedClient.DepositAccount > 0
                        && TxtTransferToDeposit > -1;
                }));
            }
        }

        /// <summary>
        /// Перевод на счёт другого клиента
        /// </summary>
        public RelayCommand TransferToClientCommand
        {
            get
            {
                return transferToClientCommand ?? (transferToClientCommand = new RelayCommand(obj =>
                {
                    dialogTransfer.OpenTransferClientDialog(ClientsList, SelectedClient);

                    for (int i = 0; i < ClientsList.Count; i++)
                    {
                        if (ClientsList[i].Equals(dialogTransfer.clientTransfer))
                        {
                            ClientsList[i].Account += TxtTransferToClient;
                            SelectedClient.Account -= TxtTransferToClient;
                        }
                    }
                    TxtTransferToClient = 0;
                },
                obj =>
                {
                    if (SelectedClient == null) return false;
                    else return SelectedClient.Account > TxtTransferToClient & TxtTransferToClient > -1;
                }));
            }
        }

        #endregion
    }
}
