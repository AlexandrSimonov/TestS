using UnityEngine;
using System.Collections.Generic;


// Полностью непроходимые зоны

public class PathGrid : MonoBehaviour {

    public Vector3 center;
    public Vector3 size;

    private Vector3 startPos;

    public float nodeSize;
    public int zoneSize;

    public GameObject prefabNode;
    public Transform parentNode;

    public Material notEmptyMaterial;
    public Material borderMaterial;

    private PathNode[,] grid;

    public PathZone[,] zones;

    private int arrSizeX;
    private int arrSizeY;

    private int countZoneX;
    private int countZoneY;

    void Awake() {
        startPos = center - (size / 2);

        // Размеры поля
        arrSizeX = Mathf.RoundToInt(size.x / nodeSize);
        arrSizeY = Mathf.RoundToInt(size.z / nodeSize);

        // Заполняем поле ячейками
        if (arrSizeX > 0 && arrSizeY > 0) {
            grid = new PathNode[arrSizeX, arrSizeY];

            for (int i = 0; i < arrSizeY; i++) {
                for (int j = 0; j < arrSizeX; j++) {

                    grid[i, j] = new PathNode {
                        coo = new Vector3((i + nodeSize / 2), nodeSize / 2, (j + nodeSize / 2)) + startPos,
                        IsEmpty = true
                    };

                    grid[i, j].obj = Instantiate(prefabNode, grid[i, j].coo, new Quaternion(0, 0, 0, 0), parentNode);
                }
            }
        }
        
        // Статичные препятствия
        RaycastHit hit;

        for (int i = 0; i < arrSizeY; i++) {
            for (int j = 0; j < arrSizeX; j++) {
                Physics.BoxCast(grid[j, i].coo + new Vector3(0, 50, 0), new Vector3(nodeSize / 2, nodeSize / 2, nodeSize / 2), new Vector3(0, -100, 0), out hit);

                if (hit.collider != null && hit.collider.gameObject.tag == "Barrier") {
                    grid[j, i].obj.GetComponent<MeshRenderer>().material = notEmptyMaterial;
                    grid[j, i].IsEmpty = false;
                }
            }
        }

        // Инициализация зон
        countZoneX = (int)(arrSizeX / zoneSize);
        countZoneY = (int)(arrSizeY / zoneSize);

        zones = new PathZone[countZoneY, countZoneX];

        for (int i = 0; i < countZoneY; i++) {
            for (int j = 0; j < countZoneX; j++) {
                zones[i, j] = new PathZone {
                    id = i * countZoneX + j
                };
            }
        }

        // Соседние зоны 
        for (int i = 0; i < countZoneY; i++) {
            for (int j = 0; j < countZoneX; j++) {
                zones[i, j].neighbors = FindNeighBors(i, j);
            }
        }

        // Установка входов и выходов
        PathZone zone1;
        PathZone zone2;
        /*
        for (int i = 0; i < countZoneY; i++) {
            for (int j = 0; j < countZoneX; j++) {
                Debug.Log(zones[i, j].id);
            }
        }*/

        for (int i = 1; i < countZoneY; i++) {    
            for (int j = 0; j < arrSizeX; j++) {
                zone1 = GetZoneByNode(i * zoneSize - 1, j);
                zone2 = GetZoneByNode(i * zoneSize, j);

                if (grid[i * zoneSize - 1, j].IsEmpty && grid[i * zoneSize, j].IsEmpty) {
                    zone1.exits.Add(new PathExit {
                        enter = zone2,
                        PathNodeEnter = grid[i * zoneSize - 1, j],
                        PathNodeExit = grid[i * zoneSize, j],
                    });

                    zone2.exits.Add(new PathExit{
                        enter = zone1,
                        PathNodeEnter = grid[i * zoneSize, j],
                        PathNodeExit = grid[i * zoneSize - 1, j]
                    });
                }
            }
        }

        for ( int i = 1; i < countZoneX; i++) {
            for (int j = 0; j < arrSizeY; j++) {
                zone1 = GetZoneByNode(j, i * zoneSize - 1);
                zone2 = GetZoneByNode(j , i * zoneSize);

                if (grid[j, i * zoneSize - 1].IsEmpty && grid[j, i * zoneSize].IsEmpty) {
                    zone1.exits.Add(new PathExit {
                        enter = zone2,
                        PathNodeEnter = grid[j, i * zoneSize - 1],
                        PathNodeExit = grid[j, i * zoneSize],
                    });

                    zone2.exits.Add(new PathExit {
                        enter = zone1,
                        PathNodeEnter = grid[j, i * zoneSize],
                        PathNodeExit = grid[j, i * zoneSize - 1]
                    });
                }
            }
        }
         /*
        foreach (PathZone zone in zones) {
            Debug.Log(zone.id);
        }
        */

        foreach (PathExit exit in GetZoneByNode(37, 37).exits) {
            exit.PathNodeEnter.obj.GetComponent<MeshRenderer>().material = borderMaterial;
        }

        /* foreach (PathZone zone in FindNeighBors(1, 1)) {
            Debug.Log(zone.id);
        } */

        /* Вот тут можно завтра попробовать добавить юнит тесты, они тут подойдут как ничто другое
        Debug.Log(GetZoneByNode(35, 14).id);

        */
    }

