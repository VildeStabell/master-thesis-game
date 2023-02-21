using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMode : GameMode {
    const string NAME = "Balance Mode";
    const string DESC = "Try to keep the board steady for as long as possible.";
    GameObject boardPrefab = (GameObject)Resources.Load("BalanceBoard", typeof(GameObject));

    private RoundController roundCtrl;
    private int score;

    public BalanceMode(RoundController roundController) {
        roundCtrl = roundController;
    }

    /**
        Get the current score
    */
    public override int getScore(bool roundOver) {
        if (!roundOver) {
            score = Mathf.FloorToInt(Time.timeSinceLevelLoad);
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

    public override void triggerScoreChange(GameObject triggeringObject) {
        // Nothing in this game mode
    }
}
