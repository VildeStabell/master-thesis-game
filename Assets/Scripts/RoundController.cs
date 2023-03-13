using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {
    public GameModeEnum gameModeType;
    public int lives = 5;
    public GameObject endRoundButtons;
    public Button replayButton;
    public GameObject pauseMenu;
    public Button continueButton;
    public GameObject lifeContainer;
    public GameObject lifeIndicator;
    public string scoreText;
    public TMP_Text scoreObject;
    public ScoreManager scoreManager;
    public GameObject scoresUI;



    GameObject board;
    string[] steeringModes = { "AngleRotation" }; // TODO: Get from scene change
    SteeringMode currentSM;
    GameMode gameMode;
    Stack<GameObject> lifeIndicators = new Stack<GameObject>();
    bool roundOver = false;
    bool paused = false;

    void Awake() {
        switch (gameModeType) {
            case GameModeEnum.BalanceMode:
                gameMode = new BalanceMode(this);
                break;
            case GameModeEnum.ShapesMode:
                gameMode = new ShapesMode(this);
                break;
            case GameModeEnum.MarbleMode:
                gameMode = new MarbleMode(this);
                break;
        }

        switch (steeringModes[0]) { // TODO: add randomisation to here and update function
            case "AngleRotation":
                currentSM = new AngleRotation();
                break;
        }

        board = gameMode.spawnBoard();

    }

    // Start is called before the first frame update
    void Start() {
        endRoundButtons.SetActive(false);
        pauseMenu.SetActive(false);
        scoresUI.SetActive(false);
        scoreManager.getScoresFromJson();

        // Spawn life indicators
        float lifeSpacing = -(lifeIndicator.GetComponent<SpriteRenderer>().bounds.size.x / 350);

        for (int i = 0; i < lives; i++) {
            GameObject life = Instantiate(lifeIndicator, lifeContainer.transform);
            life.transform.position = lifeContainer.transform.position + new Vector3(i * lifeSpacing, 0, 0);
            life.transform.rotation = new Quaternion(0, 0, 0, 0);
            lifeIndicators.Push(life);
        }

        scoreText = gameMode.getScoreText();
    }

    // Update is called once per frame
    public void Update() {
        scoreObject.text = scoreText + gameMode.getScore(roundOver);
    }

    public void endRound() {
        Destroy(board);
        endRoundButtons.SetActive(true);
        replayButton.Select();
        roundOver = true;
        scoreManager.AddScore(new Score("Player", gameMode.getScore(roundOver)));
        scoreManager.showHighScores();
    }

    public GameObject getBoard() {
        return board;
    }

    public void loseLife() {
        lives--;
        Destroy(lifeIndicators.Pop());
        gameMode.onLifeLost();

        if (lives <= 0) {
            endRound();
        }
    }

    public bool isPaused() {
        return paused;
    }

    // ---- Event Listeners ----

    /**
        Moves the board right according to current steering mode
    */
    public void moveRight() {
        if (board && !paused) {
            currentSM.moveRight(board, startMovement);
        }
    }

    /**
        Moves the board left according to current steering mode
    */
    public void moveLeft() {
        if (board && !paused) {
            currentSM.moveLeft(board, startMovement);
        }
    }

    /**
        Trigger a score change in the game mode
    */
    public void triggerScoreChange(GameObject triggeringObject) {
        gameMode.triggerScoreChange(triggeringObject);
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

    /**
        Pauses the game and opens the pause menu
    */
    public void pauseGame() {
        if (!paused) {
            paused = true;
            pauseMenu.SetActive(true);
            continueButton.Select();
            Time.timeScale = 0;
        } else {
            resumeGame();
        }
    }

    /**
        Unpauses the game and hides the pause menu
    */
    public void resumeGame() {
        paused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }



    // ---- Utility Functions ----

    /**
        Used by steeringmodes to run smooth movements
    */
    void startMovement(IEnumerator movementTracker) {
        StartCoroutine(movementTracker);
    }

    public GameMode GetGameMode() {
        return gameMode;
    }

}
