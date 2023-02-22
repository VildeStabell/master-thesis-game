using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode {

    /**
        An event listener that changes the score based on the triggering object
    */
    public abstract void triggerScoreChange(GameObject triggeringObject);

    /**
        Get the current score
    */
    public abstract int getScore(bool roundOver);

    /**
        Get the prefab from the game mode
    */
    public abstract GameObject getBoardPrefab();

    /**
        Get name of game mode
    */
    public abstract string getName();

    /**
        Get description of game mode
    */
    public abstract string getDescription();
}
