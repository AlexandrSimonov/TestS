using UnityEngine;
using System.Collections;

public class ParticleVisualEffect : MonoBehaviour, IVisualEffect {

    private ParticleSystem particle;
    private bool isStarted;
    void Awake() {
        particle = GetComponent<ParticleSystem>();
        isStarted = false;
    }

    public void Active() {
        particle.Play();
    }

    void Update() {
        if (!particle.main.loop && particle.isStopped && isStarted) {
            Destroy(this.gameObject);
        }
    }
}
