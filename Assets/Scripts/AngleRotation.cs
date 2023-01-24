using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotation : SteeringMode {
    const string NAME = "Angle rotation";
    int[] angles = {30, 45, 60, 90};
    bool rotating = false;
    int chosenAngle;

    public AngleRotation() {
        System.Random rnd = new System.Random();
        chosenAngle = angles[rnd.Next(0, angles.Length)];
    }

    /**
        Move the board towards the right
    */
    public override void moveRight(GameObject board, Action<IEnumerator> startMovement) {
        if(!rotating) {
            startMovement(Rotate(new Vector3(0, chosenAngle, 0), board));
        }
    }

    /**
        Move the board towards the left
    */
    public override void moveLeft(GameObject board, Action<IEnumerator> startMovement){
        if(!rotating) {
            startMovement(Rotate(new Vector3(0, -chosenAngle, 0), board));
        }
    }

    /**
        Get name of steering mode
    */
    public override string getName() {
        return NAME;
    }
    
    /**
        Rotate a set amount of degrees over time
    */
    private IEnumerator Rotate(Vector3 angles, GameObject board) {
        float duration = (Math.Abs(angles.y)/90)*1.0f;
        rotating = true;

        Quaternion startRotation = board.transform.rotation;
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;

        for(float t = 0 ; t < duration ; t+= Time.deltaTime) {
            board.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            yield return null;
        }

        board.transform.rotation = endRotation;
        rotating = false;
    }
}
