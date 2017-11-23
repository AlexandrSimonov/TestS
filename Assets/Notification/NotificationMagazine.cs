using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class NotificationMagazine : MonoBehaviourSingelton<NotificationMagazine> {


    private RxList<Notification> notifications;

    private void Start() {
        notifications = new RxList<Notification>();
    }

    public static RxList<Notification>.RxEvent GetAddEvent() {
        return Instance.notifications.OnAddEvent;
    }

    public static RxList<Notification>.RxEvent GetRemoveEvent() {
        return Instance.notifications.OnRemoveEvent;
    }

    public static void AddNotification(Notification notification) {
        Instance.notifications.Add(notification);
    }

    public static void RemoveNotification(Notification notification) {
        Instance.notifications.Remove(notification);
    }

    public class NotificationEvent : UnityEvent<Notification> { }
}
