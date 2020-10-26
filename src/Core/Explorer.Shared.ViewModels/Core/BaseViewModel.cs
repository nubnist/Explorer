using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Explorer.Shared.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region ProtectedMethods

        protected void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion
    }
}