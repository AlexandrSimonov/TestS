﻿using UnityEngine;
using System.Collections;


// Тут отображаем как показываются уведомления в журнале уведомлений
public class NotificationMagazineWindow : MonoBehaviour {

    public GameObject window;

    // Use this for initialization
    void Start() {
        NotificationMagazine.OnAddEvent.AddListener(AddNotification);
        NotificationMagazine.OnRemoveEvent.AddListener(RemoveNotification);
    }


    private void AddNotification(Notification notification) {
        // Instantiate обджект и т.д
    }

    private void RemoveNotification(Notification notification) {
        // Destroy обджект и т.д
    }

}
