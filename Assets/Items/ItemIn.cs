using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemIn : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, ITrashed {

    public Text itemName;
    public RawImage itemImage;
    public Texture emptyTexture;

    [HideInInspector]
    public InventoryWindow window;

    [HideInInspector]
    public InventoryWindow.InventoryWindowSection selfItem;

    public void Init(InventoryWindow.InventoryWindowSection item, InventoryWindow window) {
        this.selfItem = item;
        this.window = window;
    }

    protected virtual void SetEmptySection() {
        itemImage.texture = emptyTexture;
        itemName.text = "";
    }

    private bool dragging = false;

    protected virtual void Update() {
        if (dragging) {
            SetEmptySection();
        } else {
            if (selfItem != null && selfItem.item != null) {
                itemImage.texture = selfItem.item.sprite;
                itemName.text = selfItem.item.itemName;
            } else {
                SetEmptySection();
            }
        }
    }

    public virtual void OnBeginDrag(PointerEventData pointer) {
        if (pointer.pointerDrag.GetComponent<ItemIn>().selfItem.item != null) {
            window.tooltip.Activate(this.gameObject);
            dragging = true;
        }
    }

    public virtual void OnEndDrag(PointerEventData pointer) {
        window.tooltip.DeActivate();
        dragging = false;
    }

    public virtual void OnDrag(PointerEventData pointer) {}

    public virtual void OnDrop(PointerEventData pointer) {
        ItemIn com = pointer.pointerDrag.GetComponent<ItemIn>();
        if (com != null && com.selfItem.item != null) {
            window.Move(GetComponent<ItemIn>().selfItem, pointer.pointerDrag.GetComponent<ItemIn>().selfItem);
            window.SetSelectedItem(this.selfItem);
        }
    }

    public virtual void Select() {
        window.SetSelectedItem(this.selfItem);
    }

    public virtual void Trashed() {
        window.Throw(selfItem);
    }
}
