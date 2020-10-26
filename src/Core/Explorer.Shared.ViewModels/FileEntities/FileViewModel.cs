﻿using System.IO;

namespace Explorer.Shared.ViewModels
{
    public sealed class FileViewModel : FileEntityViewModel
    {
        public FileViewModel(string name) : base(name)
        {
            FullName = name;
        }

        public FileViewModel(FileInfo file) : base(file.Name)
        {
            FullName = file.FullName;
        }
    }
}