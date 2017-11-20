using UnityEngine;
using System.Collections;

public class NotificationList : MonoBehaviour {

    void Start() {
        NotificationMagazine.GetAddEvent().AddListener(AddNotification);
        NotificationMagazine.GetRemoveEvent().AddListener(RemoveNotification);
    }


    private void AddNotification(Notification notification) {
        // Instantiate обджект и т.д
        // Вот тут устанавливается таймер, чтобы удалять из листа по тику времени
    }

    private void RemoveNotification(Notification notification) {
        // Destroy обджект и т.д
    }

    
}
