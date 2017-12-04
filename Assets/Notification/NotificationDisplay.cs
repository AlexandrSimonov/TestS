using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NotificationDisplay : MonoBehaviour {

    public Text text;

    public Color low;
    public Color middle;
    public Color high;

    private float timeDel;

    public void Init(Notification notification) {
        text.text = notification.text;

        Image image = GetComponent<Image>();
        if (notification.priority == Notification.NotificationPriority.Low) {
            image.color = low;
        }

        if (notification.priority == Notification.NotificationPriority.Middle) {
            image.color = middle;
        }

        if (notification.priority == Notification.NotificationPriority.High) {
            image.color = high;
        }

        float time = 0;
        // Потом заменим на какую-то более приемлимую альтернативу

        foreach (char c in notification.text) {
            time += 0.05f;
        }
        time += 1;

        timeDel = Time.time + time;

    }

    private void Update() {
        if (Time.time > timeDel) {
            Destroy(this.gameObject);
        }
    }

}
