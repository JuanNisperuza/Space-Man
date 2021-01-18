﻿using UnityEngine;
public enum GameState {
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour {

    public GameState currentState = GameState.menu;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.S)) {
            StartGame();
        }
    }
    public void StartGame() {
        SetGameState(GameState.inGame);
    }

    public void GameOver() {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu() {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState) {
        if(newGameState == GameState.menu) {

        }
        else if (newGameState == GameState.inGame) {

        }
        else if (newGameState == GameState.gameOver) {

        }
        currentState = newGameState;
    }
}
