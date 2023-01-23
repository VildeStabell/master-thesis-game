using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController {
    GameObject board;
    GameMode gameMode;
    string[] steeringModes;
    SteeringMode currentSM;

    public RoundController(GameObject gameBoard, string gameModeString, string[] enabledSteeringModes) {
        //board = gameBoard;

        switch(gameModeString) { 
            case "BalanceMode":
                gameMode = new BalanceMode();
                break;
        }

        steeringModes = enabledSteeringModes;

        switch(steeringModes[0]) { // TODO: add randomisation
            case "AngleRotation":
                currentSM = new AngleRotation();
                break;
        }

        board = GameObject.Instantiate(gameMode.getBoardPrefab(), new Vector3(0, 0, 0), Quaternion.identity); //as GameObject;
    }

    // Update is called once per frame
    public void update()
    {
        
    }

    public void endRound() {
        GameObject.Destroy(board);
    }

    /**
        Moves the board right according to current steering mode
    */
    public void moveRight() {
        currentSM.moveRight(board);
    }

    /**
        Moves the board left according to current steering mode
    */
    public void moveLeft() {
        currentSM.moveLeft(board);
    }

}
