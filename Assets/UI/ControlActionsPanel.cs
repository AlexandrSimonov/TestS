using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlActionsPanel : MonoBehaviour {

    private Vector3 targetPosition;
    private RectTransform transformPanel;
    public GameObject button;

    private bool show = false;

    void Start() {
        transformPanel = transform.GetComponent<RectTransform>();
        targetPosition = transformPanel.position;
    }

    void Update() {
        transformPanel.position = Vector3.MoveTowards(transformPanel.position, targetPosition, 4);

        if (show) {
            if (Input.GetMouseButtonDown(0)) {
                HidePanel();
            }
            button.SetActive(false);
        } else {
            button.SetActive(true);
        }
    }

    public void HidePanel() {
        targetPosition.x *= -1;
        show = false;
    }

    public void ShowPanel() {
        targetPosition.x *= -1;
        show = true;
    }
}
