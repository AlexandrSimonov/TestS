using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class PathZone : System.Object {

    public List<PathExit> exits = new List<PathExit>(); // массив выходов

    public int id; // Индификатор зоны соответствует порядковому номеру

    public PathZone[] neighbors; // соседние зоны

}