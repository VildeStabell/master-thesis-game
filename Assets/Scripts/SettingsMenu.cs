using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {
    public GameObject settingsMenu;
    public GameObject previousMenu;
    public Slider firstSlider;

    public void Start() {
        settingsMenu.SetActive(false);
    }

    /**
        Open the settings menu and close the previous one
    */
    public void open() {
        settingsMenu.SetActive(true);
        previousMenu.SetActive(false);
        firstSlider.Select();
    }

    /**
        Open the settings menu and close the previous one
    */
    public void close() {
        if (settingsMenu.activeSelf) {
            settingsMenu.SetActive(false);
            previousMenu.SetActive(true);
        }
    }
}
