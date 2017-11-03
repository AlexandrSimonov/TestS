using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
// Вот над этим подумать, если нужно будет менять что-то где-то ещё
public abstract class ItemInGrid : MonoBehaviour {

    protected int num;
    protected Item item;

    protected UnityAction<int> select;
    protected UnityAction deselect;

    public virtual void Init(Item item, int num, UnityAction<int> select, UnityAction deselect) {
        this.item = item;
        this.num = num;
        this.select = select;
        this.deselect = deselect;
    }

    public void Select() {
        select.Invoke(num);
    }

    public void DeSelect() {
        deselect.Invoke();
    }

}
