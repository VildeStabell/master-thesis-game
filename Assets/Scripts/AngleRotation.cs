using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotation : SteeringMode {
    const string NAME = "Angle rotation";

    /**
        Move the board towards the right
    */
    public override void moveRight(GameObject board) {
        board.transform.Rotate(0, -90, 0, Space.Self);
    }

    /**
        Move the board towards the left
    */
    public override void moveLeft(GameObject board){
        board.transform.Rotate(0, 90, 0, Space.Self);
    }

    /**
        Get name of steering mode
    */
    public override string getName() {
        return NAME;
    }
}
