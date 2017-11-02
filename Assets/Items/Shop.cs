using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

    public List<ItemShopStructure> items;

    public ItemContext itemContext;
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
        Instantiate(itemInShopPrefab.gameObject, itemContext.parentForObject).GetComponent<ItemInShop>().Init(structure, itemContext, this);
    }

}
