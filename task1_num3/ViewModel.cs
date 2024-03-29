using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    public class ViewModel<T> : INotifyPropertyChanged
    {
        private Stack<T> _stack;
        private T _poppedItem;

        public ViewModel()
        {
            _stack = new Stack<T>();
        }

        public T CurrentItem
        {
            get { return _stack.IsEmpty() ? default(T) : _stack.Peek(); }
        }

        public int Count
        {
            get { return _stack.Count; }
        }

        public bool IsEmpty
        {
            get { return _stack.IsEmpty(); }
        }

        public void Push(T item)
        {
            _stack.Push(item);
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
        }

        public T Pop()
        {
            T item = _stack.Pop();
            OnPropertyChanged(nameof(CurrentItem));
            OnPropertyChanged(nameof(Count));
            OnPropertyChanged(nameof(IsEmpty));
            return item;
        }

        public T PoppedItem
        {
            get { return _poppedItem; }
            set
            {
                _poppedItem = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
