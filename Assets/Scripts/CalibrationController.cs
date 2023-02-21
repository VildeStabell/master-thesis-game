using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CalibrationController : MonoBehaviour {

    public const float readSpeed = 0.2f;
    public const float maxCadence = 50f;
    
    public MasterThesisGameInput input;
    public TMP_Text LoadingPercentageText;
    public Slider loadingBar;

    private InputAction cadenceInput;
    private float sumCadence = 0;
    private float startTime = 0;
    private float usedTime = 0;


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

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(readCadence(readSpeed));
    }

    // Update is called once per frame
    void Update() {
        if (sumCadence > maxCadence && usedTime == 0) {
            //eqCad is a number between 0.3-0.9, defined by the prosentage caluclated by sumCadence/usedTime*2
            //This is because the max of sumCadence/usedTime = 50

            usedTime = Time.time - startTime;
            float eqCad = Mathf.Floor((sumCadence / usedTime) * 20 * 60) / 10000 + 0.30f;
            SessionController.sessionCtrl.setEqCadence(eqCad);
            SceneManager.LoadScene(sceneName: "MainMenuScene");
        }

    }

    private IEnumerator readCadence(float seconds) {
        yield return new WaitForSeconds(seconds);

        if (sumCadence < maxCadence) {
            Vector2 cadenceVector = cadenceInput.ReadValue<Vector2>();
            float absX = Mathf.Abs(cadenceVector.x);
            float absY = Mathf.Abs(cadenceVector.y);
            float cadence = Mathf.Max(absX, absY) - Mathf.Min(absY, absX);
            sumCadence += cadence;
            
            if (sumCadence > 0 && startTime == 0) {
                startTime = Time.time;
            }

            float progress = Mathf.Clamp01(sumCadence / maxCadence / .9f);
            loadingBar.value = progress;
            LoadingPercentageText.text = progress * 100f + "%";


            StartCoroutine(readCadence(seconds));
        }
    }
}
