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
    public GameObject countPanel;

    public Color selectedColor;
    public Color notSelectedColor;

    public void Init(Inventory inventory, Item item) {
        this.inventory = inventory;
        this.item = item;
        // Условия подописовать
        CountChange(1);

        imageField.texture = item.sprite;
        nameField.text = item.itemName;
    }

    void Start() {
        GetComponent<Button>().onClick.AddListener(Select);
    }

    public void Activate() {
        item.Activate();

        if (item.type == Item.ItemType.Consumbles) {
            CountChange(-1);
        }

        //Если оружие или что-то такое, то просто помечать как активное
    }

    public void Throw() {
        Debug.Log("Объект выброшен" + item.itemName);

        // Спрашивать сколько выбросить один все или может часть, показывать ползунок во время вырасывания
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
        activityPanel.SetActive(true);
    }

    public void Close() {
        background.color = notSelectedColor;
        activityPanel.SetActive(false);
    }

}