    // Получить соседние ноды для ноды
    public PathNode[] GetNeighBorsNode(int x, int y) {
        List<PathNode> neighBors = new List<PathNode>();

        for (int i = -1 + x; i <= 1 + x; i++) { // Вертикаль
            for (int j = -1 + y; j <= 1 + y; j++) { // Горизонталь
                PathNode node = GetNode(j, i);

                if (node != null) {
                    neighBors.Add(node);
                }
            }
        }

        return neighBors.ToArray();
    }

    // Получить ноды для зоны
    public PathNode[,] GetNodeInZone(int id) {
        PathNode[,] arr = null;

        // Находим зону по id и узнаем смещение ячеек
        for (int i = 0; i < countZoneY; i++) {
            for (int j = 0; j < countZoneX; j++) {
                if (zones[j, i].id == id) {
                    arr = new PathNode[zoneSize, zoneSize];

                    // Получаем ячейки
                    for (int k = 0; k < zoneSize; k++) {
                        for (int l = 0; l < zoneSize; l++) {
                            arr[k, l] = grid[i * zoneSize + k, j * zoneSize + l];
                        }
                    }
                }
            }
        }

        return arr;
    }


    public PathNode GetNode(int x, int y) {
        if (x >= 0 && y >= 0 && x < arrSizeX && y < arrSizeY) {
            return grid[x, y];
        }
        return null;
    }

    // Получить соседние зоны для зоны
    public PathZone[] FindNeighBors(int x, int y) {
        List<PathZone> neighBors = new List<PathZone>();

        for (int i = -1 + x; i <= 1 + x; i++) { // Вертикаль
            for (int j = -1 + y; j <= 1 + y; j++) { // Горизонталь
                PathZone zone = GetPathZone(j, i);

                if (zone != null && zone.id != GetPathZone(x, y).id) {
                    neighBors.Add(zone);
                }
            }
        }

        return neighBors.ToArray();
    }

    // ПОлучить зону из массива
    public PathZone GetPathZone(int x, int y) {
        if (x >= 0 && y >= 0 && x < countZoneX && y < countZoneY) {
            return zones[x, y];
        }
        return null;
    }

    // Получить зону исходя из координат ноды
    public PathZone GetZoneByNode(int x, int y) {
        return zones[Mathf.FloorToInt(x / zoneSize), Mathf.FloorToInt(y / zoneSize)];
    }

    public void FindPath(PathNode target, PathNode current) {
        
    }

    public void ShowGrid() {

    }

    public void HideGrid() {

    }

    public PathNode GetNodeByCoordinate(Vector3 coo) {



        return null;
    }

    private void Update() {
        
    }

    public void UpdateGrid() {

    }

    private void OnDrawGizmosSelected() {
        //Gizmos.DrawCube(center, size);
        //Gizmos.color = new Color(1, 0, 0);
        //Gizmos.DrawCube(center - (size / 2) + new Vector3(0, 1, 0), new Vector3(0.2f, 0.2f, 0.2f));
        //Gizmos.color = new Color(1, 1, 0);

        /*if (grid != null) {
            for (int i = 0; i < arrSizeY; i++) {
                for (int j = 0; j < arrSizeX; j++) {
                    Gizmos.DrawCube(new Vector3(grid[i,j].X, 0, grid[i, j].Y), new Vector3(nodeSize - 0.2f, nodeSize, nodeSize - 0.2f));
                }
            }
        }*/
    }
}
