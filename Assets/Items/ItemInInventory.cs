using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemInInventory : MonoBehaviour {

    public Item item;
    public int count;

    private Inventory inventory;

    public RawImage imageField;
    public Text countField;
    public Text nameField;
    public Image background;
    public ItemInGrid itemInGrid;// ПОдумать
    public GameObject countPanel;

    public Color selectedColor;
    public Color notSelectedColor;

    public void Init(Inventory inventory, Item item) {
        this.inventory = inventory;
        this.item = item;

        CountChange(1);

        imageField.texture = item.sprite;
        nameField.text = item.itemName;
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
    }
    
    //Запускает ряд событий для выбрасывания
    public void Throw() {
        inventory.throwPanel.Open(this);
    }

    public void CountChange(int i) {
        this.count += i;

        if (count == 0) {
            Destroy(this.gameObject);
            return;
        } 

        countField.text = "" + count;

        if (count == 1) {
            countPanel.SetActive(false);
        } else {
            countPanel.SetActive(true);
        }
    }

    public void Select() {
        inventory.ItemSelect(this);
        background.color = selectedColor;
        
    }

    public void Close() {
        background.color = notSelectedColor;
        itemInGrid.CloseActivityPanel();
        inventory.throwPanel.Close();
    }

}
