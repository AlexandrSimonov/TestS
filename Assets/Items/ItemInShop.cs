using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Serialization;

public class ItemInShop : ItemInGrid {

    private ItemShopStructure structure;

    private Shop shop;

    /*public Text costField;
    public Text countField;*/

    public void Init(ItemShopStructure structure, Shop shop) {
        base.Init(structure.item);

        this.structure = structure;
        this.shop = shop;
    }

    public void Buy() {
        if (shop.inventory != null) {
            if (structure.count > 0 && MagicDust.IsCanBuy(structure.cost) && shop.inventory.IsCanTake(structure.item)) {
                MagicDust.Minus(structure.cost);
                ChangeCount(-1);
                shop.inventory.AddItem(structure.item);
            }
        }
    }
    // Нужно изменять при действиях
    private void ChangeCount(int count) {
        structure.count += count;
    }
    // Вот тут генерируется описание для предметов в магазине (сколько осталось и т.д)
    public override string GenerateDescription() {
        return "Этот предмет в магазине";
    }

    public override ActivityButton[] GenerateActivityButton() {
        return new ActivityButton[] {
            new ActivityButton {
                btnEvent = Buy,
                btnName = "Buy"
            }
        };
    }
}
