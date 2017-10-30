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

        //Возможно нужно сделать событие чтобы в магазине менялось кол-во денег, при покупке и в инвентаре
        instance.text.text = "" + instance.money;
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
        if (instance.money >= mon) return true;
        DialogSystem.AddMessage("Недостаточно денег", 2);
        return false;
    }
}
