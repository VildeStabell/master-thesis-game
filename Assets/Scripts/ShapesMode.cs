using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShapesMode : GameMode {
    const string NAME = "Shapes Mode";
    const string DESC = "Get the objects in the holes. You know, like toddlers do :)";
    const string SCORETEXT = "Objects: ";
    GameObject boardPrefab = (GameObject)Resources.Load("ShapesBoard", typeof(GameObject));

    private RoundController roundCtrl;
    private bool isRoundOver = false;
    private GameObject board;
    private int score = 0;

    public ShapesMode(RoundController roundController) {
        roundCtrl = roundController;
    }

    /**
        Register object fallen into a correct hole and destroy it
    */
    public override void triggerScoreChange(GameObject triggeringObject) {
        if (!isRoundOver) {
            score++;
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
        Spawns and returns the board
    */
    public override GameObject spawnBoard() {
        board = GameObject.Instantiate(boardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
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

    /**
        Get the unit of scoring
    */
    public override string getScoreText() {
        return SCORETEXT;
    }

    public override IEnumerable<Score> getSortedScores(ScoreData sd) {
        return sd.scores.OrderByDescending(x => x.score);
    }


    // --- Not Applicable ---

    public override void onLifeLost() {
        // Nothing in this game mode
    }
}
