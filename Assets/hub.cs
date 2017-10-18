using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hub : MonoBehaviour {

    public int sectionCount;

    private Image[] sections;
    public GameObject hubSection;
    public Text text;

    void Awake() {
        sections = new Image[sectionCount];

        for (int i = 0; i < sectionCount; i++) {
            sections[i] = Instantiate(hubSection, this.transform.GetChild(0)).GetComponent<Image>();
        }
    }

    private float maxHp;
    private float hpInSection;

    public void Init(float hp, float maxHp) {
        this.maxHp = maxHp;
        hpInSection = maxHp / sectionCount;

        ChangeHp(hp);
    }

    public void ChangeHp(float hp) {
        int sectionShow = sectionCount - (int)Mathf.Floor((maxHp - hp) / hpInSection);

        for (int i = 0; i < sections.Length; i++) {
            if (i < sectionShow) {
                sections[i].enabled = true;
            } else {
                sections[i].enabled = false;
            }
        }

        text.text = Mathf.Ceil(hp) + " / " + maxHp;
    }
}
