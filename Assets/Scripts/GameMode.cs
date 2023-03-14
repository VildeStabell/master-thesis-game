using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode {

    /**
        An event listener that changes the score based on the triggering object
    */
    public abstract void triggerScoreChange(GameObject triggeringObject);

    /**
        An event listener that triggers when a life is lost
    */
    public abstract void onLifeLost();

    /**
        Spawns and returns the board
    */
    public abstract GameObject spawnBoard();

    /**
        Get the current score
    */
    public abstract int getScore(bool roundOver);

    /**
        Get name of game mode
    */
    public abstract string getName();

    /**
        Get description of game mode
    */
    public abstract string getDescription();

    /**
        Get the name describing the score type for this game mode
    */
    public abstract string getScoreText();

    /**
        Returns the supplied list sorted by the game mode's criteria
    */
    public abstract IEnumerable<Score> getSortedScores(ScoreData sd);
}
