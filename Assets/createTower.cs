﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class createTower : MonoBehaviour {

    public GameObject prefabCorgi;
    public Camera mainCamera;
    public Grid grid;
    public DialogSystem dialog;

    private bool block = false;
    private Vector2 origin;
    private GameObject corgi;
    private gridSection[] arr;
    private int need;
    private CircleCollider2D circle;
    private bool canPos = true;

    void Update() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetKey(KeyCode.Mouse0)) {
                origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);

                if (!block) {
                    corgi = Instantiate(prefabCorgi, origin, new Quaternion(0, 0, 0, 1));
                    circle = corgi.GetComponent<CircleCollider2D>();
                    circle.enabled = false;
                    grid.ActiveGrid();
                    corgi.GetComponent<corgiController>().enabled = false;
                    block = true;
                }

                origin = grid.MyRound(origin);

                need = (int) (circle.radius / (grid.widthSection / 2));

                // origin округленный
                if (arr == null) {
                    arr = new gridSection[need * need];
                }

                for (int i = 0; i < need * need; i++) {
                    if (arr[i] != null) {
                        arr[i].DefaultColor();
                    }
                }

                for (int i = 0; i < need; i++) {
                    for (int j = 0; j < need; j++) {
                        arr[i * need + j] = grid.GetGridSection(origin + new Vector2(i * grid.widthSection, -j * grid.widthSection));
                    }
                }

                canPos = true;

                for (int i = 0; i < need * need; i++) {
                    if (arr[i].empty) {
                        arr[i].TempActive();
                    } else {
                        arr[i].Busy();
                        canPos = false;
                    }
                }

                Vector2 corgiPos = origin + new Vector2(circle.radius, -circle.radius) - circle.offset;

                corgi.transform.position = corgiPos;

                corgi.GetComponent<corgiController>().SetStartPos(corgiPos);

            }

            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                if (canPos) {
                    block = false;

                    for (int i = 0; i < need * need; i++) {
                        arr[i].Active();
                    }
                    circle.enabled = true;
                    arr = null;
                    corgi.GetComponent<corgiController>().enabled = true;
                    corgi.GetComponent<rotateLocal>().rotate(0);
                    grid.DeActiveGrid();
                } else {
                    DialogSystem.AddMessage("Тут нельзя разместить", 1);
                }    
            }
        }
    }

    

}
