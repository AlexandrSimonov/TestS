using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSection : MonoBehaviour {

    private SpriteRenderer sprite;
    public bool empty = true;

    public void Init(Grid grid) {        
        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        sprite = transform.GetComponent<SpriteRenderer>();

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), Vector2.zero);

        if (hit && hit.transform.tag == "barrier") {
            Active();
        }
    }

    public void Active() {
        sprite.color = new Color(0, 1, 0, 0.5f);
        empty = false;
    }

    public void Busy() {
        sprite.color = new Color(1, 0, 0, 0.5f);
    }

    public void TempActive() {
        sprite.color = new Color(1, 1, 0, 0.5f);
    }

    public void DefaultColor() {
        if (empty) {
            sprite.color = new Color(1, 1, 1, 0.5f);
        } else {
            sprite.color = new Color(0, 1, 0, 0.5f);
        }
        
    }
}
