using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class magicDust : MonoBehaviour {

    public Text text;
    private int money;

    void Start() {
        money = 200;
        
    }

    private void Set(int mon) {
        
        money += mon;
        Debug.Log(mon + " + " + money);
        text.text = "" + money;
    }

    //Возвращает true если всё успешно и купить, что-то можно и false если нельзя
    public bool AddMoney(int mon) {
        Debug.Log(mon);
        if (mon < 0) {
            if (money >= mon) {
                Set(mon);
                return true;
            } else {
                return false;
            }
        } else {
            Set(mon);
            return true;
        }
    }
}
