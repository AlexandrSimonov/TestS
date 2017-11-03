using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class DoubleTapEventTrigger : MonoBehaviour, IPointerClickHandler {

    public UnityEvent doubleTap;

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.clickCount == 2) {
            doubleTap.Invoke();
        }
    }
}
