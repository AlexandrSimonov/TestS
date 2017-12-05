using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    MonsterDamaged selectedMonster = null;

    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            AttackSelected(hit);


            if (Input.GetMouseButtonDown(1)) {

                agent.SetDestination(hit.point);
            }
        }
    }

    private void AttackSelected(RaycastHit hit) {
        MonsterDamaged monster = hit.transform.GetComponent<MonsterDamaged>();
        if (monster != null) {
            monster.Show();

            if (selectedMonster != monster && selectedMonster != null) {
                selectedMonster.Hide();
            }
            selectedMonster = monster;
        } else if (selectedMonster != null) {
            selectedMonster.Hide();
            selectedMonster = null;
        }
    }
}
