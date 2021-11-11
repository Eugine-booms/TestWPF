using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    internal class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo directoryInfo;

        public IEnumerable<DirectoryViewModel> SubDirectories
        {
            get => directoryInfo
                .EnumerateDirectories()
                .Select(dir_info => new DirectoryViewModel(dir_info.FullName));
        }
        public DirectoryViewModel(string path)
        {
            directoryInfo = new DirectoryInfo(path);
        }
        public IEnumerable<FileViewModel> Files => directoryInfo
            .EnumerateFiles()
            .Select(file => new FileViewModel(file.FullName));
        public string Name => directoryInfo.Name;
        public string Path => directoryInfo.FullName;
        public DateTime CreationTime => directoryInfo.CreationTime;
        public IEnumerable<object> DirerectoryItems
        {
            get => SubDirectories.Cast<object>().Concat(Files.Cast<object>());

        }
    }
    class FileViewModel: ViewModel
    {
        private readonly FileInfo fileInfo;

        public string Name => fileInfo.Name;
        public string Path => fileInfo.FullName;
        public DateTime CreationTime => fileInfo.CreationTime;
        public FileViewModel(string path)
        {
            fileInfo = new FileInfo(path);
        }
    }
    
}
