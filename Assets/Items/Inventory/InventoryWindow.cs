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
            Instantiate(prefabObj.gameObject, parentForObject).GetComponent<ItemInGrid>().Init(inventory.items[i], i, SetSelectedItem, CloseSelect);
        }
    }

    public void SetSelectedItem(int i) {
        selected = inventory.items[i];
        SelectEvent.Invoke();
    }

    public void CloseSelect() {
        CloseEvent.Invoke();
    }

    public void ActivateSelected() {
        //ActivateItem(selected);
    }

    public void CastSpellSelected() {
        CastSpell(selected);
    }

    public void Activate(int num) {
        //ActivateItem(inventory.GetItems()[num]);
    }

    private void ActivateItem(Item item) {
        item.Activate();
    }

    public void Throw() { }

    public void CastSpell(Item item) {
        item.CastSpell();
    }
}
