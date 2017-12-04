using UnityEngine;
using UnityEngine.AI;
using System.Collections;

// Есть над чем работать
// Если персонаж должен стоять длительное время лучше для него canMove поставить в false
public class Move : MonoBehaviour {

    private NavMeshAgent agent;

    public Animator animator;

    private Vector3 direction;
    Vector3 nextTarget; // Эта точка указывает куда сейчас должен двигаться юнит

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    private bool canMove = true;

    public void CanMove() {
        canMove = true;
    }

    public void NotCanMove() {
        canMove = false;
    }

    void Update() {
        if (canMove) {
            Vector3 posSteering = new Vector3(agent.steeringTarget.x, 0, agent.steeringTarget.z);
            Vector3 posObj = new Vector3(transform.position.x, 0, transform.position.z);

            animator.SetBool("walk", false);

            if (Vector3.Distance(posObj, posSteering) > 0.01f) {
                animator.SetBool("walk", true);
                direction = agent.steeringTarget - transform.position;

                direction.y = 0;
                direction.Normalize();

                float angle = Mathf.Acos(Vector3.Dot(direction, transform.forward.normalized)) * 180 / Mathf.PI;

                if (angle < 30) {
                    Rotation(direction);
                    agent.isStopped = false;
                } else {
                    Rotation(direction);
                    agent.isStopped = true;
                }
            }
        }
    }

    private void Rotation(Vector3 direction) {
        if (direction != Vector3.zero) {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.LookRotation(direction), 300 * Time.deltaTime);
        }
    }
}
