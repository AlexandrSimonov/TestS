using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryWindow : ItemWindow {

    public Transform parentForObject;

    public ItemInInventroryWindow prefabObj;

    public Inventory inventory;
    public ItemInInventoryWindowGrid selected;

    private List<ItemInInventoryWindowGrid> inventoryWindowItems;

    private void Start() {
        inventoryWindowItems = new List<ItemInInventoryWindowGrid>();

        // Иницилизируем список с индексами и пустыми ItemInInventoryWindowGrid, здесь же создаем префабы для отображения айтемов
        for (int i = 0; i < inventory.maxCountItem; i++) {
            inventoryWindowItems.Add(new ItemInInventoryWindowGrid {
                item = null,
                count = 0,
                index = i
            });

            ItemInInventroryWindow obj = Instantiate(prefabObj, parentForObject);
            obj.Init(inventoryWindowItems[i], this);
        }

        // Добавляем в предметы, которые находяться в инвентаре
        for (int i = 0; i < inventory.items.Count; i++) {
            InventoryAddItem(inventory.items[i]);
        }

        // Слушатель на добавление новых предметов
        inventory.addItemEvent.AddListener(InventoryAddItem);
        //inventory.removeItemEvent.AddListener(InventoryRemoveItem);
    }

    /*public void InventoryRemoveItem(Item item) {
        foreach (Transform go in parentForObject) {
            if (go.GetComponent<ItemInGrid>().item == item) {
                Destroy(go.gameObject);
                break;
            }
        }
    }*/

    public void InventoryAddItem(Item item) {
        ItemInInventoryWindowGrid emptySection = null;

        for (int i = 0; i < inventoryWindowItems.Count; i++) {
            if (inventoryWindowItems[i].item == item && inventoryWindowItems[i].item != null) {
                inventoryWindowItems[i].count++;
                return;
            }
            if (inventoryWindowItems[i].item == null && inventoryWindowItems[i].count == 0 && emptySection == null) {
                emptySection = inventoryWindowItems[i];  
            }
        }
    
        emptySection.item = item;
        emptySection.count = 1;
    }

    public void SetSelectedItem(ItemInInventoryWindowGrid item) {
        selected = item;
    }

    public void ActivateSelected() {
        //ActivateItem(selected);
    }

    public void Activate(int num) {
        ActivateItem(inventory.items[num]);
    }

    private void ActivateItem(Item item) {
        item.Activate();
    }
    
    //Если предмет дейтсвительно нужно выбросить
    public void ThrowOk() {
        //Debug.Log("Предмет выброшен " + selected.itemName);
        //inventory.RemoveItem(selected);
        selected = null;
    }
    // Вызывается событием 
    public void ThrowSelected() {
        //WindowConfirm.Open("Выбрасывание предмета", "Вы уверенны, что хотите выбросить предмет " + selected.itemName + "?", ThrowOk, null);
    }

    // Колдование, вызывается событием 
    public void CastSpellSelected() {
        //CastSpell(selected);
    }

    // Вызывается для заколдования предмета
    private void CastSpell(Item item) {
        item.CastSpell();
    }


    [System.Serializable]
    public class ItemInInventoryWindowGrid {
        public Item item;

        public int count;

        public int index;
    } 
}
