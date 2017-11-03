using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class ItemInInventroryWindow : ItemInGrid {

    public Text itemName;
    public RawImage itemImage;

    void Update() {
        itemImage.texture = item.sprite;
        itemName.text = item.itemName;

    }
}
