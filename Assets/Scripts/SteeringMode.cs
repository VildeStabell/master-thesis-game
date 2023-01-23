using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringMode {    
    
    /**
        Move the board towards the right
    */
    public abstract void moveRight(GameObject board, Action<IEnumerator> startMovement);

    /**
        Move the board towards the left
    */
    public abstract void moveLeft(GameObject board, Action<IEnumerator> startMovement);

    /**
        Get name of steering mode
    */
    public abstract string getName();
}
