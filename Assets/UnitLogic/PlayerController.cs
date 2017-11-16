using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private NavMeshAgent agent;

    // Use this for initialization
    void Start() {
        
        agent = GetComponent<NavMeshAgent>();
        //agent.updateRotation = false;
        //agent.updatePosition = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                agent.SetDestination(hit.point);
            }
        }
    }
}
