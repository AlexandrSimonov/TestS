using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    public ItemInInventory itemSectionPrefab;
    public GameObject inventoryParent;

    public int currentCountItem = 0;
    public float currentWeight = 0;

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

    public void AddItem(Item item) {
        if (IsCanTake(item)) {
            Debug.Log("Item add");
            foreach (ItemInInventory section in items) {
                if (section.item == null) {
                    currentWeight += item.weight;
                    currentCountItem++;
                    section.SetItem(item);
                    break;
                }
            }
        }
    }

    public bool IsCanTake(Item item) {
        if (currentWeight + item.weight > maxWeight) {
            DialogSystem.AddMessage("Слишком большой вес", 2);
            return false;
        }

        if (currentCountItem + 1 > maxCountItem) {
            DialogSystem.AddMessage("Недостаточно места в сумке", 2);
            return false;
        }

        

        return true;
    }

    public void GetItemName() {
        if (selectedItem != null) {
            Debug.Log(selectedItem.item.itemName);
        }
    }
}
