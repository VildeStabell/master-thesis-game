using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMode : GameMode {
    const string NAME = "Balance Mode";
    GameObject boardPrefab = (GameObject) Resources.Load("BalanceBoard", typeof(GameObject)); 

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
}


// "Prefabs/BalanceBoard.prefab"