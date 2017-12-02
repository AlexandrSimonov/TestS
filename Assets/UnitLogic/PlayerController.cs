using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent agent;

    // Use this for initialization
    void Start() {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        //agent.updatePosition = false;
    }

    private bool move = false;
    private Vector3 direction;
    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                //direction = hit.point - transform.position;
                agent.SetDestination(hit.point);
            }

            move = true;
            direction.y = 0;

            direction.Normalize();

            float angle = Mathf.Acos(Vector3.Dot(direction, transform.forward.normalized)) * 180 / Mathf.PI;

            if (Mathf.Abs(angle) > 25) {
                Debug.Log("Нужно остановиться и повернуться");
            } else {
                Debug.Log("Можно повернуться во время хотьбы");
            }
        }

        if (move) {
            if (direction != Vector3.zero) {
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), 150 * Time.deltaTime);
            }
            if (Vector3.Distance(new Vector3(agent.pathEndPosition.x, 0, agent.pathEndPosition.z), new Vector3(transform.position.x, 0, transform.position.z)) < 0.1f) {
                Debug.Log("Мы пришли");
                move = false;
            }
        }

    }
}
