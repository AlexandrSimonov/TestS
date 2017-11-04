using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class InventoryItemDescription : MonoBehaviour {

    public InventoryWindow window;

    public GameObject panel;
    public Text nameField;
    public RawImage imageField;

    public Text itemCount;

    public void Update() {
        if (window.selected != null && window.selected.item != null && window.selected.count != 0) {
            nameField.text = window.selected.item.itemName;
            imageField.texture = window.selected.item.sprite;
            panel.SetActive(true);
        } else {
            panel.SetActive(false);
        }
    }
}
