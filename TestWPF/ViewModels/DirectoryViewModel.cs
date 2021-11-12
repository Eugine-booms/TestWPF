using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using TestWPFApp.ViewModels.Base;


namespace TestWPFApp.ViewModels
{
    internal class DirectoryViewModel : ViewModel
    {
        private readonly DirectoryInfo directoryInfo;

        public DirectoryViewModel(string path)
        {
            directoryInfo = new DirectoryInfo(path);
        }
        public string Name => directoryInfo.Name;
        public string Path => directoryInfo.FullName;
        public DateTime CreationTime => directoryInfo.CreationTime;
        public IEnumerable<object> DirerectoryItems
        {
            get
            {
                try
                {
                    return SubDirectories.Cast<object>().Concat(Files.Cast<object>());
                }

                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<object>();

            }

        }
        public IEnumerable<FileViewModel> Files
        {
            get
            {
                try
                {
                    var files = directoryInfo
                                .EnumerateFiles()
                                .Select(file => new FileViewModel(file.FullName));
                    return files;
                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<FileViewModel>();
            }
        }
        public IEnumerable<DirectoryViewModel> SubDirectories
        {
            get
            {
                try
                {
                    var dir = directoryInfo
                              .EnumerateDirectories()
                              .Select(dir_info => new DirectoryViewModel(dir_info.FullName));
                    return dir;

                }
                catch (UnauthorizedAccessException e)
                {
                    Debug.WriteLine(e.ToString());
                }
                return Enumerable.Empty<DirectoryViewModel>();
            }
        }

    }

    internal class FileViewModel : ViewModel
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
