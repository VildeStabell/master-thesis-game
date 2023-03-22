using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour {
    public GameObject settingsMenu;
    public GameObject previousMenu;

    public void Start() {
        settingsMenu.SetActive(false);
    }

    /**
        Open the settings menu and close the previous one
    */
    public void open() {
        settingsMenu.SetActive(true);
        previousMenu.SetActive(false);
    }

    /**
        Open the settings menu and close the previous one
    */
    public void close() {
        settingsMenu.SetActive(false);
        previousMenu.SetActive(true);
    }
}
