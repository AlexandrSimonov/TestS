using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

    private section[] sections = new section[9];
    public GameObject sectionPrefab;

    private KeyCode[] keyCodes;

    // Use this for initialization
    void Start() {
        for (int i = 0; i < 9; i++) {
            GameObject obj = Instantiate(sectionPrefab, transform);
            sections[i] = obj.GetComponent<section>();
            sections[i].Init(i);
        }

        keyCodes = new KeyCode[9] {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9
        };
 
    }

    void Update () {
        for (int i = 0; i < keyCodes.Length; i++) {
            if (Input.GetKeyDown(keyCodes[i])) {
                ActiveSection(i);       
            }
        }

    }

    public void ActiveSection(int num) {
        for (int i = 0; i < 9; i++) {
            sections[i].DisableSection();
        }
        sections[num].ActiveSection();
    }
}
