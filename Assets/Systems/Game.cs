using UnityEngine;
using System.Collections;

public class Game : MonoBehaviourSingelton<Game> {

    public Window gameOverWindow;

    public enum GameState {
        Begin,
        Play,
        GameOver
    }

    [HideInInspector]
    public GameState gameState;

    private void Start() {
        gameState = GameState.Begin;
    }

    public void GamePlay() {
        Instance.gameState = GameState.Play;
        Notification.CreateNotification(Notification.NotificationPriority.Low, "Игра началась");
    }

    public static void GameOver() {
        Instance.gameState = GameState.GameOver;
        Notification.CreateNotification(Notification.NotificationPriority.High, "Игра окончена");
        Instance.gameOverWindow.Open();
    }
}
