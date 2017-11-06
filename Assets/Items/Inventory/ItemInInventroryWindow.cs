using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemInInventroryWindow : MonoBehaviour, IDropHandler {

    public Text itemName;
    public RawImage itemImage;

    public Texture emptyTexture;

    public InventoryWindow window;

    public InventoryWindow.InventoryWindowSection item;

    public void Init(InventoryWindow.InventoryWindowSection item, InventoryWindow window) {
        this.item = item;
        this.window = window;
    }

    // Вызывается когда предмет изменился и нужен "ререндер"
    void Update() {
        if (item != null && item.item != null) {
            itemImage.texture = item.item.sprite;
            itemName.text = item.item.itemName;
        } else {
            itemImage.texture = emptyTexture;
            itemName.text = "";
        }
    }

    public void Select() {
        window.SetSelectedItem(this.item);
    }
    public void Activate() {
        
    }

    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag.GetComponent<ItemInInventroryWindow>().item.item == null) {
            return;
        }
        window.Move(eventData.pointerDrag.GetComponent<ItemInInventroryWindow>().item, this.GetComponent<ItemInInventroryWindow>().item);
    }

}
