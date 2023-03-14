using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BalanceMode : GameMode {
    const string NAME = "Balance Mode";
    const string DESC = "Try to keep the board steady for as long as possible.";
    const string SCORETEXT = "Score: ";
    GameObject boardPrefab = (GameObject)Resources.Load("BalanceBoard", typeof(GameObject));

    private RoundController roundCtrl;
    private GameObject board;
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

    public override void triggerScoreChange(GameObject triggeringObject) {
        // Nothing in this game mode
    }

    public override void onLifeLost() {
        // Nothing in this game mode
    }
}



