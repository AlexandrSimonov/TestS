using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MagicDust : MonoBehaviour {

    public Text text;
    private static MagicDust instance;
    private int money;

    void Start() {
        money = 200;
        instance = this;
    }

    private static void Set(int mon) {
        instance.money += mon;
        instance.text.text = "" + instance.money;
    }

    //Возвращает true если всё успешно и купить, что-то можно и false если нельзя
    public static void AddMoney(int mon) {
        if (mon < 0) {
            if (instance.money >= mon) {
                Set(mon);
            } 
        } else {
            Set(mon);
        }
    }
}
