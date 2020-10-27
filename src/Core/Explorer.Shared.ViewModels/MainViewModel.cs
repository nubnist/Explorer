using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region PublicProperties

        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = 
            new ObservableCollection<DirectoryTabItemViewModel>();
        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion

        #region Commands

        public DelegateCommand AddTabItemCommand { get; set; }
        

        #endregion

        #region Events



        #endregion

        #region Constructor

        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);

            AddTabItemViewModel();
        }

        #endregion

        #region ProtectedMethods



        #endregion

        #region PrivateMethods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            vm.Closed += Vm_Closed;

            DirectoryTabItems.Add(vm);
            CurrentDirectoryTabItem = vm;
        }

        private void Vm_Closed(object sender, EventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabViewModel)
            {
                CloseTab(directoryTabViewModel);
            }

        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabViewModel)
        {
            directoryTabViewModel.Closed -= Vm_Closed;

            DirectoryTabItems.Remove(directoryTabViewModel);

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion

        #region CommandsMethods

        private void OnAddTabItem(object Obj) => AddTabItemViewModel();

        #endregion
    }
}
