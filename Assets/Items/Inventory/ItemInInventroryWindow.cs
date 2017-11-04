using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ItemInInventroryWindow : MonoBehaviour {

    public Text itemName;
    public RawImage itemImage;
    public int count;
    public InventoryWindow window;

    public InventoryWindow.ItemInInventoryWindowGrid item;

    public void Init(InventoryWindow.ItemInInventoryWindowGrid item, InventoryWindow window) {
        this.item = item;
        this.window = window;
    }

    // Вызывается когда предмет изменился и нужен "ререндер"
    void Update() {
        if (item != null && item.item != null) {
            itemImage.texture = item.item.sprite;
            itemName.text = item.item.itemName;
            count = item.count;
        } 
    }

    public void Select() {
        window.SetSelectedItem(this.item);
    }
}
