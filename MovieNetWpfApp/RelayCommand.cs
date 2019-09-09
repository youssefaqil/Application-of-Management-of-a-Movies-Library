using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MovieNetWpfApp
{
    public class RelayCommand<T> : ICommand
    {
        #region Fields

        private readonly Action<T> _execute = null;
        private readonly Predicate<T> _canExecute = null;

        #endregion

        #region Constructors

        /// <résumé>
        /// Crée une nouvelle commande pouvant toujours s'exécuter.
        /// </résumé>
        /// <param name="execute">La logique d'exécution.</param>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <résumé>
        ///Crée une nouvelle commande pouvant toujours s'exécuter.
        /// </résumé>
        /// <param name="execute">La logique d'exécution.</param>
        /// <param name="canExecute">TLa logique d'état d'exécution.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute((T)parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

        #endregion
    }
}
