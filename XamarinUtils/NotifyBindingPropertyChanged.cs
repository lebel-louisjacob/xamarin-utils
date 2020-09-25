using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XamarinUtils
{
    public abstract class NotifyBindingPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void UpdateBinding<A, B>(ref A currentValue, in B newValue, [CallerMemberName] in string propertyName = "")
            where B : A
        {
            if (!newValue.Equals(currentValue))
            {
                currentValue = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] in string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
