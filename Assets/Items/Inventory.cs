using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

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

    private List<ItemInInventory> items = new List<ItemInInventory>();


    void Start() {
        
    }

    public void ItemSelect(ItemInInventory item) {
        if (selectedItem != null) {
            selectedItem.Close();
        }     
   
        selectedItem = item;

        itemSelected.Invoke();
    }

    // Подумать, что если добавляется несколько объектов, то есть застаканных
    public void AddItem(Item item) {
        if (IsCanTake(item)) {
            Debug.Log("Item add");

            if (item.stacked) {

                //Ищем ему пару, если пара найдена и всё ок добавляем к паре

                foreach (ItemInInventory inventoryItem in items) {
                    Debug.Log(item == inventoryItem.item);
                    if (item == inventoryItem.item && inventoryItem.count + 1 <= item.stackedMax) {
                        inventoryItem.CountChange(1);
                        return;
                    }
                }                
            }

            
            ItemInInventory tmpItem = Instantiate(itemSectionPrefab.gameObject, inventoryParent.transform).GetComponent<ItemInInventory>();
            items.Add(tmpItem);
            tmpItem.Init(this, item);
            
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
