using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringMode {    
    
    /**
        Move the board towards the right
    */
    public abstract void moveRight(GameObject board);

    /**
        Move the board towards the left
    */
    public abstract void moveLeft(GameObject board);

    /**
        Get name of steering mode
    */
    public abstract string getName();
}
