using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
// Вот над этим подумать, если нужно будет менять что-то где-то ещё
public abstract class ItemInGrid : MonoBehaviour {

    protected int num;
    public Item item;

    protected UnityAction<int> select;
    protected UnityAction deselect;
    protected UnityAction<int> doubleTap;

    public virtual void Init(Item item, int num, UnityAction<int> select, UnityAction deselect, UnityAction<int> doubleTap) {
        this.item = item;
        this.num = num;
        this.select = select;
        this.deselect = deselect;
        this.doubleTap = doubleTap;

        this.item.ChangeEvent.AddListener(Render); // Ввезде, где есть подписка, должна быть и отписка

        Render();
    }

    public void Select() {
        select.Invoke(num);
    }

    public void DeSelect() {
        deselect.Invoke();
    }

    public void DoubleTap() {
        doubleTap.Invoke(num);
    }

    public abstract void Render();

    public void Delete() {
        this.item.ChangeEvent.RemoveListener(Render);
        Destroy(this.gameObject);
    }

}
