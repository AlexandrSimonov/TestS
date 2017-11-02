using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    private int currentCountItem = 0;
    private float currentWeight = 0;

    public GameObject Player;

    private List<ItemInInventoryStructure> items = new List<ItemInInventoryStructure>();

    [HideInInspector]
    public UnityEvent InventoryChange;

    void Start() {
        foreach (ItemInInventoryStructure structure in items) {
            structure.item.SetPlayer(Player);
            structure.changeEvent = InventoryChange;
        }


        InventoryChange.Invoke();
    }
    // Тут нужно сделать так чтобы у нас был массив предметов в инвентаре, которые не проинициализированы
    public void AddItem(Item item, int count) {
        /*if (IsCanTake(item)) {
            if (item.stacked) {
                foreach (ItemInInventory inventoryItem in items) {
                    Debug.Log(item == inventoryItem.item);
                    if (item == inventoryItem.item && inventoryItem.count + 1 <= item.stackedMax) {
                        inventoryItem.CountChange(1);
                        return;
                    }
                }                
            }
         }*/

        item.SetPlayer(Player);

        items.Add(new ItemInInventoryStructure {
            item = item,
            count = count,
            changeEvent = InventoryChange
        });

        InventoryChange.Invoke();
    }

    public void RemoveItem(Item item) {
        InventoryChange.Invoke();
    }

    public List<ItemInInventoryStructure> GetItems() {
        return items;
    }

    // Тут не трогаем, тут всё норм
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
