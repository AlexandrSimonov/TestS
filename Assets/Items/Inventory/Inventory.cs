﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    public int maxCountItem;
    public float maxWeight;

    private int currentCountItem = 0;
    private float currentWeight = 0;

    public GameObject Owner;
    public GameObject Parent;
    private Transform world;

    public List<Item> itemInit = new List<Item>();

    //Вот этот участок не прошел проверку) на вшивость)
    // Протестировать эти вызовы из инвентаря
    public RxList<Item> items = new RxList<Item>();

    void Awake() {

        foreach (Item item in itemInit) {
            Item itemCreate = Instantiate(item, Parent.transform); // ВОт тут нужен "физический" рюкзак
            itemCreate.gameObject.SetActive(false);
            AddItem(itemCreate);
        }

        itemInit = null;
        world = GameObject.FindGameObjectWithTag("World").transform;
    }

    public void AddItem(Item item) {
        if (IsCanTake(item)) {
            item.SetOwner(Owner);
            items.Add(item);
        }
    }

    public void RemoveItem(Item item) {
        item.SetOwner(null);
        items.Remove(item);
    }

    // Вот сюда попадает на самом деле префаб почему-то как item
    // ПОдумать над неидеальностью
    public void ThrowItem(Item item) {
        // Сгенерировать модель 3д ВОТ тут лажа и нужно придумать что-то
        item.transform.SetParent(world);
        item.gameObject.SetActive(true);
        RemoveItem(item);
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
