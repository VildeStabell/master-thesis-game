using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapesMode : GameMode {
    const string NAME = "Shapes Mode";
    const string DESC = "Get the objects in the holes. You know, like toddlers do :)";
    GameObject boardPrefab = (GameObject)Resources.Load("ShapesBoard", typeof(GameObject));

    private int scorePerObject = 10;

    private RoundController roundCtrl;
    private int score;
    private bool isRoundOver = false;

    public ShapesMode(RoundController roundController) {
        roundCtrl = roundController;
    }

    /**
        Register object fallen into a correct hole and destroy it
    */
    public override void triggerScoreChange(GameObject triggeringObject) {
        if (!isRoundOver) {
            score += scorePerObject;
        }

        GameObject.Destroy(triggeringObject);
    }

    /**
        Get the current score
    */
    public override int getScore(bool roundOver) {
        isRoundOver = roundOver;
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
