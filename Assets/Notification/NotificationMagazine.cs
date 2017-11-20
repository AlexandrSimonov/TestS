using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class NotificationMagazine : MonoBehaviour {

    private static NotificationMagazine instance;

    private List<Notification> notifications;

    public NotificationEvent OnAddNotification;
    public NotificationEvent OnRemoveNotification;

    private void Start() {
        instance = this;
        notifications = new List<Notification>();
    }

    public static NotificationEvent GetAddEvent() {
        return instance.OnAddNotification;
    }

    public static NotificationEvent GetRemoveEvent() {
        return instance.OnRemoveNotification;
    }

    public static void AddNotification(Notification notification) {
        instance.notifications.Add(notification);

        instance.OnAddNotification.Invoke(notification);
    }

    public static void RemoveNotification(Notification notification) {
        instance.notifications.Remove(notification);

        instance.OnRemoveNotification.Invoke(notification);
    }

    public class NotificationEvent : UnityEvent<Notification> { }
}
