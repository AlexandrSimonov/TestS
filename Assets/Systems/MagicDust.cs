using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MagicDust : MonoBehaviourSingelton<MagicDust> {

    public Text text;
    private int money;

    void Start() {
        money = 200;
    }

    private static void Set(int mon) {
        Instance.money += mon;

        //Возможно нужно сделать событие чтобы в магазине менялось кол-во денег, при покупке и в инвентаре
        Instance.text.text = "" + Instance.money;
    }

    public static void Minus(int mon) {
        if (IsCanBuy(mon)) {
            Set(-mon);
        }
    }

    public static void Plus(int mon) {
        Set(mon);
    }

    public static bool IsCanBuy(int mon) {
        if (Instance.money >= mon)
            return true;

        Notification.CreateNotification(Notification.NotificationPriority.Middle, "Недостаточно денег");
        return false;
    }
}
