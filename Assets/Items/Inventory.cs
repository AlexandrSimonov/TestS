using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    public ItemInInventory itemSectionPrefab;
    public GameObject inventoryParent;

    public int currentCountItem;
    public float currentWeight;

    // Read only
    public ItemInInventory selectedItem;

    public UnityEvent itemSelected;

    private ItemInInventory[] items;


    void Start() {
        items = new ItemInInventory[maxCountItem];

        for (int i = 0; i < maxCountItem; i++) {
            items[i] = Instantiate(itemSectionPrefab.gameObject, inventoryParent.transform).GetComponent<ItemInInventory>();
            items[i].Init(this);
        }
    }

    public void ItemSelect(ItemInInventory item) {
        if (selectedItem != null) {
            selectedItem.Close();
        }     
   
        selectedItem = item;

        itemSelected.Invoke();
    }

    public void GetItemName() {
        if (selectedItem != null) {
            Debug.Log(selectedItem.item.itemName);
        }
    }
}
