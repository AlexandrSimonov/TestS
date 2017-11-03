using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Shop : MonoBehaviour {

    public List<ItemInShop> items;
   
    public ItemInShop itemInShopPrefab;

    public Inventory inventory;


    [HideInInspector]
    public UnityEvent ShopChange;

    void Start() {
        foreach (ItemInShop structure in items) {
            InitItemInShop(structure);
        }

        ShopChange.Invoke();
    }

    public void AddNewItem(ItemInShop structure) {
        items.Add(structure);
        InitItemInShop(structure);

        ShopChange.Invoke();
    }

    public void RemoveItem() {

        ShopChange.Invoke();
    } 

    private void InitItemInShop(ItemInShop structure) {
        //Instantiate(itemInShopPrefab.gameObject, itemContext.parentForObject).GetComponent<ItemInShop>().Init(structure, itemContext, this);
    }

}
