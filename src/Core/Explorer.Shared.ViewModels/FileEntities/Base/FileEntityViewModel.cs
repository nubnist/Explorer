﻿namespace Explorer.Shared.ViewModels
{
    public abstract class FileEntityViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string FullName { get; set; }

        protected FileEntityViewModel(string name)
        {
            Name = name;
        }
    }
}