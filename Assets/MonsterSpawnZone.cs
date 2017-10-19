using UnityEngine;
using System.Collections;

public class MonsterSpawnZone : MonoBehaviour {

    // Внутренний
    public Vector2 startPos1;
    public Vector2 place1;

    // Внешний
    public Vector2 startPos2;
    public Vector2 place2;

    public GameObject test;

    private Vector2[] arrX;
    private Vector2[] arrY;

    // Use this for initialization
    void Start() {
        arrX = new Vector2[3] {
            new Vector2(startPos2.x, startPos1.x),
            new Vector2(startPos1.x, startPos1.x + place1.x),
            new Vector2(startPos1.x + place1.x, startPos2.x + place2.x)
        };

        arrY = new Vector2[3] {
            new Vector2(startPos2.y, startPos1.y),
            new Vector2(startPos1.y, startPos1.y - place1.y),
            new Vector2(startPos1.y - place1.y, startPos2.y - place2.y)
        };


        for (int i = 0; i < 100; i++) {
            Instantiate(test, GenerateRandomPoint(), new Quaternion(0,0,0,0));
        }
    }
    // Опасно!!! Переделать!!!
    private Vector2 GenerateRandomPoint() {
        int ranX = Random.Range(0, 3);

        Vector2 y;

        if (ranX == 1) {
            int ranY = Random.Range(0, 2);
            
            if (ranY == 1) {
                ranY++;
            }
            y = arrY[ranY];

        } else {
            y = arrY[Random.Range(0, 3)];
        }

        Vector2 x = arrX[ranX];

        return new Vector2(
            Random.Range(x.x, x.y),
            Random.Range(y.x, y.y)
        );
    }
    // Update is called once per frame
    void Update() {

    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1, 1, 0);

        Gizmos.DrawLine(startPos1, startPos1 + new Vector2(place1.x, 0));
        Gizmos.DrawLine(startPos1, startPos1 + new Vector2(0, -place1.y));
        Gizmos.DrawLine(startPos1 + new Vector2(0, -place1.y), startPos1 + new Vector2(place1.x, -place1.y));
        Gizmos.DrawLine(startPos1 + new Vector2(place1.x, 0), startPos1 + new Vector2(place1.x, -place1.y));

        Gizmos.DrawLine(startPos2, startPos2 + new Vector2(place2.x, 0));
        Gizmos.DrawLine(startPos2, startPos2 + new Vector2(0, -place2.y));
        Gizmos.DrawLine(startPos2 + new Vector2(0, -place2.y), startPos2 + new Vector2(place2.x, -place2.y));
        Gizmos.DrawLine(startPos2 + new Vector2(place2.x, 0), startPos2 + new Vector2(place2.x, -place2.y));
    }
}
