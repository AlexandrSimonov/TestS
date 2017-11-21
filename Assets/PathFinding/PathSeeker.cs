using UnityEngine;
using System.Collections;

public class PathSeeker : MonoBehaviour {

    // Размер указывает на то сколько ячеек занимает объект ищущий путь, число ячеек нужно возвести в квадрат
    // 1 - 1
    // 2 - 4
    // 3 - 9 

    public int size = 1;
    public GameObject target;

    public PathFindingPath path;
}
