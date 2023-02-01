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
        float angle = (inputValue/maxInput)*maxAngle;
        board.transform.rotation = Quaternion.Euler(angle, 0.0f, 0.0f);
    }
}
