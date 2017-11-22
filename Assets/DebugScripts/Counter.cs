using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Counter : MonoBehaviour {

    private RxField<int> counter = new RxField<int>(0);
    private Text textCounter;

    private void Awake() {
        textCounter = GetComponent<Text>();

        counter.OnChangeEvent.AddListener(View);
    }

    private void View(int value) {
        textCounter.text = "" + value;
    }

    public void Minus() {
        if (counter.Value >= 1) {
            counter.Value--;
        }
    }

    public void Plus() {
        counter.Value++;
    }
}
