using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float speed = 1;
    public float maxAcceleration = 1;
    public enum CameraMode {
        Control,
        Follow
    }

    public CameraMode cameraMode = CameraMode.Control;

    public bool stop = false;

    void Update() {
        if (!stop) {
            if (cameraMode == CameraMode.Control) {
                Control();
            }
            if (cameraMode == CameraMode.Follow) {
                Follow();
            }
        }

        Zoom();
    }

    private void Follow() {

    }

    private float border = 2;
    private float acceleration = 1;
    private float accelerationPl = 1.6f;

    private bool move = false;

    private Vector3 direction = new Vector3(0, 0, 0);

    // Сделать чтобы движение по диагонале, было со скоростью 0,7
    private void Control() {
        if (Input.mousePosition.x - border <= 0) {
            direction += Vector3.left;
        }
        if (Input.mousePosition.x + border >= Screen.width) {
            direction += Vector3.right;
        }
        if (Input.mousePosition.y + border >= Screen.height) {
            direction += Vector3.forward;
        }
        if (Input.mousePosition.y - border <= 0) {
            direction += Vector3.back;
        }

        if (direction != Vector3.zero) {
            direction.Normalize();
            acceleration += accelerationPl;
            move = true;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed * acceleration);
        }

        if (!move) {
            acceleration = 1;
        }

        move = false;

        direction.Set(0, 0, 0);

        if (acceleration > maxAcceleration) {
            acceleration = maxAcceleration;
        }
    }

    public float minDistanceZoom = 0;
    public float maxDistanceZoom = 1;
    public float zoomSpeed = 1;

    private void Zoom() {
        float y = transform.position.y;
        float scrollY = Input.mouseScrollDelta.y;

        // Условие того что не нужно двигаться
        if (y < maxDistanceZoom && y > minDistanceZoom && scrollY == 0) {
            return;
        }
        // Нам нужно притянуть y к maxDistance
        if (y > maxDistanceZoom) {
            Zooming(1, 5);
            return;
        }
        // Нам нужно притянуть y к minDistance
        if (y < minDistanceZoom) {
            Zooming(-1, 5);
            return;
        }

        Zooming(scrollY, zoomSpeed);

    }

    private void Zooming(float direction, float speed) {
        Vector3 target = transform.position + Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).direction * direction;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}