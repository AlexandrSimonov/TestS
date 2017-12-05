using UnityEngine;
using System.Collections;

public class MonsterDamaged : Damaged {
    public GameObject attackCircle;

    public void Show() {
        attackCircle.SetActive(true);
    }

    public void Hide() {
        attackCircle.SetActive(false);
    }
}