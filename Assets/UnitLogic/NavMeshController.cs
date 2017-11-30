using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshController : MonoBehaviour {

    private NavMeshAgent navMeshAgent;

    void Start() {
        navMeshAgent = GetComponent<NavMeshAgent>();

        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;
        navMeshAgent.updateUpAxis = false;
    }

}
