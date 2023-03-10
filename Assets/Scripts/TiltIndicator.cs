using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltIndicator : MonoBehaviour {
    public GameObject green;
    public GameObject red;
    public GameObject[] indicators;
    public float greenRange = 10.0f;

    public void updateTilt(float angle) {
        foreach (GameObject indicator in indicators) {
            indicator.transform.localEulerAngles = new Vector3(0, 0, angle);
        }

        if (Mathf.Abs(angle) > greenRange) {
            red.SetActive(true);
            green.SetActive(false);
        } else {
            green.SetActive(true);
            red.SetActive(false);
        }
    }
}
