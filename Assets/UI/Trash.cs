using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData pointer) {
        ITrashed objTrashed = pointer.pointerDrag.GetComponent<ITrashed>();

        if (objTrashed != null) {
            objTrashed.Trashed();
        }
    }
}
