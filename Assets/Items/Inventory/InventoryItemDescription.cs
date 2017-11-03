using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class InventoryItemDescription : MonoBehaviour {

    public InventoryWindow window;

    public Text nameField;
    public RawImage imageField;

    public Text itemCount;

    public void Awake() {
        window.SelectEvent.AddListener(Open);
        window.CloseEvent.AddListener(Close);

        gameObject.SetActive(false);
    }

    public void Open() {
        gameObject.SetActive(true);

        Render();
    }

    public void Close() {
        if (window.selected == null) {
            gameObject.SetActive(false);
        }
    }

    public void Render() {
        if (window.selected != null) {
            nameField.text = window.selected.itemName;
            imageField.texture = window.selected.sprite;

            window.selected.ChangeEvent.AddListener(Render);
        } else {
            Close();
        }
    }
}
