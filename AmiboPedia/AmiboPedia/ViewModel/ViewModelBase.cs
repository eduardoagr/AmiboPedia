using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AmiboPedia.ViewModel {
    public class ViewModelBase : INotifyPropertyChanged {

        // This is very handy when requesting data from an api, and let the UI know
        private bool _IsBusy;
        public bool IsBusy {
            get { return _IsBusy; }
            set {
                if (_IsBusy != value) {
                    _IsBusy = value;
                    RaisePropertyChanged();
                }
            }
        }

        #region Notify Property Changed Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
