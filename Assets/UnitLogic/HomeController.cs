using UnityEngine;

public class HomeController : MonoBehaviour {

    private Hp hp;


    void Start() {
        hp = GetComponent<Hp>();

        hp.OnHpChangeMinusEvent.AddListener(AttackNotification);

        hp.OnHpDieEvent.AddListener(HomeDie);
    }

    private void AttackNotification(float healthPoint) {
        if (hp.hp > 50) {
            NotificationMagazine.AddNotification(new Notification(Notification.NotificationPriority.Middle, "Ваш дом атакуют"));
        } else if (hp.hp <= 50 && hp.hp > 20) {
            NotificationMagazine.AddNotification(new Notification(Notification.NotificationPriority.Middle, "Ваш дом имеет меньше половины здоровья"));
        } else {
            NotificationMagazine.AddNotification(new Notification(Notification.NotificationPriority.High, "Ваш дом почти разрушен"));
        }
    }

    private void HomeDie() {
        Game.GameOver();
        Debug.Log("Вы проиграли");
    }

    void Update() {
    }

}
