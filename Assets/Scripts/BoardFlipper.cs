using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardFlipper : MonoBehaviour {
    const float maxInput = 1.0f;
    const int maxAngle = 90;
    const float readSpeed = 0.1f;
    const int sampleSize = 40; // How many of the previous readings to use when calculating cadence
    private float eqCadence;

    [Range(0, maxInput)]
    public float cadence;
    public float maxCadDifference = 0.3f;
    public MasterThesisGameInput inputActions;

    private GameObject board;
    private InputAction cadenceInput;
    private RoundController roundCtrl;
    private PlayerInput playerInput; // Needed to check control scheme
    private Queue<float> prevCadenceQueue = new Queue<float>();
    private float prevCadence = 999.0f;
    private Action<float> updateIndicator;

    private void Awake() {
        inputActions = new MasterThesisGameInput();
        playerInput = GameObject.Find("RoundController").GetComponent<PlayerInput>();
        updateIndicator = GameObject.Find("TiltIcon").GetComponent<TiltIndicator>().updateTilt;
    }

    // Start is called before the first frame update
    void Start() {
        board = gameObject;
        eqCadence = SessionController.sessionCtrl.getEqCadence();
        roundCtrl = GameObject.Find("RoundController").GetComponent<RoundController>();

        // Initialize cadence queue
        for (int i = 0; i < sampleSize; i++) {
            prevCadenceQueue.Enqueue(eqCadence);
        }

        StartCoroutine(readCadence(readSpeed));
    }

    // Update is called once per frame
    void Update() {
        if (!roundCtrl.isPaused()) {
            flipBoard();
        }
    }

    private void OnEnable() {
        cadenceInput = inputActions.Player.Cadence;
        cadenceInput.Enable();
    }

    private void OnDisable() {
        cadenceInput = inputActions.Player.Cadence;
    }

    private IEnumerator readCadence(float seconds) {
        yield return new WaitForSeconds(seconds);

        if (board != null) {
            if (playerInput.currentControlScheme == "Bike") {
                Vector2 cadenceVector = cadenceInput.ReadValue<Vector2>();
                float absX = Mathf.Abs(cadenceVector.x);
                float absY = Mathf.Abs(cadenceVector.y);
                cadence = Mathf.Max(absX, absY) - Mathf.Min(absY, absX);
            }

            float newCadence = cadence;

            // Mitigating false readings
            if(prevCadence == 999.0f || prevCadence < 0.3 || (Mathf.Abs(cadence - prevCadence) < maxCadDifference)) {
                prevCadence = cadence;
            }
            else {
                newCadence = prevCadence;
            }

            prevCadenceQueue.Dequeue();
            prevCadenceQueue.Enqueue(newCadence);

            StartCoroutine(readCadence(seconds));
        }
    }

    public void flipBoard() {
        if (board != null) {
            // For smoother flipping, actual cadence is the average of previous readings
            float smoothCad = prevCadenceQueue.ToArray().Sum() / sampleSize;

            float angle = ((smoothCad - eqCadence) / (maxInput - eqCadence)) * maxAngle;
            angle = angle > -90 ? angle : -90;

            Quaternion newRotation = board.transform.rotation;
            newRotation.x = 0;
            newRotation.z = 0;
            newRotation = Quaternion.AngleAxis(angle, Vector3.right) * newRotation;

            board.transform.rotation = Quaternion.RotateTowards(board.transform.rotation, newRotation, Time.time * readSpeed);

            updateIndicator(angle);
        }
    }
}
