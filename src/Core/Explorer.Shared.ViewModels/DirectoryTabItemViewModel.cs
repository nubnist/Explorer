using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class DirectoryTabItemViewModel : BaseViewModel
    {
        #region PublicProperties

        public string FilePath { get; set; }
        public string Name { get; set; }
        public ObservableCollection<FileEntityViewModel> DirectoriesAndFiles { get; set; } = 
            new ObservableCollection<FileEntityViewModel>();
        public FileEntityViewModel SelectedFileEntity { get; set; }

        #endregion

        #region Commands

        public ICommand OpenCommand { get; }
        public ICommand CloseCommand { get; }

        #endregion

        #region Events

        public event EventHandler Closed;

        #endregion

        #region Constructor

        public DirectoryTabItemViewModel()
        {
            Name = "Мой компьютер";

            OpenCommand = new DelegateCommand(Open);
            CloseCommand = new DelegateCommand(OnClose);

            foreach (var logicalDrive in Directory.GetLogicalDrives())
                DirectoriesAndFiles.Add(new DirectoryViewModel(logicalDrive));
        }

        #endregion

        #region ProtectedMethods



        #endregion

        #region CommandsMethods

        private void Open(object parameter)
        {
            if (parameter is DirectoryViewModel directoryViewModel)
            {
                FilePath = directoryViewModel.FullName;
                Name = directoryViewModel.Name;

                DirectoriesAndFiles.Clear();
                var directoryInfo = new DirectoryInfo(FilePath);
                foreach (var directory in directoryInfo.GetDirectories())
                    DirectoriesAndFiles.Add(new DirectoryViewModel(directory));

                foreach (var file in directoryInfo.GetFiles())
                    DirectoriesAndFiles.Add(new FileViewModel(file));

            }
        }

        private void OnClose(object obj)
        {
            Closed?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}