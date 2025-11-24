using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services
{
    public class FileSearchService : IFileSearchService
    {
        /// <summary>
        /// Определяет, ищет ли сейчас файлы сервис 
        /// </summary>
        public bool IsSearching { get; private set; } = false;


        /// <summary>
        /// Путь к корневой папке поиска
        /// </summary>
        private string _rootDirectoryPath;

        /// <summary>
        /// Количество потоков для поиска
        /// </summary>
        private byte _amountOfThreads;

        /// <summary>
        /// Имя искомого файла
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Найденные возможные пути к искомым файлам
        /// </summary>
        private ObservableCollection<string> _findedPathes = new ObservableCollection<string>();

        /// <summary>
        /// Свойства для изменений параметров
        /// </summary>
        public string RootDirectoryPath {
            get
            {
                return _rootDirectoryPath;
            }
            set
            {
                if (!IsSearching)
                {
                    _rootDirectoryPath = value;
                }
                else
                {
                    throw new InvalidOperationException("Нельзя изменить корневую папку, пока сервис работает");
                }
            }
        }

        public byte AmountOfThreads
        {
            get
            {
                return _amountOfThreads;
            }
            set
            {
                if (!IsSearching)
                {
                    _amountOfThreads = value;
                }
                else
                {
                    throw new InvalidOperationException("Нельзя изменить количество потоков, пока сервис работает");
                }
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                if (!IsSearching)
                {
                    _fileName = value;
                }
                else
                {
                    throw new InvalidOperationException("Нельзя изменить искомый файл, пока сервис работает");
                }
            }
        }

        public ObservableCollection<string> FindedPathes
        {
            get => _findedPathes;
        }


        /// <summary>
        /// Очередь путей, которые следует проверить на наличие файла
        /// </summary>
        private Queue<string> _queueOfPathesNeedToCheck = new Queue<string>();

        
        /// <summary>
        /// Определяет, закончил ли поток обход дерева файловой системы 
        /// </summary>
        private volatile bool _isMainThreadFinishToPassAllDirectories = false;

        private CancellationTokenSource _cts;

        /// <summary>
        /// Событие окончания поиска файлов 
        /// </summary>
        public event EventHandler SearchCompleted;

        public FileSearchService(byte amountOfThreads, string rootDirectory, string fileName)
        {
            _amountOfThreads = amountOfThreads;
            _rootDirectoryPath = rootDirectory;
            _fileName = fileName;
        }

        /// <summary>
        /// Запуск сервиса по поиску путей к файлу
        /// </summary>
        public void StartSearch()
        {
            IsSearching = true;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            var producerThread = new Thread(() => PassAllDiretories(_rootDirectoryPath, token));
            producerThread.Start();

            var workerThreads = new List<Thread>();
            for (int i = 0; i < _amountOfThreads; i++)
            {
                var thread = new Thread(() => CheckFilesInDirectory(token));
                thread.Start();
                workerThreads.Add(thread);
            }

            foreach (var thread in workerThreads)
            {
                thread.Join();
            }

            IsSearching = false;
            SearchCompleted?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Отмена поиска
        /// </summary>
        public void StopSearch()
        {
            _cts?.Cancel();
        }

        /// <summary>
        /// Проход по всем директориям (основной метод для потока)
        /// </summary>
        /// <param name="rootPath">Корневая папка</param>
        /// <param name="token">Токен отмены</param>
        private void PassAllDiretories(string rootPath, CancellationToken token)
        {
            PassDirectory(new DirectoryInfo(rootPath), token);
            _isMainThreadFinishToPassAllDirectories = true;
        }
        
        /// <summary>
        /// Рекурсивный обход дерева файловой системы
        /// </summary>
        /// <param name="di">Информация о директории</param>
        /// <param name="token">Токен отмены</param>
        /// <exception cref="DirectoryNotFoundException"></exception>
        private void PassDirectory(DirectoryInfo di, CancellationToken token)
        {
            if (token.IsCancellationRequested) return;
            if (di is null) return;
            if (!di.Exists) throw new DirectoryNotFoundException($"Directory {di.FullName} does not exist!");

            try
            {
                lock (_queueOfPathesNeedToCheck)
                {
                    _queueOfPathesNeedToCheck.Enqueue(di.FullName);
                }
                foreach (var dir in di.GetDirectories())
                {
                    PassDirectory(dir, token);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return;
            }
        }

        /// <summary>
        /// Проверка файлов в директориях потоками
        /// </summary>
        /// <param name="token">Токен отмены</param>
        private void CheckFilesInDirectory(CancellationToken token)
        {
            while (!token.IsCancellationRequested && (!_isMainThreadFinishToPassAllDirectories || _queueOfPathesNeedToCheck.Count > 0))
            {
                string currentPathToCheck = null;
                if (_queueOfPathesNeedToCheck.Count > 0)
                {
                    lock (_queueOfPathesNeedToCheck)
                    {
                        currentPathToCheck = _queueOfPathesNeedToCheck.Dequeue();
                    }
                }
                else
                {
                    Thread.Sleep(10);
                    continue;
                }

                try
                {
                    foreach (var file in Directory.GetFiles(currentPathToCheck))
                    {
                        if (Path.GetFileName(file).Equals(_fileName, StringComparison.OrdinalIgnoreCase))
                        {
                            lock (_findedPathes)
                            {
                                _findedPathes.Add(file);
                            }
                        }
                    }
                }
                catch (UnauthorizedAccessException ex)
                {

                }
            }
        }
    }
}
