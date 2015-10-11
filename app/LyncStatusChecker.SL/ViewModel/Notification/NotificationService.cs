using System.Windows;

namespace LyncStatusChecker.SL.ViewModel.Notification
{
    public class NotificationService : INotificationService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}