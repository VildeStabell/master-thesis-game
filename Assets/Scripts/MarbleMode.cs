using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMode : GameMode {
    const string NAME = "Marble Mode";
    const string DESC = "Get the marble into the green hole, while avoiding the red holes.";
    GameObject boardPrefab = (GameObject)Resources.Load("MarbleBoard", typeof(GameObject));
    GameObject marblePrefab = (GameObject)Resources.Load("Marble", typeof(GameObject));
    private Vector3 marbleStartPos = new Vector3(4.45f, 1.21f, -4.42f);

    private RoundController roundCtrl;
    private bool isRoundOver = false;
    private GameObject board;
    private int score;

    public MarbleMode(RoundController roundController) {
        roundCtrl = roundController;
    }

    /**
        Register object fallen into a correct hole and destroy it
    */
    public override void triggerScoreChange(GameObject triggeringObject) {
        GameObject.Destroy(triggeringObject);
        roundCtrl.endRound();
    }

    /**
        Respawns the marble
    */
    public override void onLifeLost() {
        spawnMarble();
    }

    /**
        Get the current score
    */
    public override int getScore(bool roundOver) {
        if (!isRoundOver) {
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        }

        return score;
    }

    /**
        Spawns and returns the board
    */
    public override GameObject spawnBoard() {
        board = GameObject.Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        spawnMarble();
        return board;
    }

    /**
        Get name of game mode
    */
    public override string getName() {
        return NAME;
    }

    /**
        Get description of game mode
    */
    public override string getDescription() {
        return DESC;
    }

    // --- Utility functions ---

    /**
        Spawn the marble in the correct place on the board
    */
    private void spawnMarble() {
        GameObject marble = GameObject.Instantiate(marblePrefab, board.transform);
        marble.transform.RotateAround(board.transform.position, marbleStartPos, board.transform.rotation.y);
    }
}