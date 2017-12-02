using UnityEngine;
using System.Collections;

public class Notification {

    public enum NotificationPriority {
        Low,
        Middle,
        High
    };

    public NotificationPriority priority;
    public string text;

    public Notification(NotificationPriority priority, string text) {
        this.priority = priority;
        this.text = text;
    }

    public static void CreateNotification(NotificationPriority priority, string text) {
        Notification notification = new Notification(priority, text);

        NotificationMagazine.AddNotification(notification);
    }

    public void Delete() {
        NotificationMagazine.RemoveNotification(this);
    }
}
