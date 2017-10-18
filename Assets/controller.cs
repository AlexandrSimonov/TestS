using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {

    public Animator animator;
    public SpriteRenderer sprite;
    public float speed = 5;
    private Rigidbody2D rigidbody;
    public DialogSystem dialog;
    public rotateGlobal glob;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
        animator.SetBool("die", false);
        animator.SetBool("jump", false);
        animator.SetBool("hurt", false);
        

        if (Input.GetKey(KeyCode.UpArrow)) {
            move(new Vector2(0, 1));
            

        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            move(new Vector2(0, -1));
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            move(new Vector2(-1, 0));
            sprite.flipX = true;

        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            move(new Vector2(1, 0));
            sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            animator.SetBool("run", true);
            speed = 2.2f;
        }

        if (Input.GetKey(KeyCode.Space)) {
            animator.SetBool("atack", true);
        }

        if (Input.GetKey(KeyCode.R)) {
            animator.SetBool("die", true);
        }

        if (Input.GetKey(KeyCode.T)) {
            animator.SetBool("jump", true);
        }
    }

    private void move(Vector2 vec) {
        Vector2 b = new Vector2(0, 0);
        float q = glob.quat * Mathf.PI / 180;
        float sin = Mathf.Sin(q);
        float cos = Mathf.Cos(q);

        b.x = vec.x * cos - vec.y * sin;
        b.y = vec.x * sin + vec.y * cos;

        Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + b);

        rigidbody.AddForce(b * speed);

        animator.SetBool("walk", true);
    }
}
