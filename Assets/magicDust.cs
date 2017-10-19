using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class magicDust : MonoBehaviour {

    public Text text;
    private static magicDust instance;
    private int money;

    void Start() {
        money = 200;
        instance = this;
    }

    private static void Set(int mon) {
        
        instance.money += mon;
        Debug.Log(mon + " + " + instance.money);
        instance.text.text = "" + instance.money;
    }

    //Возвращает true если всё успешно и купить, что-то можно и false если нельзя
    public static void AddMoney(int mon) {
        Debug.Log(mon);
        if (mon < 0) {
            if (instance.money >= mon) {
                Set(mon);
            } 
        } else {
            Set(mon);
        }
    }
}
