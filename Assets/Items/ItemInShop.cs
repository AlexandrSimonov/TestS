using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Serialization;

public class ItemInShop : MonoBehaviour {

    private ItemShopStructure structure;

    private Shop shop;

    public Text costField;
    public Text countField;
    public RawImage imageField;
    public Text nameField;

    public void Init(ItemShopStructure structure, Shop shop) {
        this.structure = structure;
        this.shop = shop;

        costField.text = "" + structure.cost;
        countField.text = "" + structure.count;
        nameField.text = structure.item.itemName;

        imageField.texture = structure.item.sprite;
    }

    public void Buy() {
        if (shop.inventory != null) {
            if (structure.count > 0 && MagicDust.IsCanBuy(structure.cost) && shop.inventory.IsCanTake(structure.item)) {
                MagicDust.Minus(structure.cost);
                structure.count--;
                shop.inventory.AddItem(structure.item);
            }
        }
    }
}
