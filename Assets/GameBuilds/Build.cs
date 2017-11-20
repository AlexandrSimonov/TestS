using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Build : MonoBehaviour {

    public BuildGrid buildGrid;

    public Building building;

    public bool buildMode = false; // Режим строительства

    // Поворот домика
    private void Update() {
        if (buildMode && building != null) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!EventSystem.current.IsPointerOverGameObject()) { 
                if (Input.GetMouseButton(0) && Physics.Raycast(ray, out hit, maxDistance: 100)) {
                    buildGrid.TempZone(hit.point, building.width, building.lenght);
                    //buildGrid.TempSetEmpty(false);

                } else if (buildGrid.currentTempIsEmpty) {
                    WindowConfirm.Open("Построить здание?", "Вы уверенны, что хотите построить здесь это?", BuildOk, BuildFail);
                }
            }

        }
    }

    public void BuildOk() {
        buildGrid.TempSetEmpty(false);
        Instantiate(building, buildGrid.tempCenter + building.transform.position, new Quaternion());

        buildGrid.ClearTemp();
    }


    public void BuildFail() {
        buildGrid.ClearTemp();
    }
}
