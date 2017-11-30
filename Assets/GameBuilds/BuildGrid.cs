using UnityEngine;
using System.Collections.Generic;

public class BuildGrid : MonoBehaviour {

    public int width;
    public int height;

    public Vector3 startPos;
    public BuildSection prefab;

    public bool DebugGrid;

    // Сначала по y, потом по x;
    private BuildSection[,] grid;

    void Start() {
        // Иницилизация массива

        grid = new BuildSection[height, width];

        // Иницилизация сетки
        for (int i = 0; i < height; i++) {
            for (int j = 0; j < width; j++) {
                grid[i, j] = Instantiate(prefab, startPos + new Vector3(i, 1, j), new Quaternion(), transform);
            }
        }

    }



    // Тестовая подсветка
    //private BuildSection current = null;

    private List<BuildSection> currentTemp = new List<BuildSection>();
    public bool currentTempIsEmpty = false; // Все ли выбранные ячейки пустые
    public Vector3 tempCenter;

    public void TempZone(Vector3 start, int width, int lenght) {
        ClearTemp();

        currentTempIsEmpty = true;


        for (int i = 0; i < lenght; i++) {
            for (int j = 0; j < width; j++) {
                BuildSection tmp = GetSectionByCoordinate(start + new Vector3(i, 0, j));

                if (tmp != null && tmp.isEmpty) {
                    currentTemp.Add(tmp);
                    tmp.TempActivate();
                } else {
                    currentTempIsEmpty = false;
                }
            }
        }

        if (currentTempIsEmpty) {
            Vector3 vec = currentTemp[0].obj.transform.position - new Vector3(0.5f, 0, 0.5f);

            vec += new Vector3((float)lenght * 0.5f, 0, (float)width * 0.5f);

            tempCenter = vec;
        }
    }

    public void ClearTemp() {
        foreach (BuildSection section in currentTemp) {
            section.Default();
        }

        currentTemp.Clear();

        currentTempIsEmpty = false;
    }

    public void TempSetEmpty(bool value) {
        foreach (BuildSection section in currentTemp) {
            section.SetEmpty(value);
        }
    }

    private BuildSection GetSectionByCoordinate(Vector3 vec) {
        vec -= startPos;

        return grid[Mathf.RoundToInt(Mathf.Abs(vec.x)), Mathf.RoundToInt(Mathf.Abs(vec.z))];
    }

    private void OnDrawGizmosSelected() {
        if (DebugGrid) {
            for (int i = 0; i < height; i++) {
                for (int j = 0; j < width; j++) {
                    Gizmos.DrawCube(startPos + new Vector3(i, 1, j), new Vector3(.8f, .8f, .8f));
                }
            }
        }
    }
}
