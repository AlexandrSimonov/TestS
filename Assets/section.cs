using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class section : MonoBehaviour {

    public int id = -1;
    public int count = 0;
    public item item;

    public void Init(int num) {
        id = num;

        if (count > 0) {
            transform.GetChild(1).GetComponent<Text>().text = "" + count;
        }

        transform.GetComponent<Button>().onClick.AddListener(e);
    }

    public void SetCount(int num) {
        count = num;
    }

    void e() {
        transform.parent.GetComponent<inventory>().ActiveSection(id);
    }

    public void ActiveSection() {
        transform.GetComponent<Image>().color = Color.red;
    }

    public void DisableSection() {
        transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }
}
