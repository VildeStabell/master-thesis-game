using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardFlipper : MonoBehaviour {
    const float maxInput = 1.0f;
    const int maxAngle = 90;
    const float readSpeed = 0.2f;
    const float rotationSpeed = 0.1f;
    private float eqCadence;

    [Range(0, maxInput)]
    public float cadence;
    public MasterThesisGameInput input;

    private GameObject board;
    private InputAction cadenceInput;

    // Start is called before the first frame update
    void Start() {
        board = gameObject;
        eqCadence = SessionController.sessionCtrl.getEqCadence();

        StartCoroutine(readCadence(readSpeed));
    }

    // Update is called once per frame
    void Update() {
        flipBoard();
    }

    private void Awake() {
        input = new MasterThesisGameInput();
    }

    private void OnEnable() {
        cadenceInput = input.Player.Cadence;
        cadenceInput.Enable();
    }

    private void OnDisable() {
        cadenceInput = input.Player.Cadence;
    }

    private IEnumerator readCadence(float seconds) {
        yield return new WaitForSeconds(seconds);

        if (board != null) {
            Vector2 cadenceVector = cadenceInput.ReadValue<Vector2>();
            float absX = Mathf.Abs(cadenceVector.x);
            float absY = Mathf.Abs(cadenceVector.y);
            cadence = Mathf.Max(absX, absY) - Mathf.Min(absY, absX);

            StartCoroutine(readCadence(seconds));
        }
    }

    public void flipBoard() {
        if (board != null) {
            float angle = ((cadence - eqCadence) / (maxInput - eqCadence)) * maxAngle;
            angle = angle > -90 ? angle : -90;

            Quaternion newRotation = board.transform.rotation;
            newRotation.x = 0;
            newRotation.z = 0;
            newRotation = Quaternion.AngleAxis(angle, Vector3.right) * newRotation;

            board.transform.rotation = Quaternion.RotateTowards(board.transform.rotation, newRotation, Time.time * rotationSpeed);
        }
    }
}
