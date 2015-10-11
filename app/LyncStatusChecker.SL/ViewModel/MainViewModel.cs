using System;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using LyncStatusChecker.SL.Model.Enum;
using LyncStatusChecker.SL.Model.Exceptions;
using LyncStatusChecker.SL.Model.Service;
using LyncStatusChecker.SL.ViewModel.Command;
using LyncStatusChecker.SL.ViewModel.Notification;

namespace LyncStatusChecker.SL.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly PresenceService _presenceService;
        private readonly INotificationService _notificationService;

        public MainViewModel(PresenceService presenceService, INotificationService notificationService)
        {
            if (presenceService == null)
            {
                throw new ArgumentNullException(nameof(presenceService));
            }

            if (notificationService == null)
            {
                throw new ArgumentNullException(nameof(notificationService));
            }

            _presenceService = presenceService;
            _notificationService = notificationService;

            _getPresenceCommand = new AwaitableDelegateCommand(GetPresence);

            SipUri = "sip:mjakob@luware.net";
        }

        private async Task GetPresence()
        {
            try
            {
                var presence = await _presenceService.Get(_sipUri);
                State = presence.State;
            }
            catch (UserNotFoundException e)
            {
                _notificationService.ShowMessage(e.Message);
            }
            catch (ServiceUnavailableException e)
            {
                _notificationService.ShowMessage(e.Message);
            }
        }

        private string _sipUri;
        private LyncStatus _state;
        private readonly ICommand _getPresenceCommand;

        public string SipUri
        {
            get
            {
                return _sipUri;
            }
            set
            {
                if (_sipUri == value)
                {
                    return;
                }

                _sipUri = value;
                _state = LyncStatus.None;
                RaisePropertyChanged(nameof(SipUri));
            }
        }

        public LyncStatus State
        {
            get
            {
                return _state;
            }
            private set
            {
                if (_state == value)
                {
                    return;
                }

                _state = value;
                RaisePropertyChanged(nameof(State));
            }
        }
        
        public ICommand GetPresenceCommand
        {
            get { return _getPresenceCommand; }
        }
    }
}