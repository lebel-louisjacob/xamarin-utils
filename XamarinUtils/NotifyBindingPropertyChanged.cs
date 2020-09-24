using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinUtils
{
    public abstract class NotifyBindingPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateBinding<A>(ref A currentValue, in A newValue, [CallerMemberName] in string propertyName = "")
        {
            if (!newValue.Equals(currentValue))
            {
                currentValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
