using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public abstract class ItemInGrid : MonoBehaviour {
    public Item item;   

    // Select
    public Color selectedColor;
    public Color notSelectedColor;
    public Image background;

    // Отображение маленькой фигни
    public RawImage imageField;
    public Text textField;

    public ItemContext context;


    public virtual void Init(Item item, ItemContext context) {
        imageField.texture = item.sprite;
        textField.text = item.itemName;
        this.item = item;
        this.context = context;
    }

    public void Select() {
        Debug.Log("Выбран");
        background.color = selectedColor;
        context.itemDescription.Open(this);
    }

    public void Close() {
        Debug.Log("Выбор отменен");
        background.color = notSelectedColor;
        context.itemDescription.Close();
    }

    // Переопределяем в shop, чтобы добавить цену к описанию и в inventory, чтобы что-то тоже добавить
    public virtual string GenerateDescription() {
        return "";
    }

    public virtual ActivityButton[] GenerateActivityButton() {
        return null;   
    }

    public class ActivityButton {
        public string btnName;
        public UnityAction btnEvent;
    }
}
