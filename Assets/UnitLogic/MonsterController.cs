using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterController : MonoBehaviour {

    private enum MonsterState {
        CrashHome,
        Escape,
        Kill
    }

    public GameObject target;
    private NavMeshAgent agent;
    private Hp hp; 
    
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
        hp = GetComponent<Hp>();

        hp.OnHpDieEvent.AddListener(Die);
    }

    private void Die() {
        WaveControl.MonsterDie(GetComponent<Monster>());
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        if (Physics.Raycast(this.transform.position, fwd, out hit, maxDistance: 1f)) {

            if (hit.transform.name == target.transform.name && hit.distance < 0.5f) {
                agent.velocity = Vector3.zero;
                agent.isStopped = true;
            }
        }
    }
}
