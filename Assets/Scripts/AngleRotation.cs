using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleRotation : SteeringMode {
    const string NAME = "Angle rotation";

    int[] angles = { 30, 45, 60, 90 };
    bool rotating = false;
    int chosenAngle;
    Action flipBoard;

    public AngleRotation() {
        System.Random rnd = new System.Random();
        chosenAngle = angles[rnd.Next(0, angles.Length)];
    }

    /**
        Move the board towards the right
    */
    public override void moveRight(GameObject board, Action<IEnumerator> startMovement) {
        if (!rotating) {
            startMovement(RotateY(chosenAngle, board));
        }
    }

    /**
        Move the board towards the left
    */
    public override void moveLeft(GameObject board, Action<IEnumerator> startMovement) {
        if (!rotating) {
            startMovement(RotateY(-chosenAngle, board));
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
    private IEnumerator RotateY(float angle, GameObject board) {
        if (flipBoard == null) {
            flipBoard = board.GetComponent<BoardFlipper>().flipBoard;
        }

        rotating = true;
        float duration = (Math.Abs(angle) / 90) * 1.0f;

        Quaternion startRotation = board.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.AngleAxis(angle, Vector3.up);

        for (float t = 0; t < duration; t += Time.deltaTime) {
            board.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t / duration);
            flipBoard();
            yield return null;
        }

        rotating = false;
    }
}
