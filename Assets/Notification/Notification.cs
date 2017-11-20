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

        NotificationMagazine.AddNotification(this);
    }

    public void Delete() {
        NotificationMagazine.RemoveNotification(this);
    }
}
