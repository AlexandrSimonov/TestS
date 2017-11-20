using UnityEngine;
using System.Collections;

public abstract class GridSection : MonoBehaviour {

    public abstract void Init();

    public abstract void Active();

    public abstract void TempActive();

    public abstract void Default();
}
