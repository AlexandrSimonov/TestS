using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    private float timeStart;
    public Text textComponent;

    public void Init(string text, float time) {
        textComponent.text = text;
        timeStart = GameTime.time + time;
    }
	
	// Update is called once per frame
	void Update () {
        if (timeStart - GameTime.time < 0) {
            Close();
        }
	}

    public void Close() {
        Destroy(this.gameObject);
    }
}
