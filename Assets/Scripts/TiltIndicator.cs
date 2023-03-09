using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltIndicator : MonoBehaviour {
    public GameObject green;
    public GameObject red;
    public GameObject[] indicators;
    public float greenRange = 10.0f;

    public void updateTilt(float angle) {
        Debug.Log("Tilting to: " + angle); // TODO: remove

        foreach (GameObject indicator in indicators) {
            indicator.transform.rotation = Quaternion.Euler(90, 0, angle);
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
