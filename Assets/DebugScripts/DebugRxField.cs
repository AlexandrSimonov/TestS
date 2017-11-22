using UnityEngine;
using System.Collections;

public class DebugRxField : MonoBehaviour {


    public RxField<int> num;

    // Use this for initialization
    void Start() {
        num = new RxField<int>(2);

        num.OnChangeEvent.AddListener(Changed);

        num.Value = 1;

        num.Value = 2;

        num.Value = 3;
    }

    private void Changed(int num) {
        Debug.Log(num);
    }

    void Update() {

    }
}
