using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MonsterController : MonoBehaviour {

    private enum MonsterState {
        CrashHome,
        Escape,
        Kill
    }

    public Damaged target;
    private NavMeshAgent agent;
    private Hp hp;
    private Attack attack;

    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        hp = GetComponent<Hp>();
        attack = GetComponent<Attack>();

        agent.SetDestination(target.transform.position);
        hp.OnHpDieEvent.AddListener(Die);
    }

    private void Die() {
        WaveControl.MonsterDie(GetComponent<Monster>());
        hp.OnHpDieEvent.RemoveListener(Die);
    }

    // Update is called once per frame
    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, transform.forward, out hit, maxDistance: 10f)) {

            if (hit.transform.name == target.transform.name && hit.distance < 1f) {
                agent.velocity = Vector3.zero;
                agent.isStopped = true;
                attack.AttackUnit(target);
            }
        }
    }
}
