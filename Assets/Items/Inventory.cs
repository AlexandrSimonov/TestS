using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    public ItemInInventory itemSectionPrefab;

    public ItemContext itemContext;

    private int currentCountItem = 0;
    private float currentWeight = 0;

    public GameObject Player;

    private List<ItemInInventory> items = new List<ItemInInventory>();

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

            
            ItemInInventory tmpItem = Instantiate(itemSectionPrefab.gameObject, itemContext.parentForObject).GetComponent<ItemInInventory>();
            items.Add(tmpItem);
            tmpItem.Init(item, itemContext, this);
            tmpItem.item.Init(Player);
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

}
