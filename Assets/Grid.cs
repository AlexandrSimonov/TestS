using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public float widthSection;
    public Vector2 place;
    public Vector2 startPos;

    public GameObject obj;
    public GameObject parent;

    private gridSection[,] arraySection;

    private int height;
    private int width;

    void Start() {
        width = (int)(place.x / widthSection);
        height = (int)(place.y / widthSection);

        foreach (GameObject el in GameObject.FindGameObjectsWithTag("barrier")) {
            CircleCollider2D circle = el.GetComponent<CircleCollider2D>();
            Vector2 vec = MyRound(el.transform.position) + new Vector2(circle.radius, -circle.radius) - circle.offset;

            el.transform.position = new Vector3(vec.x, vec.y, el.transform.position.z);
        }

        arraySection = new gridSection[height, width];

        if (widthSection > 0) {
            for (int j = 0; j < height; j++) {
                for (int i = 0; i < width; i++) {
                    arraySection[j, i] = Instantiate(obj, startPos + new Vector2(i * widthSection, -j * widthSection) + new Vector2(widthSection / 2, -widthSection / 2), new Quaternion(0, 0, 0, 0), parent.transform).GetComponent<gridSection>();
                    arraySection[j, i].Init(this);
                }
            }
        }

    }

    public gridSection GetGridSection(Vector2 vec) {
        vec = startPos - vec;

        if (vec.x >  0 || vec.x <= -place.x || vec.y < 0 || vec.y >= place.y) {
            return null;
        }

        int x = (int)Mathf.Floor(Mathf.Abs(vec.x) / widthSection);
        int y = (int)Mathf.Floor(Mathf.Abs(vec.y) / widthSection);

        
        return arraySection[y, x];
    }

    public void ActiveSection(Vector2 vec) {
        GetGridSection(vec).Active();
    }

    public void ActiveGrid() {
        parent.SetActive(true);
    }

    public void DeActiveGrid() {
        parent.SetActive(false);
    }


    public Vector2 MyRound(Vector2 vec) {
        Vector2 vec2 = new Vector2 {
            x = Mathf.Floor(vec.x / widthSection) * widthSection,
            y = Mathf.Ceil(vec.y / widthSection) * widthSection
        };
        return vec2;
    }

}