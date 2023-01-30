using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameMode {    
    
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
