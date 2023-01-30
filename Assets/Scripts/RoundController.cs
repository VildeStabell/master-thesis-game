using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour {
    public GameModeEnum gameModeType;

    GameObject board;
    string[] steeringModes = {"AngleRotation"}; // TODO: Get from scene change
    SteeringMode currentSM;
    GameMode gameMode;

    // Start is called before the first frame update
    void Start() {
        switch(gameModeType) {
            case GameModeEnum.BalanceMode:
                gameMode = new BalanceMode();
                break;
        }
        
        switch(steeringModes[0]) { // TODO: add randomisation to here and update function
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
        Destroy(board);
    }

    public Transform getBoardTransform() {
        return board.transform;
    }

    // ---- Event Listeners ----
    
    /**
        Moves the board right according to current steering mode
    */
    public void moveRight() {
        currentSM.moveRight(board, startMovement);
    }

    /**
        Moves the board left according to current steering mode
    */
    public void moveLeft() {
        currentSM.moveLeft(board, startMovement);
    }

    // ---- Utility Functions ----

    /**
        Used by steeringmodes to run smooth movements
    */
    void startMovement(IEnumerator movementTracker) {
        StartCoroutine(movementTracker);
    }
}
