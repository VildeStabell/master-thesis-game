using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CalibrationController : MonoBehaviour
{

    public const float maxCadence = 50f;
    public MasterThesisGameInput input;
    private InputAction cadenceInput;
    private float sumCadence = 0;
    private float startTime;
    private float usedTime;


    private void Awake()
    {
        input = new MasterThesisGameInput();
    }

    private void OnEnable()
    {
        cadenceInput = input.Player.Cadence;
        cadenceInput.Enable();
    }

    private void OnDisable()
    {
        cadenceInput = input.Player.Cadence;
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (sumCadence > maxCadence)
        {
            usedTime = Time.time - startTime;
            float eqCad = sumCadence / usedTime;
        }

    }


    private IEnumerator readCadence(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (sumCadence < maxCadence)
        {
            Vector2 cadenceVector = cadenceInput.ReadValue<Vector2>();
            float absX = Mathf.Abs(cadenceVector.x);
            float absY = Mathf.Abs(cadenceVector.y);
            float cadence = Mathf.Max(absX, absY) - Mathf.Min(absY, absX);
            sumCadence += cadence;
            StartCoroutine(readCadence(seconds));
        }
    }
}
