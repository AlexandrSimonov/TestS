using UnityEngine;
using System.Collections;

public class NotificationList : MonoBehaviour {

    public NotificationDisplay notificationObject;
    public Transform notificationParent;

    void Start() {
        NotificationMagazine.OnAddEvent.AddListener(AddNotification);
    }


    private void AddNotification(Notification notification) {
        NotificationDisplay go = Instantiate(notificationObject, notificationParent);
        go.Init(notification);
    }

}
