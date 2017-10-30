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
    public GameObject activityPanel;

    public Color selectedColor;
    public Color notSelectedColor;

    public void Init(Inventory invent) {
        inventory = invent;

        SetItem(null);
    }

    void Start() {
        GetComponent<Button>().onClick.AddListener(Select);
    }

    public void Activate() {
        Debug.Log("Объект активирован" + item.itemName);
    }

    public void Throw() {
        Debug.Log("Объект выброшен" + item.itemName);
    }

    /*public ItemInfo GetInfo() {
        return item.GetComponent<ItemInfo>();
    }*/

    public void Select() {
        if (item != null) {
            inventory.ItemSelect(this);
            background.color = selectedColor;
            activityPanel.SetActive(true);
        } else {
            Debug.Log("Item is null");
        }
    }

    public void Close() {
        background.color = notSelectedColor;
        activityPanel.SetActive(false);
    }

    public void SetItem(Item item) {
        if (item != null && this.item == null) {
            this.item = item;

            imageField.texture = item.sprite;
            //
            countField.text = "" + count;
            //
            nameField.text = item.itemName;
        }
    }
}
