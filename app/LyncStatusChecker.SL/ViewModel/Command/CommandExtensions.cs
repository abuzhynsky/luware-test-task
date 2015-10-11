using System.Windows.Input;

namespace LyncStatusChecker.SL.ViewModel.Command
{
    public static class CommandExtensions
    {
        public static void RaiseCanExecuteChanged(this ICommand command)
        {
            var canExecuteChanged = command as IRaiseCanExecuteChanged;

            if (canExecuteChanged != null)
            {
                canExecuteChanged.RaiseCanExecuteChanged();
            }
        }
    }
}