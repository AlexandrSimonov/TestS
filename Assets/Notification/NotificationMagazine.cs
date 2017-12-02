using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class NotificationMagazine : MonoBehaviourSingelton<NotificationMagazine> {


    private RxList<Notification> notifications;

    private void Awake() {
        notifications = new RxList<Notification>();
    }

    public static RxList<Notification>.RxEvent OnAddEvent {
        get {
            return Instance.notifications.OnAddEvent;
        }
    }

    public static RxList<Notification>.RxEvent OnRemoveEvent {
        get {
            return Instance.notifications.OnAddEvent;
        }
    }

    public static void AddNotification(Notification notification) {
        Instance.notifications.RxAdd(notification);
    }

    public static void RemoveNotification(Notification notification) {
        Instance.notifications.RxRemove(notification);
    }

    public class NotificationEvent : UnityEvent<Notification> { }
}
