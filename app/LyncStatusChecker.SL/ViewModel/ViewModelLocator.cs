using GalaSoft.MvvmLight.Ioc;
using LyncStatusChecker.SL.Model.Repository;
using LyncStatusChecker.SL.Model.Service;
using LyncStatusChecker.SL.ViewModel.Notification;
using Microsoft.Practices.ServiceLocation;
using RestSharp;

namespace LyncStatusChecker.SL.ViewModel
{
    public class ViewModelLocator
    {
        private const string ServiceUrl = "http://starmind.luware.net:9310";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IRestClient>(() => new RestClient(ServiceUrl));
            SimpleIoc.Default.Register<IPresenceRepository, PresenceRepository>();
            SimpleIoc.Default.Register<PresenceService>();
            SimpleIoc.Default.Register<INotificationService, NotificationService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public static MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}