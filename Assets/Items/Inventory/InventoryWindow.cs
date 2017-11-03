using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryWindow : ItemWindow {

    public Transform parentForObject;

    public ItemInGrid prefabObj;

    public Inventory inventory;
    public Item selected;

    [HideInInspector]
    public UnityEvent SelectEvent;

    [HideInInspector]
    public UnityEvent CloseEvent;

    private void Start() {
        for (int i = 0; i < inventory.items.Count; i++) {
            Instantiate(prefabObj.gameObject, parentForObject)
            .GetComponent<ItemInGrid>()
            .Init(inventory.items[i], i, SetSelectedItem, CloseSelect, Activate);
        }

        inventory.addItemEvent.AddListener(InventoryAddItem);
        inventory.removeItemEvent.AddListener(InventoryRemoveItem);
    }

    public void InventoryRemoveItem(Item item) {
        foreach (Transform go in parentForObject) {
            if (go.GetComponent<ItemInGrid>().item == item) {
                Destroy(go.gameObject);
                break;
            }
        }
    }

    // С номерами объектов будет косяк!!! Нужно подрпавить
    public void InventoryAddItem(Item item) {
        Instantiate(prefabObj.gameObject, parentForObject)
            .GetComponent<ItemInGrid>()
            .Init(item, inventory.num, SetSelectedItem, CloseSelect, Activate);
    }

    public void SetSelectedItem(int i) {
        selected = inventory.items[i];
        SelectEvent.Invoke();
    }

    public void CloseSelect() {
        CloseEvent.Invoke();
    }


    public void ActivateSelected() {
        ActivateItem(selected);
    }

    public void Activate(int num) {
        ActivateItem(inventory.items[num]);
    }

    private void ActivateItem(Item item) {
        item.Activate();
    }
    
    //Если предмет дейтсвительно нужно выбросить
    public void ThrowOk() {
        Debug.Log("Предмет выброшен " + selected.itemName);
        inventory.RemoveItem(selected);
        selected = null;
        SelectEvent.Invoke();
    }
    // Вызывается событием 
    public void ThrowSelected() {
        WindowConfirm.Open("Выбрасывание предмета", "Вы уверенны, что хотите выбросить предмет " + selected.itemName + "?", ThrowOk, null);
    }

    // Колдование, вызывается событием 
    public void CastSpellSelected() {
        CastSpell(selected);
    }

    // Вызывается для заколдования предмета
    private void CastSpell(Item item) {
        item.CastSpell();
    }


    

}
