using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardFlipper : MonoBehaviour {
    const float maxInput = 20.0f;
    const int maxAngle = 90;

    [Range(-maxInput, maxInput)]
    public float inputValue; // TODO: temp for inspector-testing

    private GameObject board;

    // Start is called before the first frame update
    void Start() {
        board = gameObject;
    }

    // Update is called once per frame
    void Update() {
        if (board != null) {
            float angle = (inputValue/maxInput)*maxAngle;

            Quaternion newRotation = board.transform.rotation;
            newRotation.x = 0;
            newRotation.z = 0;
            newRotation = Quaternion.AngleAxis(angle, Vector3.right) * newRotation;

            board.transform.rotation = newRotation;
        }
    }
}
