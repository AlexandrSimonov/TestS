using UnityEngine;

public class HomeController : MonoBehaviour {

    private Hp hp;

    void Start() {
        hp = GetComponent<Hp>();

        hp.OnHpChangeMinusEvent.AddListener(AttackNotification);
        hp.OnHpChangeMinusEvent.AddListener(AttackDebug);
        hp.OnHpDieEvent.AddListener(HomeDie);
    }

    private void AttackNotification(float healthPoint) {
        if (hp.hp > 50) {
            Notification.CreateNotification(Notification.NotificationPriority.Middle, "Ваш дом атакуют");
        } else if (hp.hp <= 50 && hp.hp > 20) {
            Notification.CreateNotification(Notification.NotificationPriority.Middle, "Ваш дом имеет меньше половины здоровья");
        } else {
            Notification.CreateNotification(Notification.NotificationPriority.High, "Ваш дом почти разрушен");
        }
    }

    private void AttackDebug(float healthPoint) {
        Debug.Log(hp.hp);
    }

    private void HomeDie() {
        Game.GameOver();

        Debug.Log("Вы проиграли");
    }

}
