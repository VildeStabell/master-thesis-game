using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {
    public GameModeEnum gameModeType;
    public int lives = 5;
    public GameObject endRoundButtons;
    public Button replayButton;

    GameObject board;
    string[] steeringModes = { "AngleRotation" }; // TODO: Get from scene change
    SteeringMode currentSM;
    GameMode gameMode;

    // Start is called before the first frame update
    void Start() {
        endRoundButtons.SetActive(false);
        switch (gameModeType) {
            case GameModeEnum.BalanceMode:
                gameMode = new BalanceMode();
                break;
        }

        switch (steeringModes[0]) { // TODO: add randomisation to here and update function
            case "AngleRotation":
                currentSM = new AngleRotation();
                break;
        }

        board = GameObject.Instantiate(gameMode.getBoardPrefab(), new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    public void Update() {

    }

    public void endRound() {
        Debug.Log("Ending round"); // TODO: transfer scores etc.
        Destroy(board);
        endRoundButtons.SetActive(true);
        replayButton.Select();

    }

    public GameObject getBoard() {
        return board;
    }

    public void loseLife() {
        lives--;

        if (lives <= 0) {
            endRound();
        }
    }

    // ---- Event Listeners ----

    /**
        Moves the board right according to current steering mode
    */
    public void moveRight() {
        if (board) {
            currentSM.moveRight(board, startMovement);
        }
    }

    /**
        Moves the board left according to current steering mode
    */
    public void moveLeft() {
        if (board) {
            currentSM.moveLeft(board, startMovement);
        }
    }

    /**
        Reloads the current scene
    */
    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /**
        Reloads to the main menu
    */
    public void returnToMenu() {
        SceneManager.LoadScene(sceneName: "MainMenuScene");
    }

    // ---- Utility Functions ----

    /**
        Used by steeringmodes to run smooth movements
    */
    void startMovement(IEnumerator movementTracker) {
        StartCoroutine(movementTracker);
    }

}
