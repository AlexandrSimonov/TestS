using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Вот над этим подумать, если нужно будет менять что-то где-то ещё
public abstract class ItemInGrid : MonoBehaviour {

    protected int index;
    public Item item;

    protected UnityAction<int> select;
    protected UnityAction deselect;
    protected UnityAction<int> doubleTap;

    public virtual void Init(int index, UnityAction<int> select, UnityAction deselect, UnityAction<int> doubleTap) {
        this.index = index;
        this.select = select;
        this.deselect = deselect;
        this.doubleTap = doubleTap;
    }

    public void Select() {
        select.Invoke(index);
    }

    public void DeSelect() {
        deselect.Invoke();
    }

    public void DoubleTap() {
        doubleTap.Invoke(index);
    }

    public void Delete() {
        Destroy(this.gameObject);
    }

}
