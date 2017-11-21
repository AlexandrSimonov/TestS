using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

    public enum GameState {
        Begin,
        Play,
        GameOver
    }

    [HideInInspector]
    public GameState gameState;

    public static Game instance;
    void Start() {
        gameState = GameState.Begin;
        instance = this;
    }

    public static void GamePlay() {
        instance.gameState = GameState.Play;
    }

    public static void GameOver() {
        instance.gameState = GameState.GameOver;
    }
}
