using UnityEngine;

// Используем класс для "классификации монстров"
public class Monster : MonoBehaviour {

    public enum MonsterSizeType {
        Small,
        Normal,
        Big,
        Epic,
        Boss
    }

    public int strong = 1;
    public string monsterName;
    public MonsterSizeType type;
}
