using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryWindow : ItemWindow {

    public Transform gridParent;
    public Transform listParent;

    public ToolTip tooltip;

    public ItemInInventroryWindow prefabGridItem;
    public ItemInInventroryWindow prefabListItem;

    public Inventory inventory;
    public InventoryWindowSection selected;

    private List<InventoryWindowSection> inventoryWindowItems;

    private void Start() {
        inventoryWindowItems = new List<InventoryWindowSection>();

        // Иницилизируем список с индексами и пустыми ItemInInventoryWindowGrid, здесь же создаем префабы для отображения айтемов
        for (int i = 0; i < inventory.maxCountItem; i++) {
            inventoryWindowItems.Add(new InventoryWindowSection {
                item = null,
                index = i
            });
            
            // В таблицу
            ItemInInventroryWindow obj = Instantiate(prefabGridItem, gridParent);
            obj.Init(inventoryWindowItems[i], this);

            // В список
            ItemInInventroryWindow obj2 = Instantiate(prefabListItem, listParent);
            obj2.Init(inventoryWindowItems[i], this);
        }

        // Добавляем в предметы, которые находяться в инвентаре
        for (int i = 0; i < inventory.items.Count; i++) {
            InventoryAddItem(inventory.items[i]);
        }

        // Слушатель на добавление новых предметов
        inventory.addItemEvent.AddListener(InventoryAddItem);
        inventory.removeItemEvent.AddListener(InventoryRemoveItem);
    }

    public void InventoryRemoveItem(Item item) {
        for (int i = 0; i < inventoryWindowItems.Count; i++) {
            if (inventoryWindowItems[i].item == item && inventoryWindowItems[i].item != null) { 
                inventoryWindowItems[i].item = null;
                return;
            }  
        }
    }

    public void InventoryAddItem(Item item) {
        InventoryWindowSection emptySection = null;

        for (int i = 0; i < inventoryWindowItems.Count; i++) {
            if (inventoryWindowItems[i].item == null && emptySection == null) {
                emptySection = inventoryWindowItems[i];  
            }
        }
    
        emptySection.item = item;
    }

    public void SetSelectedItem(InventoryWindowSection item) {
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
        inventory.ThrowItem(selected.item);
        selected = null;
    }
    // Вызывается событием 
    public void ThrowSelected() {
        WindowConfirm.Open("Выбрасывание предмета", "Вы уверенны, что хотите выбросить предмет " + selected.item.itemName + "?", ThrowOk, null);
    }

    public void Throw(InventoryWindowSection item) {
        WindowConfirm.Open("Выбрасывание предмета", "Вы уверенны, что хотите выбросить предмет " + item.item.itemName + "?", ThrowOk, null);
    }

    // Колдование, вызывается событием 
    public void CastSpellSelected() {
        CastSpell(selected.item);
    }

    // Вызывается для заколдования предмета
    private void CastSpell(Item item) {
        item.CastSpell();
    }


    // Вот этот метод должен остаться все остальные могут быть удалены, кроме методов работы с массивом item'ов
    public void Move(InventoryWindowSection item1, InventoryWindowSection item2) {
        Item tmp = item1.item;
        item1.item = item2.item;
        item2.item = tmp;
    }

    [System.Serializable] // Вот эта штука выполняет роль ячейки
    public class InventoryWindowSection {
        public Item item;

        public int index;
    } 
}
