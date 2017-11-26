using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Game", menuName = "SingletonCreate/Game", order = 1)]
public class Game : ScriptableObjectSingleton<Game> {

    public enum GameState {
        Begin,
        Play,
        GameOver
    }

    [HideInInspector]
    public GameState gameState;

    public override void Init() {
        Debug.Log("Game Init");
        gameState = GameState.Begin;
    }

    public static void GamePlay() {
        Instance.gameState = GameState.Play;
    }

    public static void GameOver() {
        Instance.gameState = GameState.GameOver;
    }
}
