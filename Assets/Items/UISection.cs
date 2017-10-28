using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class UISection : MonoBehaviour, ISection {

    public IActivated slot;

    public abstract void Activate();
}
