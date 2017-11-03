using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ItemInInventroryWindow : ItemInGrid {

    public Text itemName;
    public RawImage itemImage;

    // Вызывается когда предмет изменился и нужен "ререндер"
    public override void Render() {
        itemImage.texture = item.sprite;
        itemName.text = item.itemName;
    }
}
