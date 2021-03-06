﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocal : MonoBehaviour {

    private float speed = 120;
    private float angle = 0;

    public bool notChange = false;

    private void Start() {
        rotate(angle);
    }

    public void rotate(float angle) {
        this.angle = angle;
    }

    private void LateUpdate() {
        if (!notChange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, (Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y, 0)).y / 1000));
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), speed * Time.deltaTime);
    }
}
