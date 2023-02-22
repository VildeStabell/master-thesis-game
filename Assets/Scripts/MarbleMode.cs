using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleMode : GameMode {
    const string NAME = "Marble Mode";
    const string DESC = "Get the marble into the green hole, while avoiding the red holes.";
    GameObject boardPrefab = (GameObject)Resources.Load("MarbleBoard", typeof(GameObject));

    private RoundController roundCtrl;
    private int score;
    private bool isRoundOver = false;

    public MarbleMode(RoundController roundController) {
        roundCtrl = roundController;
    }

    /**
        Register object fallen into a correct hole and destroy it
    */
    public override void triggerScoreChange(GameObject triggeringObject) {
        Debug.Log("Goal!"); // TODO: remove

        GameObject.Destroy(triggeringObject);
    }

    /**
        Get the current score
    */
    public override int getScore(bool roundOver) {
        if (!isRoundOver) {
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad);
            Debug.Log("Time since level load" + Time.timeSinceLevelLoad);
        }

        return score;
    }

    /**
        Get the prefab from the game mode
    */
    public override GameObject getBoardPrefab() {
        return boardPrefab;
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
}
