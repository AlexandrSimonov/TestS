using UnityEngine;

// Установить для него приоритет запуска меньше чем у других
// Узнать как делают другие
public class GameTime : MonoBehaviour {

    public static bool isPlayed = true;
    // Игровое время, возможно нужна корутина
    public static float time = 0;
    // Delta Time чтобы останавливать анимацию
    public static float deltaTime = 0;

    private void Update() {
        if (isPlayed) {
            //Debug.Log("Обновлилось время");
            time += Time.deltaTime;
            deltaTime = Time.deltaTime;
        } else {
            deltaTime = 0;
        }
    }

    public static void Pause() {
        isPlayed = false;
    }

    public static void Resume() {
        isPlayed = true;
    }

}