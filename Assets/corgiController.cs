using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corgiController : MonoBehaviour {

    public GameObject enemy;
    public GameObject eventActive;
    private Vector3 startPos;
    private float dist = -1;
    private float timeGav = 0;

    // Use this for initialization
    void Start() {
        enemy = GameObject.Find("Troll_2");
        SetStartPos(transform.position);
    }

    public void SetStartPos(Vector3 vec) {
        startPos = vec;
    }

	// Update is called once per frame
	void Update () {
        if (enemy != null) {
            dist = Vector2.Distance(startPos, enemy.transform.position);

            if (dist < 8) {
                float dist2 = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist2 < 4) {
                    Gav();
                }
                if (dist2 > 4) {
                    transform.position = Vector3.MoveTowards(transform.position, enemy.transform.position, Time.deltaTime * 5);

                }
            } 
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPos, Time.deltaTime * 5);
            eventActive.SetActive(false);
        }

    }

    void Gav() {
        if (timeGav - Time.time < 0) {
            eventActive.SetActive(!eventActive.activeSelf);
            timeGav = Time.time + 0.5f;
            enemy.GetComponent<Hp>().Minus(10);
        }
    }
}
