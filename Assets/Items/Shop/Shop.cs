using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class Shop : MonoBehaviour {

    public List<ItemShopStructure> items;

    public ItemContext itemContext;
    public ItemInShop itemInShopPrefab;

    public Inventory inventory;


    [HideInInspector]
    public UnityEvent ShopChange;

    void Start() {
        foreach (ItemShopStructure structure in items) {
            InitItemInShop(structure);
        }

        ShopChange.Invoke();
    }

    public void AddNewItem(ItemShopStructure structure) {
        items.Add(structure);
        InitItemInShop(structure);

        ShopChange.Invoke();
    }

    public void RemoveItem() {

        ShopChange.Invoke();
    } 

    private void InitItemInShop(ItemShopStructure structure) {
        //Instantiate(itemInShopPrefab.gameObject, itemContext.parentForObject).GetComponent<ItemInShop>().Init(structure, itemContext, this);
    }

}
