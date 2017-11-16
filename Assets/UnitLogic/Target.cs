using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Target : MonoBehaviour {

    public Transform target;
    public NavMeshAgent agent;
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        
    }

    public void Update() {
        agent.destination = target.position;
    }

}
