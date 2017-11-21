using UnityEngine;
using System.Collections;

public class Game : MonoBehaviourSingelton<Game> {

    public enum GameState {
        Begin,
        Play,
        GameOver
    }

    [HideInInspector]
    public GameState gameState;
    
    void Start() {
        gameState = GameState.Begin;
    }

    public static void GamePlay() {
        Instance.gameState = GameState.Play;
    }

    public static void GameOver() {
        Instance.gameState = GameState.GameOver;
    }
}
