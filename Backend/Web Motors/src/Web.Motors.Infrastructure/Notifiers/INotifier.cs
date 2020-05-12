using System.Collections.Generic;

namespace Web.Motors.Infrastructure.Notifiers
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void SetNotification(Notification notification);
    }
}
