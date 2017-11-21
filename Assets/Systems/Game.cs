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
        instance.gameState = GameState.Play;
    }

    public static void GameOver() {
        instance.gameState = GameState.GameOver;
    }
}
