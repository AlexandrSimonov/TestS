using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

    public Text fpsCounter;

    private int elem = 10;
    private float[] arr;

    private int index = 0;

    private void Awake() {
        arr = new float[elem];
    }

    void Update() {
        arr[index] = 1.0f / Time.deltaTime;

        index++;

        if (index == elem) {
            fpsCounter.text = "FPS - " + Mathf.RoundToInt(Avarage());

            index = 0;
        }
    }

    private float Avarage() {
        float avarage = 0;

        for (int i = 0; i < elem; i++) {
            avarage += arr[i];
        }

        return avarage / elem;
    }
}
