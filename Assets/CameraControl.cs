using UnityEngine;

public class CameraControl : MonoBehaviour {

    private float speed = 5;

    private Vector2 border = new Vector2(5, 5);

    public Vector3 target;

    void Update() {
        Move();

    }

    void Move() {
        target = Vector3.zero;

        if (Input.mousePosition.y < border.y) {
            target += Vector3.down;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, speed * Time.deltaTime);
        }

        if (Screen.height - Input.mousePosition.y < border.y) {
            target += Vector3.up;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up, speed * Time.deltaTime);
        }

        if (Input.mousePosition.x < border.x) {
            target += Vector3.left;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.left, speed * Time.deltaTime);
        }

        if (Screen.width - Input.mousePosition.x < border.x) {
            target += Vector3.right;
        }

        target.Normalize();

        transform.position = Vector3.MoveTowards(transform.position, transform.position + target, speed * Time.deltaTime);
    }
}