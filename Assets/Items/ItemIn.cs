using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Вот над этим подумать, если нужно будет менять что-то где-то ещё
public abstract class ItemIn : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, ITrashed {

    public Text itemName;
    public RawImage itemImage;

    public Texture emptyTexture;

    public InventoryWindow window;

    // Переименовать этот item
    public InventoryWindow.InventoryWindowSection item;

    public void Init(InventoryWindow.InventoryWindowSection item, InventoryWindow window) {
        this.item = item;
        this.window = window;
    }

    private bool dragging = false;

    void Update() {
        if (dragging) {
            SetEmptySection();
        } else {
            if (item != null && item.item != null) {
                itemImage.texture = item.item.sprite;
                itemName.text = item.item.itemName;
            } else {
                SetEmptySection();
            }
        }
    }

    private void SetEmptySection() {
        itemImage.texture = emptyTexture;
        itemName.text = "";
    }

    public virtual void OnBeginDrag(PointerEventData pointer) {
        Debug.Log("Begin Drag");
        window.tooltip.Activate(this.gameObject);
        dragging = true;
    }

    public void OnEndDrag(PointerEventData pointer) {
        window.tooltip.DeActivate();
        dragging = false;
    }

    public virtual void OnDrag(PointerEventData pointer) {
        //window.tooltip.UpdatePosition(pointer.position);
    }

    public virtual void OnDrop(PointerEventData pointer) {
        ItemInInventroryWindow com = pointer.pointerDrag.GetComponent<ItemInInventroryWindow>();
        if (com != null && com.item.item != null) {
            window.Move(GetComponent<ItemInInventroryWindow>().item, pointer.pointerDrag.GetComponent<ItemInInventroryWindow>().item);
        }
    }

    public void Select() {
        window.SetSelectedItem(this.item);
    }

    public void Trashed() {
        Debug.Log("Объект выбрасывается");
        window.Throw(item);
    }
}
