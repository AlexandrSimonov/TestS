using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float speed = 1.5f;

    public Transform head;

    public float sensitivity = 5f; // чувствительность мыши
    public float headMinY = -40f; // ограничение угла для головы
    public float headMaxY = 40f;

    private Vector3 direction;
    public float jumpSpeed = 8.0F;
    private float h, v;
    private float rotationY;
    public float gravity = 20.0F;

    private IAttack attackComponent;
    private CharacterController controller;
    public Animator animator;

    private void Start() {
        controller = GetComponent<CharacterController>();

        attackComponent = GetComponent<IAttack>();

        Cursor.visible = false;
    }

    void Update() {
        Reset();

        Move();

        Jump();

        Attack();

        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }

    private void Move() {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        // управление головой (камерой)
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        rotationY = Mathf.Clamp(rotationY, headMinY, headMaxY);
        head.localEulerAngles = new Vector3(-rotationY, 0, 0);

        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        if (controller.isGrounded) {
            direction = new Vector3(h, 0, v);

            direction = transform.TransformDirection(direction);
            direction *= speed;
        }

        Debug.DrawLine(transform.position, transform.position + direction);
        if (h != 0 || v != 0) {
            animator.SetBool("walk", true);
        }


    }

    private void Attack() {
        if (Input.GetButton("Fire1")) {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(new Vector3((float)Screen.width / 2, (float)Screen.height / 2, 0));

            if (Physics.Raycast(ray, out hit)) {
                attackComponent.AttackUnit(hit.transform.GetComponent<Damaged>());
            }
        }
    }

    private void Jump() {
        if (Input.GetButton("Jump") && controller.isGrounded)
            direction.y = jumpSpeed;
    }

    private void Reset() {
        animator.SetBool("walk", false);
        animator.SetBool("attack", false);
    }
}