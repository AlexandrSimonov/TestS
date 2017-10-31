using UnityEngine;
using System.Collections.Generic;

public class Shop : WindowMonoBehaviour {

    public List<ItemShopStructure> items;

    public Transform parentShop;
    public ItemInShop itemInShopPrefab;

    public Inventory inventory;

    void Start() {
        foreach (ItemShopStructure structure in items) {
            InitItemInShop(structure);
        }
    }

    public void AddNewItem(ItemShopStructure structure) {
        items.Add(structure);
        InitItemInShop(structure);
    }

    private void InitItemInShop(ItemShopStructure structure) {
        Instantiate(itemInShopPrefab.gameObject, parentShop).GetComponent<ItemInShop>().Init(structure, this);
    }

}
