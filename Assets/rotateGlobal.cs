using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGlobal : MonoBehaviour {

    private rotateLocal[] rotateLocals;
    public float quat = 0;
    private float block = 0;

    private void Start() {
        rotateLocals = FindObjectsOfType(typeof(rotateLocal)) as rotateLocal[];
    }

    private void rotates(float angle) {
        
        for (int i = 0; i < rotateLocals.Length; i++) {
            if (rotateLocals[i] != null) {
                rotateLocals[i].rotate(angle);
            }
        }
    }

	void Update () {
        if (Input.GetKey(KeyCode.Q) && block == 0) {
            quat += 45;
            rotates(quat);
            block = Time.time;
        }

        if (Input.GetKey(KeyCode.E) && block == 0) {
            quat -= 45;
            rotates(quat);
            block = Time.time;
        }

        if (Time.time - block > 0.2f) {
            block = 0;
        }
    }
}
