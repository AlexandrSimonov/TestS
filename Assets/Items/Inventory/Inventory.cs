using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    private int currentCountItem = 0;
    private float currentWeight = 0;

    public GameObject Owner;

    public List<Item> itemInit = new List<Item>();

    public List<Item> items = new List<Item>();

    [HideInInspector]
    public AddItemEvent addItemEvent;
    [HideInInspector]
    public RemoveItemEvent removeItemEvent;

    void Awake() {
        foreach (Item item in itemInit) {
            AddItem(item.GetCopy());
        }
    }

    public void AddItem(Item item) {
        if (IsCanTake(item)) {
            item.SetOwner(Owner);
            items.Add(item);
            addItemEvent.Invoke(item);
        }

    }

    public void RemoveItem(Item item) {
        item.SetOwner(null);
        removeItemEvent.Invoke(item);
        items.Remove(item);
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

    [System.Serializable]
    public class AddItemEvent : UnityEvent<Item> {}

    [System.Serializable]
    public class RemoveItemEvent : UnityEvent<Item> { }
}
