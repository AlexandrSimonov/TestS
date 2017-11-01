using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Вот эту штуку нужно пределать, чтобы можно было сразу несколько вещей покупать
public class ItemInInventory : ItemInGrid {

    public int count;
    /*public Text countField;
    public GameObject countPanel;*/

    public void Init(Inventory inventory, Item item) {
        base.Init(item);

        this.item = item;
        CountChange(1);
    }

    public void Activate() {
        item.Activate();

        if (item.type == Item.ItemType.Consumbles) {
            CountChange(-1);
        }

        //Если оружие или что-то такое, то просто помечать как активное
    }

    // Вызывается из панель
    public void ThrowObject(int count) {
        Debug.Log("Выбросить " + count + " предметов");
        // Вот тут вот создать объект кинуть его на сцену, придать толчек, все дела
        //Нужно инвентарю сообщить что объект выброшен
    }
    
    public void Throw() {
        ThrowPanel.Open(this);
    }

    public void CountChange(int i) {
        this.count += i;

        if (count == 0) {
            Destroy(this.gameObject);
            return;
        } 
    }
    
    public void Sell() {
        Debug.Log("Продать предмет");
    }

    public override string GenerateDescription() {
        return "Этот предмет в инвентаре";
    }

    public override ActivityButton[] GenerateActivityButton() {
        return new ActivityButton[] {
            new ActivityButton {
                btnEvent = Sell,
                btnName = "Sell"
            },
            new ActivityButton {
                btnEvent = Throw,
                btnName = "Throw"
            },
            new ActivityButton {
                btnEvent = Activate,
                btnName = "Activate"
            }
        };
    }
}
