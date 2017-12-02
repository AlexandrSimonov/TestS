using UnityEngine;

// V1.0 Не класс, а сплошное дерганье
// V1.1 уже получше стало
public class CameraControl : MonoBehaviour {

    public float speed = 1;
    private float maxAcceleration = 10;


    public Transform CameraRotateX; // Поворот по оси X
    public Transform CameraRotateY; // Поворот по оси Y
    public Transform CameraZ; // Отдаленность камеры
    public Transform CameraY;

    public Transform target = null;

    public enum CameraMode {
        Control,
        Follow
    }

    public CameraMode cameraMode = CameraMode.Control;


    private void Start() {
        if (CameraRotateX == null) {
            Debug.LogError("Не установлен transform CameraRotateX");
            return;
        }

        if (CameraRotateY == null) {
            Debug.LogError("Не установлен transform CameraRotateY");
            return;
        }

        if (CameraZ == null) {
            Debug.LogError("Не установлен transform CameraZ");
            return;
        }

        if (CameraY == null) {
            Debug.LogError("Не установлен transform CameraY");
            return;
        }

        CameraDistanceZ();
    }
    // Вот тут можно ограничить выход камеры за поле обзора


    public void SetSpeed(float speed) {
        this.speed = speed;
    }

    public bool stop = false;

    [ContextMenu("Контролировать")]
    public void ControMode() {
        cameraMode = CameraMode.Control;
    }
    [ContextMenu("Следовать")]
    public void FollowMode() {
        cameraMode = CameraMode.Follow;
    }

    public void Stop() {
        stop = true;
    }

    public void Resume() {
        stop = false;
    }

    void Update() {
        if (!stop) {
            if (cameraMode == CameraMode.Control) {
                Control();

                WarpOnControl();
            }

            if (cameraMode == CameraMode.Follow) {
                Follow();
            }

            Zoom();

            Rotate();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            stop = !stop;
        }
    }

    private bool warping = false;
    // Телепортация
    private void WarpOnControl() {
        if (target == null) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Tab)) {
            warping = true;
        }

        if (warping) {
            transform.position = new Vector3(target.position.x, 0, target.position.z);
            CameraDistanceZ();
            warping = false;
        }
    }

    // Мы должны возвращать смещение для камеры, соответственно, нужно принимать камеру и 
    private void CameraDistanceZ() {
        float ctan = 1 / Mathf.Tan(CameraRotateX.localRotation.eulerAngles.x * (Mathf.PI / 180));

        CameraZ.localPosition = new Vector3(0, 0, -(ctan * CameraY.localPosition.y));
    }

    private void Follow() {
        Vector3 tar = new Vector3(target.position.x, 0, target.position.z);

        transform.position = Vector3.MoveTowards(transform.position, tar, 300);
    }

    private float border = 2;
    private float acceleration = 1;
    private float accelerationPl = 1.6f;

    private bool move = false;

    private Vector3 direction = new Vector3(0, 0, 0);

    // Сделать чтобы движение по диагонале, было со скоростью 0,7 - Сделано
    // Нет поддержки тача
    // Не смотрит на углы, ездит как попало, под наклоном
    private void Control() {

        if (Input.mousePosition.x - border <= 0) {
            direction += -CameraRotateY.right;
        }
        if (Input.mousePosition.x + border >= Screen.width) {
            direction += CameraRotateY.right;
        }
        if (Input.mousePosition.y + border >= Screen.height) {
            direction += CameraRotateY.forward;
        }
        if (Input.mousePosition.y - border <= 0) {
            direction += -CameraRotateY.forward;
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
    // Эта штука работает, но не работает с тачем нормально
    // Было бы круто добавить инерции
    private void Zoom() {
        float y = CameraY.localPosition.y;
        float scrollY = Input.mouseScrollDelta.y;

        // Условие того что не нужно двигаться
        if (y <= maxDistanceZoom && y >= minDistanceZoom && scrollY == 0) {
            return;
        }

        if (y > maxDistanceZoom) {
            Zooming(maxDistanceZoom, 2);
        } else if (y < minDistanceZoom) {
            Zooming(minDistanceZoom, 2);
        } else {
            Zooming(CameraY.localPosition.y - scrollY, zoomSpeed);
        }
        CameraDistanceZ();
    }

    private void Zooming(float h, float speed) {
        Vector3 targetZoom = new Vector3(0, h, 0);
        CameraY.localPosition = Vector3.MoveTowards(CameraY.localPosition, targetZoom, speed * Time.deltaTime);
    }

    public float CameraRotationSpeed = 1;
    private void Rotate() {
        if (Input.GetMouseButton(2)) {
            float delta = Input.GetAxis("Mouse X");
            CameraRotateY.localRotation = Quaternion.Euler(0, CameraRotateY.localRotation.eulerAngles.y + CameraRotationSpeed * delta, 0);
        }
    }
}