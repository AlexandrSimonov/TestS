using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class NotificationMagazine : MonoBehaviourSingelton<NotificationMagazine> {


    private List<Notification> notifications;

    public NotificationEvent OnAddNotification;
    public NotificationEvent OnRemoveNotification;

    private void Start() {
        notifications = new List<Notification>();
    }

    public static NotificationEvent GetAddEvent() {
        return Instance.OnAddNotification;
    }

    public static NotificationEvent GetRemoveEvent() {
        return Instance.OnRemoveNotification;
    }

    public static void AddNotification(Notification notification) {
        Instance.notifications.Add(notification);

        Instance.OnAddNotification.Invoke(notification);
    }

    public static void RemoveNotification(Notification notification) {
        Instance.notifications.Remove(notification);

        Instance.OnRemoveNotification.Invoke(notification);
    }

    public class NotificationEvent : UnityEvent<Notification> { }
}
