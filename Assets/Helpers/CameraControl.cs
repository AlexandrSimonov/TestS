using UnityEngine;

// Не класс, а сплошное дерганье
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
                //Control();

                WarpOnControl();
            }
            if (cameraMode == CameraMode.Follow) {
                //Follow();
            }

            Zoom();
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
            CameraZ.localPosition = new Vector3(0, 0, -CameraDistance());
            warping = false;
        }
    }

    // Мы должны возвращать смещение для камеры, соответственно, нужно принимать камеру и 
    private float CameraDistance() {
        float y = CameraY.position.y; // Расстояние от камеры к игроку

        float ctan = 1 / Mathf.Tan(CameraRotateX.localRotation.eulerAngles.x * (Mathf.PI / 180));

        return ctan * y;
    }

    private void Follow() {
        Vector3 pos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 tar = new Vector3(target.position.x, 0, CameraDistance());

        Vector3 targetCameraPosition = new Vector3(target.position.x, transform.position.y, CameraDistance());


        transform.position = Vector3.MoveTowards(transform.position, targetCameraPosition, 300);
    }

    private float border = 2;
    private float acceleration = 1;
    private float accelerationPl = 1.6f;

    private bool move = false;

    private Vector3 direction = new Vector3(0, 0, 0);

    // Сделать чтобы движение по диагонале, было со скоростью 0,7
    // Нет поддержки тача
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
    // Эта штука работает, но не работает с тачем нормально
    private void Zoom() {
        float y = transform.position.y;
        float scrollY = Input.mouseScrollDelta.y;

        // Условие того что не нужно двигаться
        if (y <= maxDistanceZoom && y >= minDistanceZoom && scrollY == 0) {
            return;
        }
        // Нам нужно притянуть y к maxDistance
        if (y > maxDistanceZoom) {
            Zooming(1, 5);
            Debug.Log("Нужно приблизиться");
            return;
        }
        // Нам нужно притянуть y к minDistance
        if (y < minDistanceZoom) {
            Zooming(-1, 5);
            Debug.Log("Нужно отдалиться");
            return;
        }


        Zooming(scrollY, zoomSpeed);
        Debug.Log("Есть управление");

    }

    private void Zooming(float direction, float speed) {
        /*Vector3 target = transform.position + Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).direction * direction;
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);*/
    }
}