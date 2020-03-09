using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MiniMvvm
{
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T source, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(source, newValue))
            {
                return false;
            }
            
            source = newValue;
            NotifyPropertyChanged(propertyName);

            return true;
        }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
