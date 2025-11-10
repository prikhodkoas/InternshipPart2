using System.Collections.ObjectModel;

namespace Services
{
    public interface IFileSearchService
    {
        bool IsSearching { get; }
        string RootDirectoryPath { get; set; }
        byte AmountOfThreads { get; set; }
        string FileName { get; set; }
        ObservableCollection<string> FindedPathes { get; }
        void StartSearch();
        void StopSearch();
    }
}