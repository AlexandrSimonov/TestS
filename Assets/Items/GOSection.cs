using UnityEngine;
using System.Collections;

public abstract class GOSection : MonoBehaviour, ISection {
    public Item slot;

    public abstract void Activate();
}
